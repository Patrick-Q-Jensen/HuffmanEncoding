namespace HuffmanEncoding;

public class Tree : IComparable<Tree>
{
    private readonly INode _root;

    public INode Root => _root;

    public Tree(char element, int weight)
    {
        _root = new LeafNode(element, weight);
    }

    public Tree(INode left, INode right, int weight)
    {
        _root = new InternalNode(left, right, weight);
    }

    public int Weight => _root.Weight();

    public int CompareTo(Tree? other)
    {
        if (other == null) return -1;
        if (_root.Weight() < other.Weight) return -1;
        else if (Root.Weight() == other.Weight) return 0;
        else return 1;
    }
}
