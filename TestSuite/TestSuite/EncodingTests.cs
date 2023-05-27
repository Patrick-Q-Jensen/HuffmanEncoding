using HuffmanEncoding;
using System.Text;

namespace TestSuite;

[TestClass]
public class EncodingTests
{
    [TestMethod]
    public void EncodingTest1()
    {
        string testText = "AABCBAD";

        Dictionary<char, int> frequencies = FrequencyCounter.CountFrequencies(testText);

        Tree t = TreeConstructor.BuildTree(frequencies);

        Dictionary<char, byte[]> characterCodes = PrefixCodeGenerator.GenerateCharacterPrefixCodes(t);

        //A: 0
        //B: 10
        //C: 110
        //D: 111

        byte[] encodedText = HuffmanEncoder.EncodeBytes(testText, characterCodes);

        File.WriteAllBytes("testfile", encodedText);

        string decodedContent = HuffmanEncoder.DecodeFile("testFile");

        Assert.AreEqual(testText, decodedContent);
    }

}
