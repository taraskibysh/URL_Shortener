namespace Url_shortener.DAL.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Urs_shortener.Models.Models; 
using Url_shortener.DAL; 

public static class SeedRoleData
{
    private static readonly string[] _roleNames = { "Admin", "User" };

    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var logger = serviceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();
        var config = serviceProvider.GetRequiredService<IConfiguration>();
        
        foreach (var roleName in _roleNames)
        {
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                
                if (result.Succeeded)
                {
                    logger.LogInformation($"Роль '{roleName}' успішно створена.");
                }
                else
                {
                    logger.LogError($"Помилка створення ролі '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
        
        string adminEmail = config["AdminUser:Email"];
        string adminPassword = config["AdminUser:Password"];
        
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(newAdmin, adminPassword);
            if (createResult.Succeeded)
            {
                logger.LogInformation("Адміністратор створений успішно.");
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
            else
            {
                logger.LogError($"Помилка створення адміністратора: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            logger.LogInformation("Адміністратор вже існує.");
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
