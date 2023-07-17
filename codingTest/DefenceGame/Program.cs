using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var result0 = Solution(7, 3, new int[]{4, 2, 4, 5, 3, 3, 1}); //5
        Console.WriteLine(result0);

        var result1 = Solution(2, 4, new int[]{3, 3, 3, 3}); //4
        Console.WriteLine(result1);
    }

    static int Solution(int n, int k, int[] enemy)
    {

        int result = enemy.Length;
        
        //무적권으로 모든 적 방어 가능.
        if(k >= enemy.Length) return result;
        
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(new HeapComparer<int>());

        for(int i = 0; i < enemy.Length; ++i) {
            minHeap.Enqueue(enemy[i], enemy[i]);

            int round = i + 1;
            if(k > i) {
                result = round;
            }
        }

        return 0;
    }
}

public class HeapComparer<T> : IComparer<T>
{
    public int Compare(T x, T y)
    {
        return Comparer<T>.Default.Compare(x, y);
    }
}