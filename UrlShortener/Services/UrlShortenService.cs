using Microsoft.EntityFrameworkCore;
using UrlShortener.DataAccess;
using UrlShortener.Models;

namespace UrlShortener.Service
{
    public class UrlShortenService
    {
        private readonly ApplicationDbContext _dbContext;

        public UrlShortenService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetLongUrlFromQueryString(string queryString)
        {
            long id = Helper.ConvertStringBase36ToLong(queryString);

            return await _dbContext.urlLinks.Where(x => x.Id == id)
                .Select(x => x.LongUrl)
                .FirstAsync();
        }

        public async Task CreateUrlLink(UrlLink urlLink)
        {
            _dbContext.Add(urlLink);
            await _dbContext.SaveChangesAsync();
        }
    }
}
