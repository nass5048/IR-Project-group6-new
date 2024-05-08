using System.Text;
using System.Text.RegularExpressions;

namespace IR_Project_group6_C_
{
    internal class InvertedIndexData
    {
        public string token { get; set; }
        public Dictionary<string, int> locationFreqs { get; set; } = new Dictionary<string, int>();
        public string soundex { get; private set; }

        public InvertedIndexData(string token, string location)
        {
            this.token = token;
            AddLocation(location);
            this.soundex = GenerateSoundex(token);
        }

        public void AddLocation(string location)
        {
            if (locationFreqs.ContainsKey(location))
                locationFreqs[location]++;
            else
                locationFreqs.Add(location, 1);
        }

        public static string GenerateSoundex(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return "0000";
            string upperToken = token.ToUpper();
            StringBuilder soundexCode = new StringBuilder();
            soundexCode.Append(upperToken[0]);

            string encoded = new string(upperToken.Substring(1).Where(c => "BFPVCGJKQSXZDTLMNR".Contains(c)).ToArray());
            encoded = Regex.Replace(encoded, "[AEIOUYHW]", "");
            encoded = Regex.Replace(encoded, "[BFPV]+", "1");
            encoded = Regex.Replace(encoded, "[CGJKQSXZ]+", "2");
            encoded = Regex.Replace(encoded, "[DT]+", "3");
            encoded = Regex.Replace(encoded, "[L]+", "4");
            encoded = Regex.Replace(encoded, "[MN]+", "5");
            encoded = Regex.Replace(encoded, "[R]+", "6");

            soundexCode.Append(encoded);

            return soundexCode.ToString().Substring(0, Math.Min(4, soundexCode.Length)).PadRight(4, '0');
        }
    }
}
