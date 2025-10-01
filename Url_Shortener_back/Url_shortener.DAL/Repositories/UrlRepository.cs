using Microsoft.EntityFrameworkCore;
using Urs_shortener.Models.Models;

namespace Url_shortener.DAL.Repositories;

public class UrlRepository : IUrlRepository
{
    private ApplicationDbContext _dbContext;

    public UrlRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UrlEntry> Create(UrlEntry entity)
    {
        var result = await _dbContext.Urls.AddAsync(entity);
        await _dbContext.SaveChangesAsync();  
        return result.Entity;
    }
    
    public async Task<UrlEntry> Update(UrlEntry entity, long id)
    {
        var originalValue = await _dbContext.Urls.FirstOrDefaultAsync(u => u.Id == id);
        if (originalValue == null)
        {
            throw new KeyNotFoundException($"UrlEntry with ID {id} was not found.");
        }

        originalValue.OriginalUrl = entity.OriginalUrl;
        originalValue.ShortCode = entity.ShortCode;

        await _dbContext.SaveChangesAsync();  

        return originalValue;
    }


    public async Task Delete(long id)
    {
        var originalValue = await _dbContext.Urls.FirstOrDefaultAsync(u => u.Id == id);
        if (originalValue == null)
        {
            throw new KeyNotFoundException($"UrlEntry with ID {id} was not found.");
        }
        _dbContext.Urls.Remove(originalValue);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UrlEntry?> Get(long id)
    {
        var originalValue = await _dbContext.Urls.FirstOrDefaultAsync(u => u.Id == id);
        return originalValue;
    }
    
    public async Task<IEnumerable<UrlEntry>> GetAll()
    {
        return await _dbContext.Urls.ToListAsync();
    }

    public async Task<UrlEntry> GetByShortCode(string code)
    {
       return await _dbContext.Urls.FirstOrDefaultAsync((e) => e.ShortCode == code);
    }

}