using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest.Sorts
{
    internal class BubbleSort : AbstractSort
    {
        #region ISort
        public override void Prepare(List<int> data)
        {
            Data = new List<int>(data);
            Size = data.Count;
        }

        public override void Run()
        {
            for (var i = 0; i < Size - 1; ++i)
            {
                var swapped = false;
                for (var j = 0; j < Size - i - 1; ++j)
                {
                    if (Data[j] > Data[j + 1])
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
        #endregion
    }
}
