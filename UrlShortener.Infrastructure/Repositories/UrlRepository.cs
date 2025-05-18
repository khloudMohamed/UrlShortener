using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UrlShortener.Core.Entities;
using UrlShortener.Core.Interfaces;
using UrlShortener.Infrastructure.Data;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlDbContext _context;

        public UrlRepository(UrlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
        }

        public async Task<bool> ExistsShortUrlAsync(string shortUrl)
        {
            return await _context.Urls.AnyAsync(u => u.ShortUrl == shortUrl);
        }

        public async Task<Url?> GetByShortUrlAsync(string shortUrl)
        {
            return await _context.Urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
