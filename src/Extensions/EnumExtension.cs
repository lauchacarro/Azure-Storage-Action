using AzureStorageAction.Arguments;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AzureStorageAction.Extensions
{
    public static class EnumExtension
    {
        public static ArgumentAttribute GetArgumentAttribute(this Enum @enum)
        {
            FieldInfo fi = @enum.GetType().GetField(@enum.ToString());

            ArgumentAttribute[] attributes =
                (ArgumentAttribute[])fi.GetCustomAttributes(
                typeof(ArgumentAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0];
            else
                return null;
        }

        public static T[] GetArray<T>(this Type type) where T : Enum
        {
            return Enum.GetValues(type).Cast<T>().ToArray();
        }

        public static IEnumerable<ArgumentAttribute> GetArgumentAttributes(this IEnumerable<ArgumentEnum> enums)
        {
            return enums.Select(x => x.GetArgumentAttribute());
        }
    }
}
