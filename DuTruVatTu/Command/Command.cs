using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DuTruVatTu.Command
{
    public class Command
    {
        public string MaHoaChuoi(string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public string RemoveSpace(string str)
        {
            return Regex.Replace(str, @"\s+", "-");
        }

        public string ConvertFileName(string str)
        {
            str = RemoveSpace(str);
            str = convertToUnSign3(str);
            return str.ToLower();
        }
    }
}