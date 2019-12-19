using System.Linq;

namespace AzureStorageAction.Extensions
{
    public static class StringExtension
    {
        public static bool IsLast(this string[] args, int index)
        {
            return args.Last() == args[index];
        }
    }
}
