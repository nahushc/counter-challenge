using System.Text.RegularExpressions;

namespace CounterChallenge.Service.UniqueCharacterParser
{
    public class RegexUniqueCharacterParserService : IUniqueCharacterParserService
    {
        // The split pattern uses anything besides one of the 26 letters of the English alphabet as one of the delimiters. 
        // The parentheses ensure that the delimiters are still included in the split string. 
        public const string _splitPattern = @"([^a-zA-Z])";
        public RegexUniqueCharacterParserService()
        {

        }

        public string Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            // The variable words contains the split input string. 
            var words = Regex.Split(input, _splitPattern).ToList();

            if (words == null || !words.Any())
            {
                return "";
            }

            // Remove all instances of empty ("") strings. 
            words.RemoveAll(word => word == string.Empty);

            var parsedValue = string.Empty;

            foreach(var word in words)
            {
                if (Regex.IsMatch(word, _splitPattern))
                {
                    // If the current word is a non-alphabetic character then include it as is. 
                    parsedValue += word; 
                }
                else
                {
                    if (word.Length > 1)
                    {
                        var firstLetter = word[0].ToString();
                        var lastLetter = word[word.Length - 1].ToString();
                        var characterLookup = new HashSet<char>();

                        for (int currentLetterIndex = 1; currentLetterIndex < word.Length - 1; currentLetterIndex++)
                        {
                            if (!characterLookup.Contains(word[currentLetterIndex]))
                            {
                                characterLookup.Add(word[currentLetterIndex]);
                            }
                        }

                        parsedValue += firstLetter + characterLookup.Count() + lastLetter;
                    }
                    else
                    {
                        parsedValue += word;
                    }
                }
            }

            return parsedValue;
        }

    }
}