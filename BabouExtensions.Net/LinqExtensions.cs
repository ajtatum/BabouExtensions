using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace BabouExtensions.Net
{
    public static class LinqExtensions
    {
        public static Boolean IsEmpty<T>(this IEnumerable<T> source)
        {
            //http://stackoverflow.com/a/41324/397186
            if (source == null)
                return true; // or throw an exception
            return !source.Any();
        }

        /// <summary>
        /// Returns true if the two lists are exact matches
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool Matches<T>(this List<T> x, List<T> y)
        {
            // same list or both are null
            if (x == y)
            {
                return true;
            }

            // one is null (but not the other)
            if (x == null || y == null)
            {
                return false;
            }

            // count differs; they are not equal
            if (x.Count != y.Count)
            {
                return false;
            }

            return !x.Where((t, i) => !t.Equals(y[i])).Any();
        }

        public static void ForEach<T>(this IList<T> list, Action<T> function)
        {
            foreach (var item in list)
            {
                function?.Invoke(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> function)
        {
            foreach (var item in list)
            {
                function?.Invoke(item);
            }
        }

        /// <summary>
        /// If the condition is true, it performs the where
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// If the condition is true, it performs the where
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, int, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// If the condition is true, it performs the where
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// If the condition is true, it performs the where
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, TKey low, TKey high) where TKey : IComparable<TKey>
        {
            if (keySelector != null)
            {
                Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());
                Expression lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(low));
                Expression upperBound = Expression.LessThanOrEqual(key, Expression.Constant(high));
                Expression and = Expression.AndAlso(lowerBound, upperBound);
                var lambda = Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
                return source.Where(lambda);
            }
            return null;
        }

        /// <summary>
        /// Takes a list and formats it into a string. Great if you have a list of strings and need to put each string on a new line or separate them
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> self, string format)
        {
            return self.ToString(i => string.Format(format, i));
        }

        /// <summary>
        /// Takes a list of names and uses a function to format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="function"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> self, Func<T, object> function)
        {
            var result = new StringBuilder();

            foreach (var item in self) result.Append(function?.Invoke(item));

            return result.ToString();
        }

        /// <summary>
        /// Joins a list of strings by a separator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> self, string separator)
        {
            return string.Join(separator, self.ToArray());
        }

        /// <summary>
        /// Takes a list of items and attempts to put them into a datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            // Create the result table, and gather all properties of a T
            var table = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add the properties as columns to the datatable
            foreach (var prop in props)
            {
                var propType = prop.PropertyType;

                // Is it a nullable type? Get the underlying type
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    propType = new NullableConverter(propType).UnderlyingType;

                table.Columns.Add(prop.Name, propType);
            }

            // Add the property values per T as rows to the datatable
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                table.Rows.Add(values);
            }

            return table;
        }

        /// <summary>
        /// When a query of type "match any of the given strings against one column" is to be performed, the following extension method can be used.
        /// Beware that the logic is slightly different here: When no strings are given, there is no filtering performed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="searchKeys"></param>
        /// <param name="fieldSelector"></param>
        /// <example>
        /// The example below shows how you would generate a LINQ query that would execute the following in SQL:
        /// Select * from Table where (a.FirstName LIKE '%' + @p1 + '%' OR a.FirstName LIKE '%' + @p2 + '%')
        /// </example>
        /// <code>
        /// var manyParam = new string[] { "Jody", "Jane" };
        /// var qry = dbContext.Table.MultiValueContainsAny(manyParam, x => x.FirstName).ToList();
        /// </code>
        /// <returns></returns>
        public static IQueryable<T> MultiValueContainsAny<T>(this IQueryable<T> source, ICollection<string> searchKeys, Expression<Func<T, string>> fieldSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (fieldSelector == null)
                throw new ArgumentNullException(nameof(fieldSelector));
            if (searchKeys == null || searchKeys.Count == 0)
                return source;

            var containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            Expression expression = null;
            foreach (var searchKeyPart in searchKeys)
            {
                var tmp = new Tuple<string>(searchKeyPart);
                Expression searchKeyExpression = Expression.Property(Expression.Constant(tmp), tmp.GetType().GetProperty("Item1"));
                Expression callContainsMethod = Expression.Call(fieldSelector.Body, containsMethod, searchKeyExpression);

                expression = expression == null ? callContainsMethod : Expression.OrElse(expression, callContainsMethod);
            }
            return source.Where(Expression.Lambda<Func<T, bool>>(expression, fieldSelector.Parameters));
        }

        /// <summary>
        /// When a query like "Find me all Persons that have Jonny or Jackie as their first, last or nick name" is to be performed,
        /// the following extension method can be used. Please note that performing such a query can easily become a performance hog; use it's power wisely!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="searchKeys"></param>
        /// <param name="all"></param>
        /// <param name="fieldSelectors"></param>
        /// <example>
        /// The example below shows how you would generate a LINQ query that would execute the following in SQL:
        /// Select * from Table where (a.FirstName LIKE '%' + @p1 + '%' OR a.LastName LIKE '%' + @p2 +'%' OR a.NickName LIKE '%' + @p3 + '%') OR (a.FirstName LIKE '%' + @p4 + '%' OR a.LastName LIKE '%' + @p5 + '%' OR a.NickName LIKE '%' + @p6 + '%')
        /// </example>
        /// <code>
        /// var manyParam = new string[] { "Jody", "Jane" };
        /// var qry = dbContext.Table.MultiValueContainsAnyAll(manyParams, false, x => new [] { x.FirstName, x.LastName, x.NickName }).ToList();
        /// </code>
        /// <returns></returns>
        public static IQueryable<T> MultiValueContainsAnyAll<T>(this IQueryable<T> source, ICollection<string> searchKeys, bool all, Expression<Func<T, string[]>> fieldSelectors)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (fieldSelectors == null)
                throw new ArgumentNullException(nameof(fieldSelectors));
            var newArray = fieldSelectors.Body as NewArrayExpression;
            if (newArray == null)
                throw new ArgumentOutOfRangeException(nameof(fieldSelectors), fieldSelectors, "You need to use fieldSelectors similar to 'x => new string [] { x.LastName, x.FirstName, x.NickName }'; other forms not handled.");
            if (newArray.Expressions.Count == 0)
                throw new ArgumentException("No field selected.");
            if (searchKeys == null || searchKeys.Count == 0)
                return source;

            var containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            Expression expression = null;

            foreach (var searchKeyPart in searchKeys)
            {
                var tmp = new Tuple<string>(searchKeyPart);
                Expression searchKeyExpression = Expression.Property(Expression.Constant(tmp), tmp.GetType().GetProperty("Item1"));

                Expression oneValueExpression = null;
                foreach (var fieldSelector in newArray.Expressions)
                {
                    Expression act = Expression.Call(fieldSelector, containsMethod, searchKeyExpression);
                    oneValueExpression = oneValueExpression == null ? act : Expression.OrElse(oneValueExpression, act);
                }

                if (expression == null)
                    expression = oneValueExpression;
                else if (all)
                    expression = Expression.AndAlso(expression, oneValueExpression);
                else
                    expression = Expression.OrElse(expression, oneValueExpression);
            }
            return source.Where(Expression.Lambda<Func<T, bool>>(expression, fieldSelectors.Parameters));
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            var parts = sortExpression.Split(' ');
            var descending = false;

            if (parts.Length > 0 && parts[0] != "")
            {
                var property = parts[0];

                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }

                var prop = typeof(T).GetProperty(property);

                if (prop == null)
                {
                    throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                }

                return @descending ? list.OrderByDescending(x => prop.GetValue(x, null)) : list.OrderBy(x => prop.GetValue(x, null));
            }

            return list;
        }
    }
}