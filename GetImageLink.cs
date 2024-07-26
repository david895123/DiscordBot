using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot
{
    internal class GetImageLink
    {

        public static string GetImage(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = client.GetStringAsync(client.BaseAddress).Result;

            return getBetween(response, "\"url\":\"", "\",\"width\"");
        }

        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }


    }
}
