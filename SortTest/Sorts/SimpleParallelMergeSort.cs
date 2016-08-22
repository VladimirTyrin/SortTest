using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortTest.Sorts
{
    internal class SimpleParallelMergeSort : MergeSort
    {
        #region ISort

        #endregion

        #region private

        protected override void RunRecursivePart(int left, int middle, int right)
        {
            Parallel.Invoke(
                () => InnerMergeSort(left, middle),
                () => InnerMergeSort(middle, right)
            );
        }

        #endregion
    }
}

