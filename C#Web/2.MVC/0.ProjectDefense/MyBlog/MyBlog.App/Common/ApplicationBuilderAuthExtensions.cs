namespace MyBlog.App.Common
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using MyBlog.Models.Users;
    using MyBlog.Common;

    public static class ApplicationBuilderAuthExtensions
    {
        

        private static readonly IdentityRole[] initialRoles =
        {
            new IdentityRole(CommonConstants.OwnerSuffix),
            new IdentityRole(CommonConstants.AdminSuffix),
            new IdentityRole(CommonConstants.PremiumUserSuffix)
        };

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                foreach (var role in initialRoles)
                {
                    if(!await roleManager.RoleExistsAsync(role.Name))
                    {
                        var result = await roleManager.CreateAsync(role);
                    }
                }

                var owner = await userManager.FindByNameAsync(CommonConstants.DefaultOwnerUsername);

                if(owner == null)
                {
                    owner = new User
                    {
                        UserName = CommonConstants.DefaultOwnerUsername,
                        Email = CommonConstants.DefaultOwnerEmail,
                        FullName = CommonConstants.DefaultOwnerFullName
                    };

                    await userManager.CreateAsync(owner, CommonConstants.DefaultOwnerPassword);

                    await userManager.AddToRoleAsync(owner, initialRoles[CommonConstants.RolesListOwnerIndex].Name);
                }

                var admin = await userManager.FindByNameAsync(CommonConstants.DefaultAdminUsername);

                if (admin == null)
                {
                    admin = new User
                    {
                        UserName = CommonConstants.DefaultAdminUsername,
                        Email = CommonConstants.DefaultAdminEmail,
                        FullName = CommonConstants.DefaultAdminFullName
                    };

                    await userManager.CreateAsync(admin, CommonConstants.DefaultAdminPassword);

                    await userManager.AddToRoleAsync(admin, initialRoles[CommonConstants.RolesListAdminIndex].Name);
                }
            }
        }
    }
}
