using CommandLine;

namespace HuffmanEncoding;
public static class CommandLineArgumentParser
{
    public static CommandLineArguments? ParseArguments(string[] args)
    {
       ParserResult<CommandLineArguments> result = Parser.Default.ParseArguments<CommandLineArguments>(args);

        if (result.Errors.Any())
        {
            Console.WriteLine("Error(s) occurred while attempting to parse commandline arguments:");

            foreach (Error error in result.Errors)
            {
                Console.WriteLine(error.Tag);
            }
            return null;
        }

        if (File.Exists(result.Value.InputFile) == false)
        {
            Console.WriteLine("Invalid input file value, file could not be found");
            return null;
        }

        if (string.IsNullOrWhiteSpace(result.Value.OutputFile))
        {
            Console.WriteLine("Invalid output file vlaue, cannot be empty");
            return null;
        }

        return result.Value;
    }
}
