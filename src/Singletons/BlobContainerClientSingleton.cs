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

        private static BlobContainerClient _instance = null;

        public static async Task<BlobContainerClient> GetInstace()
        {
            if (_instance.IsNull())
            {
                string containerName = ArgumentContext.Instance.GetValue(ArgumentEnum.ContainerName);

                if (string.IsNullOrWhiteSpace(containerName))
                {
                    containerName = BlobContainerClient.WebBlobContainerName;
                }

                await foreach (BlobContainerItem container in BlobServiceClientSingleton.GetInstance().GetBlobContainersAsync())
                {
                    if (container.Name == containerName.Trim())
                    {
                        _instance = BlobServiceClientSingleton.GetInstance().GetBlobContainerClient(containerName);
                        Console.WriteLine("Blob Container {0} was found.", containerName);
                        break;
                    }
                }

                if (_instance.IsNull())
                {
                    _instance = await BlobServiceClientSingleton.GetInstance().CreateBlobContainerAsync(containerName);
                    Console.WriteLine("Blob Container {0} was created.", containerName);
                }
            }

            return _instance;
        }
    }
}
