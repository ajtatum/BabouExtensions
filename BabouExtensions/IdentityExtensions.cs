using System;
using System.Security.Claims;
using System.Security.Principal;

namespace BabouExtensions
{
    /// <summary>
    /// Identity Extensions
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// Gets property from <see cref="IIdentity"/>
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="property">Property to search for in IIdentity</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetProperty(this IIdentity identity, string property)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity), "Identity cannot be null");

            if(string.IsNullOrEmpty(property))
                throw new ArgumentNullException(nameof(property), "Property cannot be null or empty");

            var claim = ((ClaimsIdentity) identity).FindFirst(property);
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}