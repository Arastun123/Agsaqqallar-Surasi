using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Agsaqqallarsurasi.Helpers;

public static class UrlHelpers
{
    public static string GenerateSlug(string title)
    {
        string processedTitle = Regex.Replace(title.ToLower().Trim(), @"\s+", "-")
                                     .Replace("ə", "e")
                                     .Replace("ç", "c")
                                     .Replace("ğ", "g")
                                     .Replace("ı", "i")
                                     .Replace("ö", "o")
                                     .Replace("ş", "s")
                                     .Replace("ü", "u")
                                     .Replace(",", "")
                                     .Replace(".", "");
        return processedTitle;
    }

    public static string GenerateHash(int id)
    {
        var bytes = BitConverter.GetBytes(id);
        var hash = BitConverter.ToString(new SHA1Managed().ComputeHash(bytes)).Replace("-", "").ToLower();
        return hash.Substring(0, 10);
    }
}

