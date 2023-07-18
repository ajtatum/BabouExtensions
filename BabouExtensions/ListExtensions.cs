using System;
using System.Collections.Generic;
using System.Linq;
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
            [ThreadStatic] 
            private static Random _local;

            public static Random ThisThreadsRandom => _local ??= new Random(unchecked(Environment.TickCount * 31 + Thread
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

        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Grabs a random element from an Enumerable
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomElement<T>(this IList<T> enumerable)
            => enumerable.ElementAt(_random.Next(0, enumerable.Count));

        /// <summary>
        /// Grabs a random element from an Enumerable
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T RandomElement<T>(this ICollection<T> enumerable)
            => enumerable.ElementAt(_random.Next(0, enumerable.Count));

        /// <summary>
        /// Returns a string separated by commas and a word/character as defined in the parameter
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="finalWord">For example and, or, and the ampersand sign</param>
        /// <returns></returns>
        public static string CommasWithWord(this IEnumerable<string> collection, string finalWord)
        {
            var output = string.Empty;

            if (collection == null) 
                return string.Empty;

            var list = collection.ToList();

            if (!list.Any()) 
                return output;

            if (list.Count == 1) 
                return list.First();

            if (list.Count == 2)
                return string.Join($" {finalWord} ", list);

            var delimited = string.Join(", ", list.Take(list.Count - 1));

            output = string.Concat(delimited, $", {finalWord} ", list.LastOrDefault());

            return output;
        }

        /// <summary>
        /// Returns a string separated by commas and a word/character as defined in the parameter
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="finalWord">For example and, or, and the ampersand sign</param>
        /// <returns></returns>
        public static string CommasWithWord(this IEnumerable<int> collection, string finalWord)
        {
            var output = string.Empty;

            if (collection == null) 
                return string.Empty;

            var list = collection.ToList();

            if (!list.Any()) 
                return output;

            if (list.Count == 1) 
                return Convert.ToString(list.First());

            if (list.Count == 2)
                return string.Join($" {finalWord} ", list);

            var delimited = string.Join(", ", list.Take(list.Count - 1));

            output = string.Concat(delimited, $", {finalWord} ", list.LastOrDefault());

            return output;
        }
    }
}