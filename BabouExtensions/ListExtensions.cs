using System;
using System.Collections.Generic;
using System.Threading;

namespace BabouExtensions
{
    /// <summary>
    /// Extensions for Lists
    /// </summary>
    public static class ListExtensions
    {
        private static class ThreadSafeRandom
        {
            [ThreadStatic] private static Random Local;

            public static Random ThisThreadsRandom => Local ??= new Random(unchecked(Environment.TickCount * 31 + Thread
                                                                                         .CurrentThread.ManagedThreadId));
        }

        /// <summary>
        /// Shuffles a list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Allows you to easily add values to an ICollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="list"></param>
        /// <param name="values"></param>
        public static void AddRange<T, S>(this ICollection<T> list, params S[] values)
            where S : T
        {
            foreach (S value in values)
                list.Add(value);
        }
    }
}