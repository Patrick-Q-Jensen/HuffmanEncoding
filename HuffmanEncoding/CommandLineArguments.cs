using CommandLine;

namespace HuffmanEncoding;
public class CommandLineArguments
{
    [Option('i', "input", Required = true, HelpText = "The complete path to the file that should be encoded")]
    public string InputFile { get; set; } = "";

    [Option('o', "output", Required = true, HelpText = "The file that the encoded content should be written to")]
    public string OutputFile { get; set; } = "";

    [Option('d', "decode", Required = false, Default = false, HelpText = "Indicates that the target input file should be decoded")]
    public bool Decode { get; set; }
}
