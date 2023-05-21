namespace HuffmanEncoding;

public class InternalNode : INode
{
    private readonly int _weight;
    private readonly INode _left;
    private readonly INode _right;

    public InternalNode(INode left, INode right, int weight)
    {
        _left = left;
        _right = right;
        _weight = weight;
    }

    public INode Left => _left;
    public INode Right => _right;

    public bool IsLeaf()
    {
        return false;
    }

    public int Weight()
    {
        return _weight;
    }
}
