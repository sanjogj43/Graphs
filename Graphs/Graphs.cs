using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class EdgeNode {
        public int dest;
        public EdgeNode next;
        public EdgeNode(int pDest)
        {
            dest = pDest;
        }
    }
    public class Graph {
        EdgeNode[] vertices;
        //Dictionary<char, AdjListNode> vertices;
        public Graph(int v)
        {
            vertices = new EdgeNode[v];
        }

        public void AddEdge(int src, int dest)
        { 
            // ************ Since this is undirected graph insert src and dest in adj lists of eachother *******
            
            // ************ Insert dest in adj list of src *****************************************************
            EdgeNode temp = vertices[src];
            if (temp == null)
            {
                // No edges inserted yet
                vertices[src] = new EdgeNode(dest);
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new EdgeNode(dest);
            }

            // ************ Insert src in adj list of dest *****************************************************
            temp = vertices[dest];
            if (temp == null)
            {
                // No edges inserted yet
                vertices[dest] = new EdgeNode(src);
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new EdgeNode(src);
            }
        }
    }
    class Graphs
    {
        static void Main1(string[] args)
        {
            Graph g = new Graph(5);
            g.AddEdge(0, 1);
            g.AddEdge(0, 4);
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);


            Dictionary<int, bool> test = new Dictionary<int, bool>();
            HashSet<int> test1 = new HashSet<int>();
            test1.Add(1);
            test1.Add(-2);
            test1.Add(-3);
            test1.Add(-4);

            test.Add(1, true);
            test.Add(-2, true);
            test.Add(-3, true);
            test.Add(-4, true);

            bool val;
            test.TryGetValue(1, out val);
           
                Console.WriteLine(test[-4]);

        }
    }
}
