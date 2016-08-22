using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest.Sorts
{
    internal class TaskParallelMergeSort : MergeSort
    {
        #region ISort

        #endregion

        #region private

        protected override void RunRecursivePart(int left, int middle, int right)
        {
            if (right - left < ParallelThreshold)
            {
                InnerMergeSort(left, middle);
                InnerMergeSort(middle, right);
                return;
            }
            Task.WhenAll(
                Task.Run(() => InnerMergeSort(left, middle)),
                Task.Run(() => InnerMergeSort(middle, right))
            ).Wait();
        }

        protected const int ParallelThreshold = 10000;
        #endregion
    }
}
