namespace HuffmanEncoding;

internal class Program
{

    static void Main(string[] args)
    {
        CommandLineArguments? arguments = CommandLineArgumentParser.ParseArguments(args);
        if (arguments == null) {
            return;
        }
        
        string content = File.ReadAllText(arguments.InputFile);

        Dictionary<char, int> characterFrequencies = FrequencyCounter.CountFrequencies(content);

        Tree tree = TreeConstructor.BuildTree(characterFrequencies);    

        List<CharacterCode> characterCodes = PrefixCodeGenerator.GenerateCharacterPrefixCodes(tree);
    
    }
}