using Azure.Storage.Blobs;

using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

namespace AzureStorageAction.Singletons
{
    public sealed class BlobServiceClientSingleton
    {
        private BlobServiceClientSingleton()
        {
        }

        public static BlobServiceClientSingleton _instance = new BlobServiceClientSingleton();

        private BlobServiceClient _blobServiceClient = null;

        public BlobServiceClient GetBlobServiceClient()
        {
            if (_blobServiceClient.IsNull())
            {
                string connectionString = ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString);

                _blobServiceClient = new BlobServiceClient(connectionString);
            }

            return _blobServiceClient;
        }
    }
}
