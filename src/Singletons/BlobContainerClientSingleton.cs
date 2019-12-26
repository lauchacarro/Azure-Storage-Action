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
        }

        public static readonly BlobContainerClientSingleton _instance = new BlobContainerClientSingleton();

        public string ContainerName { get; set; }

        private BlobContainerClient _blobContainerClient = null;

        public async Task<BlobContainerClient> GetBlobContainerClient()
        {
            if (_blobContainerClient.IsNull())
            {
                SetContainerName();

                await foreach (BlobContainerItem container in BlobServiceClientSingleton._instance.GetBlobServiceClient().GetBlobContainersAsync())
                {
                    if (container.Name == _instance.ContainerName.Trim())
                    {
                        _blobContainerClient = BlobServiceClientSingleton._instance.GetBlobServiceClient().GetBlobContainerClient(_instance.ContainerName);
                        Console.WriteLine("Blob Container {0} was found.", _instance.ContainerName);
                        break;
                    }
                }

                if (_blobContainerClient.IsNull())
                {
                    _blobContainerClient = await BlobServiceClientSingleton._instance.GetBlobServiceClient().CreateBlobContainerAsync(_instance.ContainerName);
                    Console.WriteLine("Blob Container {0} was created.", _instance.ContainerName);
                }
            }

            return _blobContainerClient;
        }

        public void SetContainerName()
        {
            _instance.ContainerName = ArgumentContext.Instance.GetValue(ArgumentEnum.ContainerName);

            if (string.IsNullOrWhiteSpace(_instance.ContainerName))
            {
                _instance.ContainerName = BlobContainerClient.WebBlobContainerName;
            }
        }
    }
}
