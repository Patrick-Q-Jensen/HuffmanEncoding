using HuffmanEncoding;

namespace TestSuite
{
    [TestClass]
    public class CommandLineArgumentTests
    {
        [TestMethod]
        public void ArgumentsTest1()
        {
            string[] args = { "invalidValue", "SomeFile.txt" };
            CommandLineArguments? result = CommandLineArgumentParser.ParseArguments(args);
            Assert.IsNull(result);
        }

    }


}
