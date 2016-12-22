using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Heap
    {
        public int[] A;

        public void Swap(int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
        public void BuildMaxHeap()
        {
            int len = A.Count();
            for (int i = len / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(i, len);
            }
        }

        public void MaxHeapify(int i, int arrLen)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int largest;
            if (l < arrLen && A[l] > A[i])
            {
                largest = l;
            }
            else 
            {
                largest = i;
            }
            if (r < arrLen && A[r] > A[largest])
            {
                largest = r;    
            }

            if (largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest, arrLen);
            }
        }

        public void HeapSort()
        {
            int len = A.Count();
            for (int i = 0; i < len; i++)
            {
                Swap(0, len - i - 1);
                MaxHeapify(0, len-i-1);
            }
        }
    }

    public class PriorityQueue 
    {
        //List<Vertex> A;

        // If want to use c# quivalent of vectors use List<T>

         public void Swap(List<Vertex> A,int i, int j)
        {
            Vertex temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
         public void BuildMinHeap(List<Vertex> A)
        {
            int len = A.Count();
            for (int i = len / 2 - 1; i >= 0; i--)
            {
                MinHeapify(A,i, len);
            }
        }

        public void MinHeapify(List<Vertex> A, int inputIndex, int arrLen)
        {
            int leftIndex = 2 * inputIndex + 1;
            int rightIndex = 2 * inputIndex + 2;
            int smallestIndex;
            if (leftIndex < arrLen && A[leftIndex].cost < A[inputIndex].cost)
            {
                smallestIndex = leftIndex;
            }
            else 
            {
                smallestIndex = inputIndex;
            }
            if (rightIndex < arrLen && A[rightIndex].cost < A[smallestIndex].cost)
            {
                smallestIndex = rightIndex;    
            }

            if (smallestIndex != inputIndex)
            {
                Swap(A,inputIndex, smallestIndex);
                MinHeapify(A,smallestIndex, arrLen);
            }
        }


        public Vertex HeapMin(List<Vertex> A)
        { 
            return A[0];
        }

        public int parent(int inputIndex)
        {
            return (inputIndex - 1) / 2;
        }
        public void DecreaseKey(List<Vertex> A, int inputIndex, int inputKey)
        {
            if (inputKey > A[inputIndex].cost)
            {
                // error
            }
            else 
            {
                int parentIndex = parent(inputIndex);
                A[inputIndex].cost = inputKey;
                int upwardTravIndex = inputIndex;
                while (upwardTravIndex > 0 && A[parentIndex].cost > A[inputIndex].cost)
                {
                    Swap(A,inputIndex, parentIndex);
                    upwardTravIndex = parentIndex;
                    parentIndex = parent(upwardTravIndex);
                }
            }
        }

        public Vertex  ExtractMin(List<Vertex> A)
        {
            if (A.Count < 1)
            {
                // error
                return null;
            }
            else
            {
                Vertex min = A[0];
                int cnt = A.Count;
                Swap(A,0,  cnt - 1);
                A.RemoveAt(cnt - 1);
                MinHeapify(A,0, cnt-1);

                return min;
            }
        }
    }
    public class program {
        public static void Main1()
        {
            Heap h = new Heap();
            h.A = new int []{8,7,6,5,4,3,2,1};
            h.BuildMaxHeap();
            h.HeapSort();
            Console.WriteLine(h.A);
            Console.Read();
        }
    }
}
