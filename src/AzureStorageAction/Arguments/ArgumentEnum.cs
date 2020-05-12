namespace AzureStorageAction.Arguments
{
    public enum ArgumentEnum
    {
        [Argument("-c", true)]
        ConnectionString,

        [Argument("-f", false)]
        FolderName,

        [Argument("-n", false)]
        ContainerName,

        [Argument("-a", false)]
        PublicAccessPolicy,

        [Argument("-s", false)]
        EnableStaticWebSite,

        [Argument("-i", false)]
        IndexDocument,

        [Argument("-e", false)]
        ErrorDocument,
    }
}
