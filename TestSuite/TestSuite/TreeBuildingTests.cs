using HuffmanEncoding;

namespace TestSuite;

[TestClass]
public class TreeBuildingTests
{
    [TestMethod]
    public void BuildTreeTest1()
    {
        string testText = "AABCBAD";

        Dictionary<char, int> frequencies = FrequencyCounter.CountFrequencies(testText);        

        Tree t = TreeConstructor.BuildTree(frequencies);

        Assert.AreEqual(7, t.Weight);
        InternalNode n1 = (InternalNode)t.Root;
        LeafNode l1 = (LeafNode)n1.Left;

        Assert.AreEqual('A', l1.Value);
        Assert.AreEqual(3, l1.Weight());

        //PrefixCodeGenerator pcg = new();
        //List<CharacterCode> characterCodes = pcg.GenerateCharacterPrefixCodes(t);

    }

    [TestMethod]
    public void BuildTreeTest2()
    {
        Dictionary<char, int> frequencies = new()
        {
            { 'C', 32 },
            { 'D', 42 },
            { 'E', 120 },
            { 'K', 7 },
            { 'L', 42 },
            { 'M', 24 },
            { 'U', 37 },
            { 'Z', 2 }
        };
        
        Tree t = TreeConstructor.BuildTree(frequencies);
        Assert.AreEqual(306, t.Weight);

        InternalNode n1 = (InternalNode)t.Root;
        LeafNode l1 = (LeafNode)n1.Left;
        Assert.AreEqual(120, l1.Weight());
        Assert.AreEqual('E', l1.Value);
        
        InternalNode n2 = (InternalNode)n1.Right;
        Assert.AreEqual(186, n2.Weight());

        InternalNode n3 = (InternalNode)n2.Left;
        Assert.AreEqual(79, n3.Weight());

        LeafNode l2 = (LeafNode)n3.Left;
        Assert.AreEqual('U', l2.Value);
        Assert.AreEqual(37, l2.Weight());
         
        Dictionary<char, byte[]> characterCodes = PrefixCodeGenerator.GenerateCharacterPrefixCodes(t);
        
        CollectionAssert.AreEqual(new byte[] { 0 }, characterCodes['E']);
        CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 0 }, characterCodes['C']);
        CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1, 1 }, characterCodes['M']);
        CollectionAssert.AreEqual(new byte[] { 1,1,1,1,0,0 }, characterCodes['Z']);

    }        
}