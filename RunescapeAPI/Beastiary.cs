using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RunescapeAPI
{
    //https://runescape.fandom.com/wiki/Application_programming_interface
    //https://runescape.fandom.com/wiki/RuneScape_Bestiary
    public class Beastiary
    {
        private static readonly string BaseURL = "http://services.runescape.com/m=itemdb_rs/bestiary/";
        private static readonly string BeastDataURL = BaseURL + "beastData.json?beastid=";
        private static readonly string BeastNameSearchURL = BaseURL + "beastSearch.json?term=";
        private static readonly string BeastLetterSearchURL = BaseURL + "bestiaryNames.json?letter=";
        private static readonly string BeastAreaSearchURL = BaseURL + "areaBeasts.json?identifier=";
        private static readonly string BeastCategorySearchURL = BaseURL + "slayerBeasts.json?identifier=";
        private static readonly string BeastWeaknessSearchURL = BaseURL + "weaknessBeasts.json?identifier=";
        private static readonly string BeastLevelsSearchURL = BaseURL + "levelGroup.json?identifier=";
        private static readonly string CatNamesURL = BaseURL + "slayerCatNames.json";
        private static readonly string AreaNamesURL = BaseURL + "areaNames.json";
        private static readonly string WeaknessNamesURL = BaseURL + "weaknessNames.json";

        public static BeastData GetBeastData(int BeastID)
        {
            return Utils.GetJson<BeastData>(BeastDataURL + BeastID);
        }

        public static BeastSearchResult[] SearchBeastiaryByName(params string[] terms)
        {
            string Term = terms[0];
            foreach (string term in terms)
            {
                Term += "+" + term;
            }

            return Utils.GetJson<BeastSearchResult[]>(BeastNameSearchURL + Term);
        }

        public static BeastSearchResult[] SearchBeastiaryByFirstLetter(char Letter)
        {
            return Utils.GetJson<BeastSearchResult[]>(BeastLetterSearchURL + Letter);
        }

        public static BeastSearchResult[] SearchBeastiaryByArea(string Area)
        {
            return Utils.GetJson<BeastSearchResult[]>(BeastAreaSearchURL + Area);
        }

        public static BeastSearchResult[] SearchBeastiaryByCategory(int CategoryID)
        {
            return Utils.GetJson<BeastSearchResult[]>(BeastCategorySearchURL + CategoryID);
        }

        public static BeastSearchResult[] SearchBeastiaryByWeakness(int WeaknessID)
        {
            return Utils.GetJson<BeastSearchResult[]>(BeastWeaknessSearchURL + WeaknessID);
        }

        public static BeastSearchResult[] SearchBeastiaryBetweenLevels(int Lower, int Higher)
        {
            return Utils.GetJson<BeastSearchResult[]>(BeastLevelsSearchURL + Lower + "-" + Higher);
        }

        public static Dictionary<string, int> GetSlayerCategoryNames()
        {
            return Utils.GetJson<Dictionary<string, int>>(CatNamesURL);
        }

        public static string[] GetAreaNames()
        {
            return Utils.GetJson<string[]>(AreaNamesURL);
        }

        public static Dictionary<string, int> GetWeaknessNames()
        {
            return Utils.GetJson<Dictionary<string, int>>(WeaknessNamesURL);
        }
    }

    public class BeastData
    {
        public string Name;
        public int ID;
        public bool Members;
        public string Weakness;
        public int Level;
        public int LifePoints;
        public int Defence;
        public int Attack;
        public int Magic;
        public int Ranged;
        public string XP;
        public int SlayerLevel;
        public string SlayerCat;
        public int Size;
        public bool Attackable;
        public bool Aggressive;
        public bool Poisonous;
        public string Description;
        public List<string> Area;
        public Dictionary<string, int> Animations;
    }

    public class BeastSearchResult
    {
        public int Value;
        public string Label;
    }
}