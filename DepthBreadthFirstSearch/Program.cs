using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepthBreadthFirstSearch
{
    static class Program
    {
        public class classGraph
        {
            private readonly int V;
            //adjacency List
            private readonly List<int>[] Adj;
            public classGraph(int vertices)
            {
                V = vertices;
                Adj = new List<int>[V];
                for (int i = 0; i < V; i++)
                {
                    Adj[i] = new List<int>();
                }
            }
            public void AddEdge(int v, int w)
            {
                Adj[v].Add(w);
                // Adj[w].Add(v);
            }
            public void PrintAdjacencyMatrix()
            {
                for (int i = 0; i < V; i++)
                {
                    Console.Write(i + " :[");
                    string s = " ";
                    foreach (var k in Adj[i])
                    {
                        s = s + (k + ",");
                    }
                    s = s.Substring(0, s.Length - 1);
                    s = s + "]";
                    Console.Write(s);
                    Console.WriteLine();
                }
            }
            public List<int> GetAdjList(int m)
            {
                return Adj[m];
            }

            public int VertexCount
            {
                get
                {
                    return V;
                }
            }
            public void DepthFirstSearch(int v)
            {
                bool[] visited = new bool[V];
                //for DFS use stact
                Stack<int> stack = new Stack<int>();
                visited[v] = true;
                stack.Push(v);
                while (stack.Count != 0)
                {
                    v = stack.Pop();
                    Console.WriteLine(" next-> " + v);
                    foreach (int i in Adj[v])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            stack.Push(i);
                        }
                    }
                }
            }
            public void BreadthFirstSearch(int v)
            {
                bool[] visited = new bool[V];
                //Create queue for BFS
                Queue<int> queue = new Queue<int>();
                visited[v] = true;
                queue.Enqueue(v);

                //Loop throght all nodes in queue
                while (queue.Count != 0)
                {
                    //deque a vertex from queue and print it.
                    v = queue.Dequeue();
                    Console.WriteLine(" next->" + v);
                    //GEt all adjacency vertuces of s
                    foreach (Int32 next in Adj[v])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }
                }


            }
        }
        [STAThread]
        static void Main()
        {
            classGraph graph = new classGraph(7);
            int iStart = 3;
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 0);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 6);
            graph.AddEdge(5, 1);
            graph.AddEdge(6, 5);

/*            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);*/

            //print adjacency matrix
            graph.PrintAdjacencyMatrix();

            Console.WriteLine("DFS traversal starting from vertex "+ iStart + ":");
            graph.DepthFirstSearch(iStart);
            Console.WriteLine("BFS traversal starting from vertex " + iStart + ":");
            graph.BreadthFirstSearch(iStart);
            }
        }
}
