using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunescapeAPI
{
    public class GrandExchange
    {
        private static readonly string GEUpdate = "https://secure.runescape.com/m=itemdb_rs/api/info.json";
        private static readonly string BaseURL = "http://services.runescape.com/m=itemdb_rs/api/catalogue/";
        private static readonly string CatalogueCatURL = BaseURL + "category.json?category=";

        public static int LastUpdate()
        {
            return Utils.GetJson<int>(GEUpdate);
        }

        public static DateTime LastUpdateUTC()
        {
            var BeginDate = Utils.RunedateDayZero;
            var BeginDT = DateTime.Parse(BeginDate);
            return BeginDT.AddDays(LastUpdate());
        }

        public static Dictionary<string, int> GetCatalogueCatagory(int CategoryID)
        {
            return Utils.GetJson<Dictionary<string, int>>(CatalogueCatURL + CategoryID);
        }
    }

    public class GEItems
    {
        public int Total;
        public List<GEItem> Items;
    }

    public class GEItem
    {
        public string Icon;
        public string Icon_Large;
        public int ID;
        public string Type;
        public string TypeIcon;
        public string Name;
        public string Description;
        public Dictionary<string, string> Current;
        public Dictionary<string, string> Today;
        public bool Members;
    }
}