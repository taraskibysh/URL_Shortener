namespace Urs_shortener.Models.Dtos;

public class UrlResponceDto
{
    public long Id { get; set; }
    public string ShortUrl { get; set; } = string.Empty;

    public string OriginalUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; }
}