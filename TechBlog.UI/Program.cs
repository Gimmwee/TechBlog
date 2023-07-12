using TechBlog.UI.Areas.Identity.Data;
using TechBlog.UI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechBlog.Core.Repository.UnitOfWork;

namespace TechBlog.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;
            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    // Đọc thông tin Authentication:Google từ appsettings.json
                    IConfigurationSection googleAuthNSection = configuration.GetSection("Authentication:Google");

                    // Thiết lập ClientID và ClientSecret để truy cập API google
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                    googleOptions.CallbackPath = "/dang-nhap-tu-google";

                })
                .AddFacebook(facebookOptions => {
                    // Đọc cấu hình
                    IConfigurationSection facebookAuthNSection = configuration.GetSection("Authentication:Facebook");
                    facebookOptions.AppId = facebookAuthNSection["AppId"];
                    facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                    // Thiết lập đường dẫn Facebook chuyển hướng đến
                    facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
                });
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultString");

            builder.Services.AddDbContext<TechBlogUIContext>(option => option.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentifyUsingUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>().AddEntityFrameworkStores<TechBlogUIContext>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapRazorPages();
            app.Run();
        }
    }
}