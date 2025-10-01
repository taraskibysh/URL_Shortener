namespace Urs_shortener.Models.Models;

public class UrlEntry
{
    public long Id { get; set; }
    public string ShortCode { get; set; }

    public string OriginalUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; } 
}