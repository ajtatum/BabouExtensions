﻿using System;
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
    }
}