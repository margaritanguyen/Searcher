using System.Collections.Generic;
using System.Linq;

namespace Searcher
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] arr, int size)
        {
            return arr.Select((s, i) => arr.Skip(i * size).Take(size)).Where(a => a.Any());
        }
    }
}
