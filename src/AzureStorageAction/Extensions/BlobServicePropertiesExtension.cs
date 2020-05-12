using Azure.Storage.Blobs.Models;

namespace AzureStorageAction.Extensions
{
    public static class BlobServicePropertiesExtension
    {
        public static void EnableStaticWebSite(this BlobServiceProperties properties, string indexDocument, string errorDocument)
        {
            properties.StaticWebsite.Enabled = true;
            properties.StaticWebsite.ErrorDocument404Path = errorDocument;
            properties.StaticWebsite.IndexDocument = indexDocument;
        }

        public static void DisableStaticWebSite(this BlobServiceProperties properties)
        {
            properties.StaticWebsite.Enabled = false;
            // Avoid error "Element IndexDocument is only expected when StaticWebsite/Enabled is enabled."
            properties.StaticWebsite.ErrorDocument404Path = null;
            properties.StaticWebsite.IndexDocument = null;
        }
    }
}
