using AzureStorageAction.BlobCommands.Enums;
using AzureStorageAction.BlobCommands.Interfaces;

using System.Threading.Tasks;

namespace AzureStorageAction.BlobCommands
{
    public class BlobCommandManager
    {
        private ICommand _command;

        public void SetCommand(BlobActionsEnum @enum)
        {
            _command = new CommandFactory().GetCommand(@enum);
        }

        public async Task ExecuteCommand()
        {
            await _command.ExecuteAction();
        }
    }
}
