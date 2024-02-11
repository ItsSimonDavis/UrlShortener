using AdvancedREI;
using System;

namespace UrlShortener
{
    public static class Helper
    {
        public static string ConvertIntToStringBase36(long num)
        {
            return Base36.NumberToBase36(num);
        }
        public static long ConvertStringBase36ToLong(string base36String)
        {
            return Base36.Base36ToNumber(base36String);
        }
    }
}
