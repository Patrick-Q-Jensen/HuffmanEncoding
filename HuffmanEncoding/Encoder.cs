using System.Text;

namespace HuffmanEncoding;

public class HuffmanEncoder
{
    public static byte[] EncodeBytes(string text, Dictionary<char, byte[]> characterCodes)
    {
        StringBuilder sb = new();
        List<byte> encodedbytes = new();
        string codeHeader = string.Join(";", characterCodes.Select(x => Convert.ToInt16(x.Key) + "-" + string.Concat(x.Value))) + '!';

        encodedbytes.AddRange(codeHeader.Select(c => Convert.ToByte(c)));
        foreach (char c in text ) {
             sb.Append(string.Concat(characterCodes[c]));
        }
        string debug = sb.ToString();
        encodedbytes.AddRange(GetBytes(sb.ToString()));
        return encodedbytes.ToArray();
    }

    public static byte[] GetBytes(string bitString)
    {
        var t = bitString.Chunk(8);
        List<byte> bytes = new List<byte>();
        foreach (char[] item in t)
        {
            if (item.Length < 8)
            {
                foreach (char c in item)
                {
                    bytes.Add(c == '1' ? (byte) 1 : (byte) 0);
                }
                continue;
            }

            bytes.Add(Convert.ToByte(new string(item), 2));
        }
        return bytes.ToArray();
    }

    public static string Encode(string text, Dictionary<char, byte[]> characterCodes)
    {
        StringBuilder sb = new();
        sb.Append(string.Join(";", characterCodes.Select(x => x.Key + "=" + string.Concat(x.Value))) + "!");       
        foreach (char c in text)
        {            
            sb.Append(string.Concat(characterCodes[c]));
        }
        return sb.ToString();
    }

    public static string DecodeFile(string file)
    {
        using FileStream stream = new(file, FileMode.Open, FileAccess.Read);
        Dictionary<string, char> codeHeader = GetCodeHeader(stream);

        string encodedBits = GetEncodedBits(stream);
        return DecodeEncodedBits(encodedBits, codeHeader);        
    }

    private static string DecodeEncodedBits(string encodedBits, Dictionary<string, char> codeHeader)
    {
        StringBuilder sb = new();
        string code = "";
        foreach (char character in encodedBits)
        {
            code += character;
            if (codeHeader.ContainsKey(code) == false) continue;

            sb.Append(codeHeader[code]);
            code = "";
        }
        return sb.ToString();
    }

    private static string GetEncodedBits(FileStream stream)
    {
        StringBuilder sb = new();
        bool streamFinished = false;

        while (streamFinished == false)
        {
            int b = stream.ReadByte();
            if (b == -1)
            {
                streamFinished = true;
                continue;
            }
            if (b == 0 || b == 1)
            {
                sb.Append(b == 1 ? "1" : "0");
                continue;
            }
            string tesets = Convert.ToString(b, 2).PadLeft(8, '0');
            sb.Append(tesets);

        }
        return sb.ToString();
    }

    private static Dictionary<string, char> GetCodeHeader(FileStream stream)
    {
        string codeHeader = "";
        bool codeHeaderFinished = false;
        while (codeHeaderFinished == false)
        {
            int b = stream.ReadByte();
            if (b == -1)
            {
                Console.WriteLine("The code header termination character was not found in the given input file, please provide a valid file");
                Environment.Exit(-1);
            }

            char c = Convert.ToChar(b);

            if (c == '!')
            {
                codeHeaderFinished = true;
                continue;
            }

            codeHeader += c;
        }

        string[] characterCodeStrings = codeHeader.Split(';');

        Dictionary<string, char> characterCodes = new();

        foreach (string characterCode in characterCodeStrings)
        {
            string[] t = characterCode.Split('-');
            char c = Convert.ToChar(int.Parse(t[0]));
            string bits = t[1];
            characterCodes.Add(bits, c);
        }

        return characterCodes;
    }
}
