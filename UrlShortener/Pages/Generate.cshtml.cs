using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UrlShortener.Models;
using UrlShortener.Service;

namespace UrlShortener.Pages
{
    [BindProperties]
    public class GenerateModel : PageModel
    {
        [Required]
        [MaxLength(3000)]
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }

        private readonly UrlShortenService _urlShortenService;
        public GenerateModel(UrlShortenService urlShortenService)
        {
            _urlShortenService = urlShortenService;
        }

        public async Task OnPostAsync()
        {
            if (!Uri.IsWellFormedUriString(LongUrl, UriKind.Absolute))
            {
                ModelState.AddModelError("LongUrl", "Url Is Not Valid");
                return;
            }

            ModelState.Remove("ShortUrl");

            UrlLink urlLink = new UrlLink() { LongUrl = LongUrl};
            await _urlShortenService.CreateUrlLink(urlLink);

            ShortUrl = urlLink.GetShortUrl(Request.Scheme, Request.Host.ToString());
        }
    }
}
