using System.Threading.Tasks;

namespace AzureStorageAction.BlobCommands.Interfaces
{
    public interface ICommand
    {
        Task ExecuteAction();
    }
}
