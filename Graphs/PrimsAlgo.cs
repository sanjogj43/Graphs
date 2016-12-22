using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public static class GlobalVar
    {
        public static int MAX = 100000;
    }

    public class Vertex
    {
        public char key;
        public int cost;
        public Vertex parent;
        public Vertex(char pKey)
        {
            key = pKey;        
        }
    }

    public class HalfEdge
    {
        Vertex v2;
        int edgeCost;

        public HalfEdge(Vertex v, int pCost)
        {
            v2 = v;
            edgeCost = pCost;
        }
    }

    public class Graph
    {
        PriorityQueue pQueue = new PriorityQueue();
        Dictionary<char, Vertex> vertexMap = new Dictionary<char, Vertex>();
        List<Vertex> vertexPqueue = new List<Vertex>(); 
        Dictionary<char, Dictionary<char, HalfEdge>> AdjList = new Dictionary<char, Dictionary<char,HalfEdge>>();

        public Graph()
        { 
        }

        public bool ConstructPQueue()
        {
            foreach (Vertex v in vertexPqueue)
            {
                v.cost = GlobalVar.MAX;
            }
            if (vertexPqueue.Count > 0)
            {
                vertexPqueue[0].cost = 0;
                pQueue.BuildMinHeap(vertexPqueue);
                return true;
            }
            return false;
        }

        public bool AddEdge(char v1Key, char v2Key, int cost)
        {
            Vertex v1 = vertexMap.ContainsKey(v1Key) ? vertexMap[v1Key] : null;
            Vertex v2 = vertexMap.ContainsKey(v2Key) ? vertexMap[v2Key] : null;
            if (v1 != null && v2 != null)
            {
                HalfEdge h1 = new HalfEdge(v2, cost);
                HalfEdge h2 = new HalfEdge(v1, cost);
                if (!AdjList.ContainsKey(v1.key))
                {
                    var dict = new Dictionary<char, HalfEdge>();
                    dict.Add(v2Key, h2);
                    AdjList.Add(v1Key, dict);
                }
                else 
                {
                    var dict = AdjList[v1.key];
                    dict.Add(v2Key,h2);
                }

                if (!AdjList.ContainsKey(v2.key))
                {
                    var dict = new Dictionary<char, HalfEdge>();
                    dict.Add(v1Key, h1);
                    AdjList.Add(v2Key, dict);
                }
                else
                {
                    var dict = AdjList[v1.key];
                    dict.Add(v1Key, h1);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddNode(char key)
        {
            if (!vertexMap.ContainsKey(key))
            {
                Vertex v = new Vertex(key);
                vertexMap.Add(key,v);
                vertexPqueue.Add(v);
            }
        }
    }
    public class Prim
    {
        
    }
}
