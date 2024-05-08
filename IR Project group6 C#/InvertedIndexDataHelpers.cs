using System.Text;
using System.Text.RegularExpressions;

internal static class InvertedIndexDataHelpers
{

    private static char EncodeChar(char c)
    {
        switch (c)
        {
            case 'B': case 'F': case 'P': case 'V': return '1';
            case 'C': case 'G': case 'J': case 'K': case 'Q': case 'S': case 'X': case 'Z': return '2';
            case 'D': case 'T': return '3';
            case 'L': return '4';
            case 'M': case 'N': return '5';
            case 'R': return '6';
            default: return '0';
        }
    }

    private static string GenerateSoundex(string token)
    {
        if (string.IsNullOrEmpty(token)) return "0000";
        string upperToken = token.ToUpper();
        string filteredToken = Regex.Replace(upperToken, "[^A-Z]", "");
        if (string.IsNullOrEmpty(filteredToken)) return "0000";

        char firstLetter = filteredToken[0];
        StringBuilder soundexCode = new StringBuilder().Append(firstLetter);

        string remaining = filteredToken.Substring(1).Replace("A", "").Replace("E", "").Replace("I", "")
            .Replace("O", "").Replace("U", "").Replace("Y", "").Replace("H", "").Replace("W", "");

        foreach (char c in remaining)
        {
            if (soundexCode.Length >= 4) break;
            char encodedChar = EncodeChar(c);
            if (encodedChar != soundexCode[^1])
                soundexCode.Append(encodedChar);
        }

        return soundexCode.ToString().PadRight(4, '0');
    }
}