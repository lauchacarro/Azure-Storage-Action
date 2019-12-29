using AzureStorageAction.Arguments;
using AzureStorageAction.BlobCommands;
using AzureStorageAction.BlobCommands.Enums;
using AzureStorageAction.Extensions;

using System;
using System.Threading.Tasks;

namespace AzureStorageAction
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Environment Directory: {0}", Environment.CurrentDirectory);

            string[] arguments = args.RemoveNullAndWhitespace();

            ArgumentContext.Instance.AddArguments(arguments);

            BlobCommandManager manager = new BlobCommandManager();
            manager.SetCommand(BlobActionsEnum.EnabledStaticWebSite);
            await manager.ExecuteCommand();

            manager.SetCommand(BlobActionsEnum.ChangeAccessPolicy);
            await manager.ExecuteCommand();

            manager.SetCommand(BlobActionsEnum.StartUploadFiles);
            await manager.ExecuteCommand();
        }
    }
}
