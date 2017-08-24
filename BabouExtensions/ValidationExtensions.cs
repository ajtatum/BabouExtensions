using System;

namespace BabouExtensions
{
    public static class ValidationExtensions
    {
        public static T ThrowIfNullOrEmpty<T>(this T o, string paramName) where T : class
        {
            if (o == null)
                throw new ArgumentNullException(paramName);
            if (o is string && String.IsNullOrWhiteSpace(Convert.ToString(o)))
                throw new ArgumentException($"{paramName} cannot be empty.");

            return o;
        }
    }
}