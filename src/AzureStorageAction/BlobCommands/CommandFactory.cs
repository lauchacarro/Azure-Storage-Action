using AzureStorageAction.BlobCommands.Commands;
using AzureStorageAction.BlobCommands.Enums;
using AzureStorageAction.BlobCommands.Interfaces;

using System.ComponentModel;

namespace AzureStorageAction.BlobCommands
{
    public class CommandFactory
    {
        public ICommand GetCommand(BlobActionsEnum commandOption)
        {
            return commandOption switch
            {
                BlobActionsEnum.EnabledStaticWebSite => new EnabledStaticWebSiteCommand(),
                BlobActionsEnum.ChangeAccessPolicy => new ChangeAccessPolicyCommand(),
                BlobActionsEnum.StartUploadFiles => new StartUploadFilesCommand(),
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}
