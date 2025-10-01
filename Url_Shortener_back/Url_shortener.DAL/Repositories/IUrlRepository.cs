using Urs_shortener.Models.Models;

namespace Url_shortener.DAL.Repositories;

public interface IUrlRepository
{
    public Task<UrlEntry> Create(UrlEntry entity);
    public Task<UrlEntry> Update(UrlEntry entity, long id);
    public Task Delete(long id);
    public Task<UrlEntry?> Get(long id);
    public Task<IEnumerable<UrlEntry>> GetAll();
    public Task<UrlEntry> GetByShortCode(string code);
}