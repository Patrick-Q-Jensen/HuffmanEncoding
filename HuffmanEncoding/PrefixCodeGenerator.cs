namespace HuffmanEncoding;

public static class PrefixCodeGenerator
{
    public static Dictionary<char, byte[]> GenerateCharacterPrefixCodes(Tree t)
    {       
        Dictionary<char, byte[]> characterCodes = new();
        Traverse(new List<byte>(), t.Root, characterCodes);
        return characterCodes;
    }

    private static void Traverse(List<byte> code, INode node, Dictionary<char, byte[]> characterCodes)
    {
        if (node.IsLeaf())
        {                           
            characterCodes.Add(((LeafNode)node).Value, code.ToArray());              
            return;
        }

        InternalNode internalNode = (InternalNode)node;

        if (internalNode.Left != null)
        {
            Traverse(new List<byte>(code) { 0 }, internalNode.Left, characterCodes);
        }

        if (internalNode.Right != null)
        {
            Traverse(new List<byte>(code) { 1 }, internalNode.Right, characterCodes);
        }           
    }
}
