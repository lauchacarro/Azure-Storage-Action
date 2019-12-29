using Azure.Storage.Blobs;

using System.Threading.Tasks;

namespace AzureStorageAction.Singletons.Interfaces
{
    public interface IBlobContainerClientSingleton
    {
        IBlobServiceClientSingleton BlobServiceClientObject { get; set; }

        Task<BlobContainerClient> GetBlobContainerClient();
    }
}