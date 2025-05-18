using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UrlShortener.Core.Entities
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; } = null!;
        public string ShortUrl { get; set; } = null!;
        public int VisitCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
