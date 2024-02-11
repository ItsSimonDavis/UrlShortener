using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class UrlLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string LongUrl { get; set; }
        public string GetShortUrl(string scheme, string host)
        {
            string idInBase36 = Helper.ConvertIntToStringBase36(Id);
            return $"{scheme}://{host}/?{idInBase36}";
        }
    }
}
