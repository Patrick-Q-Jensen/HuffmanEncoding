namespace HuffmanEncoding;

public static class TreeConstructor
{
    public static Tree BuildTree(Dictionary<char, int> frequencies)
    {          
        List<Tree> priorityQueue = new();

        foreach (var item in frequencies)
        {
            priorityQueue.Add(new Tree(item.Key, item.Value));
        }
        priorityQueue.Sort();         

        return ReduceTrees(priorityQueue);
    }

    private static Tree ReduceTrees(List<Tree> priorityQueue)
    {
        if (priorityQueue.Count == 1)
        {
            return priorityQueue.First();
        }

        Tree leftTree = GetFirstTree(priorityQueue);
        Tree rightTree = GetFirstTree(priorityQueue);

        Tree newTree = new(leftTree.Root, rightTree.Root, leftTree.Weight + rightTree.Weight);

        priorityQueue.Add(newTree);
        priorityQueue.Sort();

        return ReduceTrees(priorityQueue);
    }

    private static Tree GetFirstTree(List<Tree> PriorityQueue)
    {
        Tree tmp = PriorityQueue[0];
        PriorityQueue.RemoveAt(0);
        return tmp;
    }
}
