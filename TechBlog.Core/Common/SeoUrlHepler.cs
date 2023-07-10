using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace TechBlog.Core.Common
{
    public static class SeoUrlHepler
    {
        /// <summary>
        /// covert string value to UrlSlug
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUrlSlug(string value)
        {
            // First to lower case 
            value = value.ToLowerInvariant();

            // Remove all accents
            value = RemoveDiacritics(value);

            // Replace spaces with hyphens
            value = value.Replace(" ", "-");

            // Remove invalid characters
            value = Regex.Replace(value, @"[^a-z0-9\-]", "", RegexOptions.Compiled);

            // Trim hyphens from beginning and end
            value = value.Trim('-');

            // Replace double hyphens
            value = Regex.Replace(value, @"-{2,}", "-", RegexOptions.Compiled);

            return value;
        }

        private static string RemoveDiacritics(string value)
        {
            string normalizedString = value.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(normalizedString[i]);
                }
            }

            return stringBuilder.ToString();
        }

    }
}