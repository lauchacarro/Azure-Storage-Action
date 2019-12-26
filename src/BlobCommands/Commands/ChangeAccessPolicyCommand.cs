using Azure.Storage.Blobs.Models;

using AzureStorageAction.Arguments;
using AzureStorageAction.BlobCommands.Interfaces;
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
            if (Enum.TryParse(typeof(PublicAccessType), publicAccessPolicy, out object result))
            {
                await (await BlobContainerClientSingleton.GetInstance()).SetAccessPolicyAsync((PublicAccessType)result);
                Console.WriteLine("The Access Policy was changed to {0}", result.ToString());
            }
        }
    }
}
