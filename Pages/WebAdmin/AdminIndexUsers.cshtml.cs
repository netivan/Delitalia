using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelliItalia_Razor.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DelliItalia_Razor.Pages.WebAdmin
{
    public class AdminIndexUsersModel : PageModel
    {

        private readonly DelliItalia_Razor.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        private readonly RoleManager<IdentityRole> _roleMan;
        private readonly UserManager<WebshopUser> _webUser;

        public AdminIndexUsersModel(DelliItalia_Razor.Data.ApplicationDbContext context
            , IWebHostEnvironment webHost, RoleManager<IdentityRole> roleMan, UserManager<WebshopUser> webUser)
        {
            _context = context;
            _webHost = webHost;
            _roleMan = roleMan;
            _webUser = webUser;
        }

        [BindProperty]
        public IEnumerable<IdentityRole> roleMod { get; set; }
        public IEnumerable<WebshopUser> webUser { get; set; }

        [BindProperty]
        public RoleModel roller { set; get; }
        
        public async Task OnGetAsync()
        {
            roleMod = _roleMan.Roles;
            var webUser = _webUser.Users;
        }

        public async Task<IActionResult> OnPostAsync(RoleModel roller)
        {
            if (ModelState.IsValid)
            {
                IdentityRole idRole = new IdentityRole
                {
                    Name = roller.RoleName
                };

                IdentityResult result = await _roleMan.CreateAsync(idRole);
                if (result.Succeeded)
                {
                    return RedirectToPage("./AdminIndexUsers");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToPage("./AdminIndexUsers");
        }
       

    }
}
