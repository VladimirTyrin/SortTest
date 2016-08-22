using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest.Sorts
{
    internal abstract class AbstractSort : ISort
    {
        #region ISort

        public virtual string Name { get; } = null;
        public abstract void Prepare(List<int> data);
        public abstract void Run();
        public virtual void ReportResults() => Console.WriteLine(string.Join(" ", Data.Select(i => i.ToString())));
        #endregion

        #region protected
        protected List<int> Data;
        protected int Size;
        #endregion
    }
}
