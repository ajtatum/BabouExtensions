using System;
using System.Collections;
using System.Collections.Generic;

namespace BabouExtensions
{
    /// <summary>
    /// Assert and Validation Extensions
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        /// Throws an exception if the first object is null
        /// </summary>
        /// <param name="objs"></param>
        public static void ThrowOnFirstNull(params object[] objs)
        {
            foreach (var obj in objs)
            {
                ThrowIfNull(obj);
            }
        }

        /// <summary>
        /// Throws an exception if object is null
        /// </summary>
        /// <param name="obj"></param>
        public static void ThrowIfNull(this object obj)
        {
            ThrowIfNull(obj, null);
        }

        /// <summary>
        /// Throws an exception if object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="varName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ThrowIfNull(this object obj, string varName)
        {
            if (obj == null)
                throw new ArgumentNullException(varName ?? "object");
        }

        /// <summary>
        /// Throws an exception if object is null
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="varName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T ThrowIfNull<T>(this T obj, string varName)
        {
            if (obj == null)
                throw new ArgumentNullException(varName ?? "object");

            return obj;
        }

        /// <summary>
        /// Throws an exception is string is empty
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string ThrowIfNullOrEmpty(this string strValue)
        {
            return ThrowIfNullOrEmpty(strValue, null);
        }

        /// <summary>
        /// Throws an exception is string is empty
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="varName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ThrowIfNullOrEmpty(this string strValue, string varName)
        {
            if (string.IsNullOrEmpty(strValue))
                throw new ArgumentNullException(varName ?? "string");

            return strValue;
        }

        /// <summary>
        /// Throws an exception is collection is null
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the varName is empty</exception>
        public static ICollection ThrowIfNullOrEmpty(this ICollection collection)
        {
            ThrowIfNullOrEmpty(collection, null);

            return collection;
        }

        /// <summary>
        /// Throws an exception is collection is null or if varName is empty
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="varName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If collection is null</exception>
        /// <exception cref="ArgumentException">If the varName is empty</exception>
        public static ICollection ThrowIfNullOrEmpty(this ICollection collection, string varName)
        {
            var fieldName = varName ?? "collection";

            if (collection == null)
                throw new ArgumentNullException(fieldName);

            if (collection.Count == 0)
                throw new ArgumentException(fieldName + " is empty");

            return collection;
        }

        /// <summary>
        /// Throws an exception is collection is null
        /// </summary>
        /// <param name="collection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICollection<T> ThrowIfNullOrEmpty<T>(this ICollection<T> collection)
        {
            ThrowIfNullOrEmpty(collection, null);

            return collection;
        }

        
        /// <summary>
        /// Throws an exception is the collection is null or has no items.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="varName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static ICollection<T> ThrowIfNullOrEmpty<T>(this ICollection<T> collection, string varName)
        {
            var fieldName = varName ?? "collection";

            if (collection == null)
                throw new ArgumentNullException(fieldName);

            if (collection.Count == 0)
                throw new ArgumentException(fieldName + " is empty");

            return collection;
        }
    }
}