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

        private static BlobServiceClient _instance = null;

        public static BlobServiceClient GetInstance()
        {
            if (_instance.IsNull())
            {
                string connectionString = ArgumentManager.GetValue(ArgumentEnum.ConnectionString);

                _instance = new BlobServiceClient(connectionString);
            }

            return _instance;
        }
    }
}
