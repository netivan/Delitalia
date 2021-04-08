using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelliItalia_Razor.Model;
using DelliItalia_Razor.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    public class EditRollsModel : PageModel
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly RoleManager<IdentityRole> _roleMan;
        private readonly UserManager<WebshopUser> _webUser;

        public EditRollsModel(IWebHostEnvironment webHost, RoleManager<IdentityRole> roleMan, UserManager<WebshopUser> webUser)
        {
            _webHost = webHost;
            _roleMan = roleMan;
            _webUser = webUser;
        }

        [BindProperty]
        public IEnumerable<IdentityRole> roleMod { get; set; }
        public IEnumerable<WebshopUser> webUser { get; set; }
        [BindProperty]
        public EditRoleViewModel VMRoll { set; get; }

        [BindProperty]
        public RoleModel roller { set; get; }

        //public async Task OnGetAsync()
        //{
        //    roleMod = _roleMan.Roles;
        //    webUser = _webUser.Users;
        //}
        public async Task<IActionResult> OnGetAsync(string id)
        {
            var role = await _roleMan.FindByIdAsync(id);
            if (role == null)
            {
                return RedirectToPage("./AdminIndexUsers");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RollName = role.Name
            };

            foreach (var user in _webUser.Users)
            {
                if (await _webUser.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);   
                }
            }
            ViewData["Roll"] = new EditRoleViewModel
            {
                Id = role.Id,
                RollName = role.Name,
                Users = model.Users
            };



            return Page();
        }
    }
}
