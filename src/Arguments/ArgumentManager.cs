using AzureStorageAction.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorageAction.Arguments
{
    public class ArgumentManager
    {
        private static Dictionary<ArgumentEnum, string> KeyValues = new Dictionary<ArgumentEnum, string>();

        public static string GetValue(ArgumentEnum @enum)
        {
            return KeyValues.ContainsKey(@enum) ? KeyValues[@enum] : string.Empty;
        }

        public static void MapArguments(string[] args)
        {
            ArgumentEnum[] argumentsEnum = typeof(ArgumentEnum).GetArray<ArgumentEnum>();

            IEnumerable<ArgumentAttribute> argumentAttributes = argumentsEnum.GetArgumentAttributes();

            string[] argumentsKeys = argumentAttributes.GetKeys();

            for (int i = 0; i < args.Length; i++)
            {
                if (!args.IsLast(i))
                {
                    if (argumentsKeys.Contains(args[i]) && !argumentsKeys.Contains(args[i + 1]))
                    {
                        string key = args[i];
                        string value = args[i + 1];

                        int indexOfKey = Array.IndexOf(argumentsKeys, key);
                        ArgumentEnum enumOfKey = argumentsEnum[indexOfKey];

                        KeyValues.Add(enumOfKey, value);
                    }
                }
            }

            ArgumentEnum? argumentMissing = KeyValues.ValidateArgumentsRequerid();
            if (argumentMissing.HasValue)
            {
                throw new ArgumentException(string.Format("{0} was not specified", argumentMissing.Value.ToString()));
            }
        }
    }
}
