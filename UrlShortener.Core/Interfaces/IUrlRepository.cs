using UrlShortener.Core.Entities;
using System.Threading.Tasks;

namespace UrlShortener.Core.Interfaces
{
    public interface IUrlRepository
    {
        Task<Url?> GetByShortUrlAsync(string shortUrl);
        Task AddAsync(Url url);
        Task<bool> ExistsShortUrlAsync(string shortUrl);
        Task SaveChangesAsync();
    }
}
