using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal class EqulityComparerRealizate : IEqualityComparer<IEnumerable<int>>
    {
        public bool Equals(IEnumerable<int>? x, IEnumerable<int>? y)
        {
            for (int i = 0; i < x!.Count(); i++)
            {
                for (int j = i + 1; j < x!.Count(); j++)
                {
                    if (x!.ElementAt(i) == x!.ElementAt(j)) return true;
                }
            }
            return false;
        }

        public int GetHashCode([DisallowNull] IEnumerable<int> obj)
        {
            return obj.GetHashCode();
        }
    }
}
