namespace HuffmanEncoding;

public static class PrefixCodeGenerator
{
    public static List<CharacterCode> GenerateCharacterPrefixCodes(Tree t)
    {
        List<CharacterCode> code = new();
        Traverse(new List<byte>(), t.Root, code);
        return code;
    }

    private static void Traverse(List<byte> code, INode node, List<CharacterCode> characterCodes)
    {
        if (node.IsLeaf())
        {
            characterCodes.Add(new CharacterCode(((LeafNode)node).Value, node.Weight(), code.ToArray()));                
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
