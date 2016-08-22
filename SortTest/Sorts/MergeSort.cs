using System;
using System.Collections.Generic;
using System.Linq;

namespace SortTest.Sorts
{
    internal class MergeSort : AbstractSort
    {
        #region ISort
        public override void Prepare(List<int> data)
        {
            Data = new List<int>(data);
            Size = data.Count;
            Buffer = new List<int>(Data);
        }

        public override void Run() => InnerMergeSort(0, Size);

        public override void ReportResults() => Console.WriteLine(string.Join(" ", Data.Select(i => i.ToString())));

        #endregion

        #region private

        protected void InnerMergeSort(int left, int right)
        {
            if (right - left + 1 < Threshold)
            {
                InnerBubbleSort(left, right);
                return;
            }

            var middle = (left + right)/2;
            RunRecursivePart(left, middle, right);
            Merge(left, middle, right);
        }

        protected virtual void RunRecursivePart(int left, int middle, int right)
        {
            InnerMergeSort(left, middle);
            InnerMergeSort(middle, right);
        }

        protected void Merge(int left, int middle, int right)
        {
            var leftIndex = left;
            var rightIndex = middle;
            var size = right - left;
            for (var i = 0; i < size; ++i)
            {
                if (leftIndex < middle && rightIndex < right)
                {
                    if (Data[leftIndex] < Data[rightIndex])
                    {
                        Buffer[i + left] = Data[leftIndex];
                        leftIndex++;
                    }
                    else
                    {
                        Buffer[i + left] = Data[rightIndex];
                        rightIndex++;
                    }
                }
                else if (leftIndex < middle)
                {
                    Buffer[i + left] = Data[leftIndex];
                    leftIndex++;
                }
                else
                {
                    Buffer[i + left] = Data[rightIndex];
                    rightIndex++;
                }
            }

            for (var i = left; i < right; ++i)
                Data[i] = Buffer[i];
        }

        protected void InnerBubbleSort(int left, int right)
        {
            var size = right - left;

            for (var i = 0; i < size - 1; ++i)
            {
                var swapped = false;
                for (var j = 0; j < size - i - 1; ++j)
                {
                    if (Data[j + left] > Data[j + 1 + left])
                    {
                        var tmp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = tmp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }

        protected const int Threshold = 20;
        protected List<int> Buffer;
        #endregion
    }
}
