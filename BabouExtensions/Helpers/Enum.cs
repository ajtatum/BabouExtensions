using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BabouExtensions.Helpers
{
    public class Enum<T> where T : struct, IConvertible
    {
        /// <summary>
        /// Returns a <see cref="List{T}"/> type string from an <see cref="Enum"/> based on the <see cref="DescriptionAttribute"/>.
        /// <para>If the <see cref="DescriptionAttribute"/> is absent, it uses the name of the <see cref="Enum"/>.</para>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetListByDescriptionAttr()
        {
            var items = new List<string>();

            var type = typeof(T);

            if (type.IsEnum)
            {
                var values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));

                    var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    var enumString = memInfo[0].Name;

                    if (descriptionAttributes.Length > 0)
                    {
                        enumString = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                    }

                    items.Add(enumString);
                }
            }
            return items;
        }

        /// <summary>
        /// Returns a <see cref="List{T}"/> type string from an <see cref="Enum"/> based on the <see cref="DisplayAttribute"/>.
        /// <para>If the <see cref="DisplayAttribute"/> is absent, it uses the name of the <see cref="Enum"/>.</para>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetListByDisplayAttr()
        {
            var items = new List<string>();

            var type = typeof(T);

            if (type.IsEnum)
            {
                var values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));

                    var displayAttribute = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                    var enumString = memInfo[0].Name;

                    if (displayAttribute.Length > 0)
                    {
                        enumString = ((DisplayAttribute)displayAttribute[0]).Name;
                    }

                    items.Add(enumString);
                }
            }
            return items;
        }
    }
}
