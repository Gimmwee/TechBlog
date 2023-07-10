using FA.JustBlog.UI.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FA.JustBlog.UI.Areas.Identity.Pages.Role
{
    [Authorize(Roles = "Admin, Blog Owner, Contibutor")]
    public class UserModel : PageModel
    {
        const int USER_PER_PAGE = 10;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentifyUsingUser> _userManager;

        public UserModel(RoleManager<IdentityRole> roleManager,
                          UserManager<IdentifyUsingUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;


        }
        public class UserInList : IdentifyUsingUser
        {
            // Liệt kê các Role của User ví dụ: "Admin,Editor" ...
            public string listroles { set; get; }
        }

        public List<UserInList> users;
        public int totalPages { set; get; }

        [TempData] // Sử dụng Session
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int pageNumber { set; get; }
        public void OnPost() => NotFound("Don't post");
        public async Task<IActionResult> OnGet()
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    await _userManager.CreateAsync(new UsingIdentityUser { UserName = "user" + i, Email = "user" + i + "@gmail.com", FirstName = "User", LastName = "User 1" }, "123");
            //}
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            var lusers = (from u in _userManager.Users
                          orderby u.UserName
                          select new UserInList()
                          {
                              Id = u.Id,
                              UserName = u.UserName,
                          });

            int totalUsers = await lusers.CountAsync();


            totalPages = (int)Math.Ceiling((double)totalUsers / USER_PER_PAGE);

            users = await lusers.Skip(USER_PER_PAGE * (pageNumber - 1)).Take(USER_PER_PAGE).ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.listroles = string.Join(",", roles.ToList());
            }

            return Page();
        }
    }
}
