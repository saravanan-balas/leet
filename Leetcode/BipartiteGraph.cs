namespace Leetcode;

public class BipartiteGraph
{
    public static void Do()
    {
        int[][] graph = new int[][]
        {
            //[1,2,3],[0,2],[0,1,3],[0,2]
            [1,3],[0,2],[1,3],[0,2]
        };
        
        Console.WriteLine(new BipartiteGraph().IsBipartite(graph));
    }

    public bool IsBipartite(int[][] graph)
    {
        int[] color = new int[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (color[i] == 0)
            {
                color[i] = 1;
                if (!Dfs(graph, color, i)) return false;
            }
        }

        return true;
    }

    private bool Dfs(int[][] graph, int[] color, int v)
    {
        Console.WriteLine("Recursion start : " + v);
        int currentColor = color[v];
        foreach (int w in graph[v])
        {
            Console.WriteLine("w " + w);
            if (color[w] == currentColor) return false;
            if (color[w] == 0)
            {
                color[w] = -currentColor;
                if (!Dfs(graph, color, w)) return false;
            }

            Console.WriteLine(string.Join(" , ", color));
        }

        return true;
    }
}