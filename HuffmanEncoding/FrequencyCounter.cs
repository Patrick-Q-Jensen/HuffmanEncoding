namespace HuffmanEncoding;

public static class FrequencyCounter{
    public static Dictionary<char, int> CountFrequencies(string text)
    {     
        Dictionary<char, int> dict = new();
        foreach (char character in text)
        {
            if (dict.ContainsKey(character))
            {
                dict[character] = dict[character] + 1;
                continue;
            }

            dict.Add(character, 1);
        }

        return dict;
    }
}
