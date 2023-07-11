using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.Data;

namespace FA.JustBlog.UI.Areas.Identity.Pages.Role
{
    [Authorize(Roles = "Admin, Blog Owner")]
    public class DeleteModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public class InputModel
        {
            [Required]
            public string Id { set; get; }
            public string Name { set; get; }

        }
        [BindProperty]
        public InputModel Input { set; get; }

        [BindProperty]
        public bool isConfirmed { set; get; }

        [TempData] // Sử dụng Session
        public string StatusMessage { get; set; }
        public IActionResult OnGet() => NotFound("Not Found");

        public async Task<IActionResult> OnPost()
        {
            var role = await _roleManager.FindByIdAsync(Input.Id);

            if (role == null)
            {
                return NotFound("Not Found Role To Delete");
            }

            ModelState.Clear();

            if (isConfirmed)
            {
                //Xóa
                await _roleManager.DeleteAsync(role);
                StatusMessage = "Deleted " + role.Name;

                return RedirectToPage("Index");
            }
            else
            {
                Input.Name = role.Name;
                isConfirmed = true;

            }

            return Page();
        }
    }
}
