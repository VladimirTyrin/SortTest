using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SortTest.Sorts;

namespace SortTest.Utils
{
    internal static class AlgorithmRunner
    {
        public static void RunSort(ISort sort, List<int> data, int repeatCount = 100, bool outputData = false)
        {
            var name = sort.GetType().Name;
            Console.WriteLine($"Starting {name}");
            if (outputData)
                Console.WriteLine(string.Join(" ", data.Select(i => i.ToString())));
            long totalTime = 0;
            for (var i = 0; i < repeatCount; ++i)
            {
                sort.Prepare(data);
                var stopWatch = Stopwatch.StartNew();
                sort.Run();
                stopWatch.Stop();
                totalTime += stopWatch.ElapsedTicks;
            }
            
            Console.WriteLine($"Finished {name} in {(double)totalTime * 1000 / (Stopwatch.Frequency * repeatCount)}ms avg");
            if (outputData)
                sort.ReportResults();
            Console.WriteLine("-------------------------------------------");
        }
    }
}
