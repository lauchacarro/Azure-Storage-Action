using Azure.Storage.Blobs;

using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;
using AzureStorageAction.Singletons.Interfaces;

namespace AzureStorageAction.Singletons
{
    public sealed class BlobServiceClientSingleton : IBlobServiceClientSingleton
    {
        private BlobServiceClientSingleton()
        {
        }

        private static BlobServiceClientSingleton _instance = null;
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
        public BlobServiceClient BlobServiceClientObject { get; set; }

        public BlobServiceClient GetBlobServiceClient()
        {
            if (BlobServiceClientObject.IsNull())
            {
                string connectionString = ArgumentContext.Instance.GetValue(ArgumentEnum.ConnectionString);

                BlobServiceClientObject = new BlobServiceClient(connectionString);
            }

            return BlobServiceClientObject;
        }
    }
}
