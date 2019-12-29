using AzureStorageAction.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureStorageAction.Arguments
{
    public class ArgumentContext
    {
        private ArgumentContext()
        {
            _arguments = new Dictionary<ArgumentEnum, string>();
        }

        private readonly Dictionary<ArgumentEnum, string> _arguments = null;

        private static ArgumentContext _instance;
        public static ArgumentContext Instance
        {
            get
            {
                if (_instance.IsNull())
                {
                    _instance = new ArgumentContext();
                }
                return _instance;
            }
        }

        public string GetValue(ArgumentEnum @enum)
        {
            return _arguments.ContainsKey(@enum) ? _arguments[@enum] : string.Empty;
        }

        public void AddArguments(string[] args)
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

                        if (!_arguments.TryAdd(enumOfKey, value))
                        {
                            _arguments[enumOfKey] = value;
                        }
                    }
                }
            }

            ArgumentEnum? argumentMissing = _arguments.ValidateArgumentsRequerid();
            if (argumentMissing.HasValue)
            {
                throw new ArgumentException(string.Format("{0} was not specified", argumentMissing.Value.ToString()));
            }
        }

        public void Clear()
        {
            _arguments.Clear();
        }
    }
}
