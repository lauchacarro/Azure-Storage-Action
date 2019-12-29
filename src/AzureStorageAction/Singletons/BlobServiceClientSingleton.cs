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

        private static BlobServiceClientSingleton _instance = null;
        private BlobServiceClient _blobServiceClientObject = null;

        public static BlobServiceClientSingleton Instance
        {
            get
            {
                if (_instance.IsNull())
                {
                    _instance = new BlobServiceClientSingleton();
                }

                return _instance;
            }
        }

        public BlobServiceClient GetBlobServiceClient()
        {
            if (_blobServiceClientObject.IsNull())
            {
                string connectionString = ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString);

                _blobServiceClientObject = new BlobServiceClient(connectionString);
            }

            return _blobServiceClientObject;
        }
    }
}
