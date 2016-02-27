using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Lab4
{
    public static class EnumerableExtensions
    {
        public static int OddSum(this IEnumerable<int> source)
        {
            return source.Odd().Sum();
        }

        public static int EvenSum(this IEnumerable<int> source)
        {
            return source.Even().Sum();
        }

        public static IEnumerable<T> Even<T>(this IEnumerable<T> source)
        {
            return source.Where((value, index) => index % 2 == 0);
        }

        public static IEnumerable<T> Odd<T>(this IEnumerable<T> source)
        {
            return source.Where((value, index) => index % 2 == 1);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Odd().Merge(source.Even());
        }

        private static IEnumerable<T> Merge<T>(this IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            int i;

            for (i = 0; firstSequence != null && i < firstSequence.Count(); i++)
            {
                yield return firstSequence.ElementAt(i);

                if (secondSequence != null && i < secondSequence.Count())
                {
                    yield return secondSequence.ElementAt(i);
                }
            }

            foreach (var item in secondSequence.Where((v, index) => index > i))
            {
                yield return item;
            }
        }

        public static IEnumerable<T> DoSmth<T>(this IEnumerable<T> sourse, Action<T> action)
        {
            if (action != null)
            {
                foreach (var item in sourse)
                {
                    action(item);
                }
            }

            return sourse;
        } 
    }
}
