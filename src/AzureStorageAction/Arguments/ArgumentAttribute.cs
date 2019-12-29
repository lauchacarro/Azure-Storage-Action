using System;

namespace AzureStorageAction.Arguments
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ArgumentAttribute : Attribute
    {
        public ArgumentAttribute(string key, bool isRequired)
        {
            Key = key;
            IsRequired = isRequired;
        }

        public string Key { get; set; }
        public bool IsRequired { get; set; }

    }
}
