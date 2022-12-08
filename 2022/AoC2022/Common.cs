using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    public static class Common
    {
        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IList<T>> source)
        {
            var enumerators = source.Map(t => t.GetEnumerator()).Filter(e => e.MoveNext());

            while (enumerators.Any())
            {
                yield return enumerators.Map(e => e.Current);
                enumerators = enumerators.Filter(e => e.MoveNext());
            }
        }

        public static IEnumerable<T> Duplicates<T>(this IEnumerable<T> source)
        {
            return source
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);
        }

        public static IEnumerable<T> Pop<T>(this IList<T> source, int n = 1)
        {
            while (n > 0)
            {
                T value = source.Last();
                source.RemoveAt(source.Count - 1);
                yield return value;
                n--;
            }
        }

        public static void Push<T>(this IList<T> source, IEnumerable<T> values)
        {
            foreach (T value in values) source.Add(value);
        }
    }
}
