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
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var logger = serviceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

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
    }
}
