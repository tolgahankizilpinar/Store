using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";
            const string adminRole = "Admin";

            //UserManager
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            //RoleManager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            // Önce Admin rolünün varlığını kontrol et ve yoksa oluştur
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                var role = new IdentityRole(adminRole);
                var roleCreateResult = await roleManager.CreateAsync(role);

                if (!roleCreateResult.Succeeded)
                    throw new Exception($"Admin role could not be created: {string.Join(", ", roleCreateResult.Errors.Select(e => e.Description))}");
            }

            IdentityUser? user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "tolgahan.kizilpinar@hotmail.com",
                    PhoneNumber = "555123123344",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                   throw new Exception($"Admin user could not be created: {string.Join(", ", result.Errors.Select(e => e.Description))}");

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                        .Roles
                        .Select(r => r.Name ?? "")
                        .ToList()
                );

                
                if (!roleResult.Succeeded)
                     throw new Exception($"Could not add Admin role to user: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
            }
        }
    }
}