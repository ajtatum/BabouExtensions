using System;

namespace BabouExtensions.Attributes
{
    /// <summary>
    /// Represents the Open Api Data type metadata attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class DisplayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayAttribute"/> class.
        /// </summary>
        /// <param name="name">The display name.</param>
        /// <exception cref="T:System.ArgumentNullException">Parameter name is required. <paramref name="name"/></exception>
        public DisplayAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Parameter name is required.");
            }

            Name = name;
        }

        /// <summary>
        /// The display Name.
        /// </summary>
        public string Name { get; }
    }
}
