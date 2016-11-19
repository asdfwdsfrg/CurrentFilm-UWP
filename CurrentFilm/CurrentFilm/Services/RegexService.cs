using System.Text.RegularExpressions;

namespace CurrentFilm.Services
{
    public static class RegexService
    {
        public static string RegexAdapt(string pattern, string input)
        {
            Regex reg = new Regex(pattern);
            Match matchedString = reg.Match(input);
            return matchedString.ToString();
        }
    }
}
