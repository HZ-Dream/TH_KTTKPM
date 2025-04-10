using ASCWeb.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ASC.Model.BaseTypes;

namespace ASCWeb.Data
{
    public class IdentitySeed : IIdentitySeed
    {
        public async Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<ApplicationSettings> options)
        {
            // Tạo các roles nếu chưa tồn tại
            var roles = options.Value.Roles.Split(new char[] { ',' });

            foreach (var role in roles)
            {
                try
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        IdentityRole storageRole = new IdentityRole { Name = role };
                        await roleManager.CreateAsync(storageRole);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            // Tạo Admin nếu chưa có
            var admin = await userManager.FindByEmailAsync(options.Value.AdminEmail);
            if (admin == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = options.Value.AdminName,
                    Email = options.Value.AdminEmail,
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(user, options.Value.AdminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", options.Value.AdminEmail));
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("IsActive", "True"));
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                }
            }
            else
            {
                // Nếu Admin đã tồn tại, kiểm tra và thêm claim nếu cần
                var claims = await userManager.GetClaimsAsync(admin);
                if (!claims.Any(c => c.Type == "IsActive"))
                {
                    await userManager.AddClaimAsync(admin, new System.Security.Claims.Claim("IsActive", "True"));
                }
            }

            // Tạo Engineer nếu chưa có
            var engineer = await userManager.FindByEmailAsync(options.Value.EngineerEmail);
            if (engineer == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = options.Value.EngineerName,
                    Email = options.Value.EngineerEmail,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                IdentityResult result = await userManager.CreateAsync(user, options.Value.EngineerPassword);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", options.Value.EngineerEmail));
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("IsActive", "True"));
                    await userManager.AddToRoleAsync(user, Roles.Engineer.ToString());
                }
            }
            else
            {
                // Nếu Engineer đã tồn tại, kiểm tra và thêm claim nếu cần
                var claims = await userManager.GetClaimsAsync(engineer);
                if (!claims.Any(c => c.Type == "IsActive"))
                {
                    await userManager.AddClaimAsync(engineer, new System.Security.Claims.Claim("IsActive", "True"));
                }
            }
        }
    }
}