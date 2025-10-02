using Microsoft.AspNetCore.Identity;

namespace Urs_shortener.Models.Models;


public class ApplicationUser : IdentityUser
{
    public ICollection<UrlEntry> Urls { get; set; } = new List<UrlEntry>();
}