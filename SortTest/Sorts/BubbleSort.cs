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
            _data = new List<int>(data);
            _size = data.Count;
        }

        public override void Run()
        {
            for (var i = 0; i < _size - 1; ++i)
            {
                var swapped = false;
                for (var j = 0; j < _size - i - 1; ++j)
                {
                    if (_data[j] > _data[j + 1])
                    {
                        var tmp = _data[j];
                        _data[j] = _data[j + 1];
                        _data[j + 1] = tmp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }
        #endregion

        #region private

        private List<int> _data;
        private int _size;

        #endregion
    }
}
