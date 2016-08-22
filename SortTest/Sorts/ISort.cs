using System.Collections.Generic;

namespace SortTest.Sorts
{
    internal interface ISort
    {
        void Prepare(List<int> data);
        void Run();
        void ReportResults();
    }
}
