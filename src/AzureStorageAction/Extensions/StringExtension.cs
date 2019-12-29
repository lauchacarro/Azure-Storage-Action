using Azure.Storage.Blobs.Models;

using System;
using System.Linq;

namespace AzureStorageAction.Extensions
{
    public static class StringExtension
    {
        public static bool IsLast(this string[] args, int index)
        {
            return args.Last() == args[index];
        }

        public static string[] RemoveNullAndWhitespace(this string[] args)
        {
            return args.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        }

        public static bool IsPublicAccessType(this string str, out PublicAccessType publicAccessType)
        {
            bool result = Enum.TryParse(typeof(PublicAccessType), str, out object @enum);
            publicAccessType = (PublicAccessType)(@enum.IsNull() ? -1 : @enum);

            return result;
        }
    }
}
