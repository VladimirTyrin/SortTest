using System;
using System.Collections.Generic;
using System.Threading;
using SortTest.Sorts;
using SortTest.Utils;

namespace SortTest
{
    internal class Program
    {
        private static readonly List<ISort> Sorts = new List<ISort>
        {
            new BubbleSort(),
            new InsertionSort(),
            new MergeSort(),
            new SimpleParallelMergeSort(),
            new AdaptiveParallelMergeSort(),
            new TaskParallelMergeSort()
        };
        private static readonly int[] Sizes =
        {
            10,
            100,
            1000,
            1000 * 10,
            1000 * 100,
            1000 * 1000,
            1000 * 1000 * 10,
            // 1000 * 1000 * 100
        };
        private static void Main(string[] args)
        {
            var threadCount = Environment.ProcessorCount;
            ThreadPool.SetMinThreads(threadCount, threadCount);
            ThreadPool.SetMaxThreads(threadCount, threadCount);
            foreach (var size in Sizes)
            {
                RunAllSorts(size);
            }
        }

        private static void RunAllSorts(int listSize)
        {
            Console.WriteLine($"Sorting {listSize} elements");
            Console.WriteLine();
            foreach (var sort in Sorts)
            {
                var random = new Random();
                var dataForSort = new List<int>();
                for (var i = 0; i < listSize; ++i)
                    dataForSort.Add(random.Next(1, 1000));

                AlgorithmRunner.RunSort(sort, dataForSort, outputData: false);
            }
            Console.WriteLine("===============================================");
        }
    }
}
