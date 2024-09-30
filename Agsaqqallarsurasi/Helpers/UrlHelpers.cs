using System.Text.RegularExpressions;

namespace Agsaqqallarsurasi.Helpers;

public static class UrlHelpers
{
    public static string GenerateSlug(string title)
    {
        return Regex.Replace(title.ToLower().Trim(), @"\s+", "-")
                    .Replace("ə", "e")
                    .Replace("ç", "c")
                    .Replace("ğ", "g")
                    .Replace("ı", "i")
                    .Replace("ö", "o")
                    .Replace("ş", "s")
                    .Replace("ü", "u")
                    .Replace(",", "")
                    .Replace(".", "");
    }
}

