using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunescapeAPI
{
    internal class Utils
    {
        internal static readonly string RunedateDayZero = "27 February 2002";

        internal static T GetJson<T>(string URL)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString(URL);
            wc.Dispose();
            return JsonConvert.DeserializeObject<T>(webData);
        }
    }
}