using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest.Sorts
{
    internal class AdaptiveParallelMergeSort : MergeSort
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
            Parallel.Invoke(
                () => InnerMergeSort(left, middle),
                () => InnerMergeSort(middle, right)
            );
        }

        protected const int ParallelThreshold = 10000;

        #endregion
    }
}
