using System.Collections.Generic;

//#tag:graph traversal,clone,dfs
public class Solution
{
    class NodeFactory
    {
        private static List<Node> nodes = new List<Node>();
        public static Node GetNode(int val)
        {
            if (nodes.Count >= val)
            {
                return nodes[val - 1];
            }

            for (int i = nodes.Count; i <= val; i++)
            {
                nodes.Add(new Node(i+1));
            }
            return nodes[val - 1];
        }
    }


    public Node CloneGraph(Node node)
    {
        if (node == null)
        {
            return null;
        }

        Node cloneNode = NodeFactory.GetNode(node.val);
        HashSet<Node> deepCopied = new HashSet<Node> { node };
        CloneNeighbors(node, cloneNode, deepCopied);
        return cloneNode;
    }


    private void CloneNeighbors(Node fromNode, Node toNode, HashSet<Node> deepCopied)
    {
        if (fromNode.neighbors != null)
        {
            toNode.neighbors = new List<Node>();
            foreach (var nei in fromNode.neighbors)
            {
                var cloneNei = NodeFactory.GetNode(nei.val);
                toNode.neighbors.Add(cloneNei);
                if (!deepCopied.Contains(nei))
                {
                    deepCopied.Add(nei);
                    CloneNeighbors(nei, cloneNei, deepCopied);
                }
            }
        }
    }
}
