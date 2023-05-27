namespace HuffmanEncoding;

internal class Program
{
    static void Main(string[] args)
    {
        CommandLineArguments? arguments = CommandLineArgumentParser.ParseArguments(args);
        if (arguments == null) {
            return;
        }

        if (arguments.Decode == true) {
            string decodedContent = HuffmanEncoder.DecodeFile(arguments.InputFile);

            File.WriteAllText(arguments.OutputFile, decodedContent);
            return;
        }

        EncodeInputFile(arguments);
    }

    private static void EncodeInputFile(CommandLineArguments arguments)
    {
        string content = File.ReadAllText(arguments.InputFile);

        Dictionary<char, int> characterFrequencies = FrequencyCounter.CountFrequencies(content);

        Tree tree = TreeConstructor.BuildTree(characterFrequencies);

        Dictionary<char, byte[]> characterCodes = PrefixCodeGenerator.GenerateCharacterPrefixCodes(tree);

        byte[] encodedBytes = HuffmanEncoder.EncodeBytes(content, characterCodes);

        File.WriteAllBytes(arguments.OutputFile, encodedBytes);
    }
}