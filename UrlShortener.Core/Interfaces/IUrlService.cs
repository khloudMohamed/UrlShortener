using UrlShortener.Core.Entities;
using System.Threading.Tasks;

namespace UrlShortener.Core.Interfaces
{
    public interface IUrlService
    {
        Task<string> CreateShortUrlAsync(string originalUrl);
        Task<Url?> GetByShortUrlAsync(string shortUrl);
        Task SaveChangesAsync();
    }
}
