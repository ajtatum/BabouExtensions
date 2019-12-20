using System;
using System.ComponentModel;
using System.Linq;

namespace BabouExtensions
{
    /// <summary>
    /// Enum Extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description of an enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        public static T? GetEnumValueFromDescription<T>(this string source) where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false),
                    (f, a) => new { Field = f, Att = a })
                .SingleOrDefault(a => ((DescriptionAttribute)a.Att).Description == source);

            return (T?)field?.Field?.GetRawConstantValue();
        }

        /// <summary>
        /// Gets an Enum from String
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException">T must be an enumerated type.</exception>
        public static T ParseEnum<T>(this string source, T defaultValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) 
                throw new ArgumentException("T must be an enumerated type");

            if (source.IsNullOrWhiteSpace()) 
                return defaultValue;

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().ToLower().Equals(source.Trim().ToLower())) 
                    return item;
            }
            return defaultValue;
        }
    }
}
