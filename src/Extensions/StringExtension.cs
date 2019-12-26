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
    }
}
