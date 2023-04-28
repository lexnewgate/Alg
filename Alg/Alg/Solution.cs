
public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        
        int []indegree = new int[n];
        foreach (var edge in edges)
        {
            indegree[edge[1]]++;
        }

        var ret = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
            {
                ret.Add(i);
            }
        }

        return ret;
    }
}