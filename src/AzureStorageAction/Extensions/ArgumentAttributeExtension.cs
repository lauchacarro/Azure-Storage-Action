using AzureStorageAction.Arguments;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorageAction.Extensions
{
    public static class ArgumentAttributeExtension
    {
        public static string[] GetKeys(this IEnumerable<ArgumentAttribute> arguments)
        {
            return arguments.Select(x => x.Key).ToArray();
        }

        public static IEnumerable<ArgumentAttribute> GetRequired(this IEnumerable<ArgumentAttribute> arguments)
        {
            return arguments.Where(x => x.IsRequired);
        }

        public static IEnumerable<ArgumentEnum> ToEnums(this IEnumerable<ArgumentAttribute> arguments)
        {
            string[] argumentsKeys = typeof(ArgumentEnum).GetArray<ArgumentEnum>().GetArgumentAttributes().GetKeys().ToArray();
            string[] keysValids = arguments.Where(x => argumentsKeys.Contains(x.Key)).GetKeys();

            return keysValids.Select(x => (ArgumentEnum)Array.IndexOf(argumentsKeys, x));
        }

        public static ArgumentEnum? ValidateArgumentsRequerid(this Dictionary<ArgumentEnum, string> keyValues)
        {
            ArgumentEnum[] argumentsEnum = typeof(ArgumentEnum).GetArray<ArgumentEnum>();

            IEnumerable<ArgumentAttribute> argumentAttributes = argumentsEnum.GetArgumentAttributes();

            IEnumerable<ArgumentAttribute> argumentsRequired = argumentAttributes.GetRequired();

            IEnumerable<ArgumentEnum> enumsRequired = argumentsRequired.ToEnums();

            foreach (ArgumentEnum argumentEnum in enumsRequired)
            {
                if (!keyValues.ContainsKey(argumentEnum))
                    return argumentEnum;
            }

            return null;
        }
    }
}
