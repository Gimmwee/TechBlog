using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.UI.Areas.Identity.Pages.Role
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public List<IdentityRole> Roles { get; set; }

        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> OnGet()
        {
            Roles = await _roleManager.Roles.ToListAsync();

            return Page();
        }

        [TempData]
        public string StatusMessage { get; set; }
    }
}
