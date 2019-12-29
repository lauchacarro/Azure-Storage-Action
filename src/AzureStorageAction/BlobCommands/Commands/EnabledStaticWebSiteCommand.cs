using Azure.Storage.Blobs.Models;

using AzureStorageAction.Arguments;
using AzureStorageAction.BlobCommands.Interfaces;
using AzureStorageAction.Extensions;
using AzureStorageAction.Singletons;

using System;
using System.Threading.Tasks;

namespace AzureStorageAction.BlobCommands.Commands
{
    public class EnabledStaticWebSiteCommand : ICommand
    {
        public async Task ExecuteAction()
        {
            if (bool.TryParse(ArgumentContext.Instance.GetValue(ArgumentEnum.EnableStaticWebSite), out bool enabled))
            {
                Azure.Response<BlobServiceProperties> response = await BlobServiceClientSingleton.Instance.GetBlobServiceClient().GetPropertiesAsync();
                BlobServiceProperties properties = response.Value;
                properties.EnableStaticWebSite(enabled);

                await BlobServiceClientSingleton.Instance.GetBlobServiceClient().SetPropertiesAsync(properties);

                Console.WriteLine("***");

                if (enabled)
                {
                    Console.WriteLine("Enabled Static Web Site:");
                    Console.WriteLine($"IndexDocument: {properties.StaticWebsite.IndexDocument}");
                    Console.WriteLine($"ErrorDocument404Path: {properties.StaticWebsite.ErrorDocument404Path}");
                }
                else
                {
                    Console.WriteLine("Disabled Static Web Site:");
                }

                Console.WriteLine("***");
            }
        }
    }
}
