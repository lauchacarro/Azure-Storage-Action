namespace AzureStorageAction.Extensions
{
    public static class NullExtension
    {
        public static bool IsNull(this object obj)
        {
            return obj is null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }
    }
}
