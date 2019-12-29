using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using AzureStorageAction.Arguments;
using AzureStorageAction.Extensions;

using System;
using System.Threading.Tasks;

namespace AzureStorageAction.Singletons
{
    public sealed class BlobContainerClientSingleton
    {
        private BlobContainerClientSingleton()
        {
            _blobServiceClientObject = BlobServiceClientSingleton.Instance;
        }

        private string _containerName = null;
        private BlobContainerClient _blobContainerClient = null;
        private BlobServiceClient _blobServiceClient = null;
        private BlobServiceClientSingleton _blobServiceClientObject = null;
        private static BlobContainerClientSingleton _instance = null;

        public static BlobContainerClientSingleton Instance
        {
            get
            {
                if (_instance.IsNull())
                {
                    _instance = new BlobContainerClientSingleton();
                }

                return _instance;
            }
        }

        public async Task<BlobContainerClient> GetBlobContainerClient()
        {
            if (_blobContainerClient.IsNull())
            {
                SetContainerName();

                if (_blobServiceClient.IsNull())
                {
                    _blobServiceClient = GetBlobServiceClient();
                }

                _blobContainerClient = await SearchBlobContainer();

                if (_blobContainerClient.IsNull())
                {
                    _blobContainerClient = await CreateBlobContainer();
                }
            }

            return _blobContainerClient;
        }

        private void SetContainerName()
        {
            _containerName = ArgumentContext.Instance.GetValue(ArgumentEnum.ContainerName);

            if (string.IsNullOrWhiteSpace(_containerName))
            {
                _containerName = BlobContainerClient.WebBlobContainerName;
            }
        }

        private async Task<BlobContainerClient> SearchBlobContainer()
        {
            await foreach (BlobContainerItem container in _blobServiceClient.GetBlobContainersAsync())
            {
                if (container.Name.Equals(_containerName.Trim()))
                {
                    BlobContainerClient blobContainer = _blobServiceClient.GetBlobContainerClient(_containerName);
                    Console.WriteLine("Blob Container {0} was found.", _containerName);
                    return blobContainer;
                }
            }

            return null;
        }

        private async Task<BlobContainerClient> CreateBlobContainer()
        {
            BlobContainerClient blobContainer = await _blobServiceClient.CreateBlobContainerAsync(_containerName);
            Console.WriteLine("Blob Container {0} was created.", _containerName);
            return blobContainer;
        }

        private BlobServiceClient GetBlobServiceClient()
        {
            return _blobServiceClientObject.GetBlobServiceClient();
        }
    }
}