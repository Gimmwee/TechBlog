﻿using TechBlog.UI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace TechBlog.UI.Areas.Identity.Pages.Role
{
    
    public class AddUserRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentifyUsingUser> _userManager;
        public AddUserRoleModel(RoleManager<IdentityRole> roleManager, UserManager<IdentifyUsingUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public class InputModel
        {
            [Required]
            public string ID { set; get; }
            public string Name { set; get; }

            public string[] RoleNames { set; get; }

        }

        [BindProperty]
        public InputModel Input { set; get; }

        [BindProperty]
        public bool isConfirmed { set; get; }

        [TempData] // Sử dụng Session
        public string StatusMessage { get; set; }

        public IActionResult OnGet() => NotFound("Not Found");

        public List<string> AllRoles { set; get; } = new List<string>();

        public async Task<IActionResult> OnPost()
        {


            var user = await _userManager.FindByIdAsync(Input.ID);
            if (user == null)
            {
                return NotFound("Not Found Role To Delete");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var allroles = await _roleManager.Roles.ToListAsync();

            allroles.ForEach((r) => {
                AllRoles.Add(r.Name);
            });

            if (!isConfirmed)
            {
                Input.RoleNames = roles.ToArray();
                isConfirmed = true;
                StatusMessage = "";
                ModelState.Clear();
            }
            else
            {
                // Update add and remove
                StatusMessage = "Updated";
                if (Input.RoleNames == null) Input.RoleNames = new string[] { };
                foreach (var rolename in Input.RoleNames)
                {
                    if (roles.Contains(rolename)) continue;
                    await _userManager.AddToRoleAsync(user, rolename);
                }
                foreach (var rolename in roles)
                {
                    if (Input.RoleNames.Contains(rolename)) continue;
                    await _userManager.RemoveFromRoleAsync(user, rolename);
                }

            }

            Input.Name = user.UserName;
            return Page();
        }
    }
}
