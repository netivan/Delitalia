using DelliItalia_Razor.Model;
using DelliItalia_Razor.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelliItalia_Razor.Controllers
{
    //reservVersionSano
    public class WebAdminiController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly RoleManager<IdentityRole> _roleMan;
        private readonly UserManager<WebshopUser> _userMan;

        public WebAdminiController(IWebHostEnvironment webHost, RoleManager<IdentityRole> roleMan, UserManager<WebshopUser> userMan)
        {
            _webHost = webHost;
            _roleMan = roleMan;
            _userMan = userMan;
        }
        public string RollId { set; get; }
        public IList<UserRoleViewModel> userRoleVLList = new List<UserRoleViewModel>();
        public UserRoleViewModel userRoleVM { set; get; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleMan.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRoles(string id)
        {
            var role = await _roleMan.FindByIdAsync(id);
            
            if(role == null)
            {
                return null;
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RollName = role.Name
            };
            foreach(var user in _userMan.Users)
            {
                if(await _userMan.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRoles(EditRoleViewModel model)
        {
            var role = await _roleMan.FindByIdAsync(model.Id);

            if (role == null)
            {
                return RedirectToPage("~/WebAdmin/AdminIndexUsers");
            }
            else
            {
                role.Name = model.RollName;
                var result = await _roleMan.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToPage("WebAdmin","AdminIndexUsers");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description) ;
                }
                return View(model);
            }            
        }

        [HttpGet]
        public async Task<IActionResult> UserRoles(string roleId)
        {
            ViewBag.roleId = roleId;
            var roll = await _roleMan.FindByIdAsync(roleId);
            if (roll == null)
            {
                return RedirectToAction("EditRoles", new { Id = roleId });
            }
            var model = new List<UserRoleViewModel>();
            foreach(var user in _userMan.Users)
            {
                var userRVM = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await _userMan.IsInRoleAsync(user, roll.Name))
                {
                    userRVM.IsSelected = true;
                }
                else
                {
                    userRVM.IsSelected = false;
                }
                model.Add(userRVM);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserRoles(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleMan.FindByIdAsync(roleId);
            if(role == null)
            {
                return RedirectToAction("EditRoles", new { Id = roleId });
            }
            for(int i = 0; i < model.Count; i++)
            {
                var user = await _userMan.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;
                
                if(model[i].IsSelected && !(await _userMan.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userMan.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userMan.IsInRoleAsync(user, role.Name))
                {
                    result = await _userMan.RemoveFromRoleAsync(user, role.Name );
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if(i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRoles", new { Id = roleId});
                    }
                }

                
            }
            return RedirectToAction("EditRoles", new { Id = roleId });
        }         
    }
}
