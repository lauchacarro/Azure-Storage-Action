using Azure.Storage.Blobs;

namespace AzureStorageAction.Singletons.Interfaces
{
    public interface IBlobServiceClientSingleton
    {
        BlobServiceClient GetBlobServiceClient();
    }
}