namespace HuffmanEncoding;

public class LeafNode : INode
{
    private readonly char _element;
    private readonly int _weight;

    public LeafNode(char element, int weight)
    {
        _element = element;
        _weight = weight;
    }

    public char Value => _element;

    public bool IsLeaf() {
        return true;
    }

    public int Weight() {
        return _weight;
    }
}
