using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using AzureStorageAction.Arguments;
using AzureStorageAction.BlobCommands.Interfaces;
using AzureStorageAction.Extensions;
using AzureStorageAction.Singletons;

using System;
using System.Threading.Tasks;

namespace AzureStorageAction.BlobCommands.Commands
{
    public class ChangeAccessPolicyCommand : ICommand
    {
        public async Task ExecuteAction()
        {
            string publicAccessPolicy = ArgumentContext.Instance.GetValue(ArgumentEnum.PublicAccessPolicy);
            if (publicAccessPolicy.IsPublicAccessType(out PublicAccessType result))
            {
                BlobContainerClient blobContainerClient = await BlobContainerClientSingleton.Instance.GetBlobContainerClient();
                await blobContainerClient.SetAccessPolicyAsync(result);
                Console.WriteLine("The Access Policy was changed to {0}", result.ToString());
            }
        }
    }
}
