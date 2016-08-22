using System;
using System.Collections.Generic;
using System.Linq;

namespace SortTest.Sorts
{
    internal class InsertionSort : AbstractSort
    {
        #region ISort
        public override void Prepare(List<int> data)
        {
            Data = new List<int>(data);
            Size = data.Count;
        }

        public override void Run()
        {
            for (var i = 1; i < Size - 1; ++i)
            {
                var current = Data[i];
                var j = i - 1;
                while (j >= 0 && Data[j] > current)
                {
                    Data[j + 1] = Data[j];
                    j--;
                }
                Data[j + 1] = current;
            }
        }
        #endregion
    }
}
