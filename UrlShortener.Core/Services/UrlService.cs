using UrlShortener.Core.Entities;
using UrlShortener.Core.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Core.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _repository;
        private readonly Random _random = new();

        public UrlService(IUrlRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateShortUrlAsync(string originalUrl)
        {
            for (int i = 0; i < 5; i++)
            {
                var shortCode = GenerateShortCode();
                if (!await _repository.ExistsShortUrlAsync(shortCode))
                {
                    var url = new Url
                    {
                        OriginalUrl = originalUrl,
                        ShortUrl = shortCode,
                        VisitCount = 0
                    };
                    await _repository.AddAsync(url);
                    await _repository.SaveChangesAsync();
                    return shortCode;
                }
            }
            throw new Exception("Failed to generate a unique short URL.");
        }

        public async Task<Url?> GetByShortUrlAsync(string shortUrl)
        {
            return await _repository.GetByShortUrlAsync(shortUrl);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        private string GenerateShortCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, 6).Select(_ => chars[_random.Next(chars.Length)]).ToArray());
        }
    }
}
