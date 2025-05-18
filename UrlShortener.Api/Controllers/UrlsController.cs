using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Core.Entities;
using UrlShortener.Infrastructure.Data;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("urls")]  // POST shorten: /urls/shorten
    public class UrlsController : ControllerBase
    {
        private readonly UrlDbContext _context;
        private readonly ILogger<UrlsController> _logger;

        public UrlsController(UrlDbContext context, ILogger<UrlsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> Shorten([FromBody] UrlRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Url))
                    return BadRequest("URL is required");

                for (int i = 0; i < 5; i++)
                {
                    var shortCode = GenerateShortCode();  // This works because method is inside this controller
                    var existing = await _context.Urls.FirstOrDefaultAsync(x => x.ShortUrl == shortCode);
                    if (existing == null)
                    {
                        var url = new Url { OriginalUrl = request.Url, ShortUrl = shortCode };
                        _context.Urls.Add(url);
                        await _context.SaveChangesAsync();
                        return Created("", new { shortened_url = shortCode });
                    }
                }

                return StatusCode(500, "Failed to generate a unique short URL");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Server error");
            }
        }

        private string GenerateShortCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Range(0, 6).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
    }

    [ApiController]
    public class RedirectController : ControllerBase
    {
        private readonly UrlDbContext _context;

        public RedirectController(UrlDbContext context)
        {
            _context = context;
        }

        [HttpGet("/{shortUrl}")]  // root-level route like https://localhost:7250/iudpgS
        public async Task<IActionResult> RedirectToOriginal(string shortUrl)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);
            if (url == null)
                return NotFound("Short URL not found");

            url.VisitCount++;
            await _context.SaveChangesAsync();

            return Redirect(url.OriginalUrl);
        }
    }

    public class UrlRequest
    {
        public string Url { get; set; } = string.Empty;
    }
}
