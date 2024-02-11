using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Service;

namespace UrlShortener.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UrlShortenService _urlShortenService;

        public IndexModel(UrlShortenService urlShortenService)
        {
            _urlShortenService = urlShortenService;
        }

        public async Task OnGet()
        {
            QueryString requestQueryString = Request.QueryString;
            string strRequestQueryString = requestQueryString.ToString();

            if (strRequestQueryString.Equals("index", StringComparison.CurrentCultureIgnoreCase) ||
                !requestQueryString.HasValue ||
                strRequestQueryString.Length < 2)
                return;

            // Remove the ? from query string
            strRequestQueryString = strRequestQueryString.Substring(1);

            string urlToRedirectTo = await _urlShortenService.GetLongUrlFromQueryString(strRequestQueryString);
            Response.Redirect(urlToRedirectTo);
        }
    }
}
