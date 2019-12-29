using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using AzureStorageAction.Arguments;
using AzureStorageAction.BlobCommands.Interfaces;
using AzureStorageAction.Extensions;
using AzureStorageAction.Singletons;

using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorageAction.BlobCommands.Commands
{
    public class StartUploadFilesCommand : ICommand
    {
        public async Task ExecuteAction()
        {
            string folderName = ArgumentContext.Instance.GetValue(ArgumentEnum.FolderName);
            string rootPath = string.IsNullOrWhiteSpace(folderName)
                ? Environment.CurrentDirectory
                : Path.Combine(Environment.CurrentDirectory, folderName);


            if (Directory.Exists(rootPath))
            {
                DirectoryInfo directory = new DirectoryInfo(rootPath);
                foreach (string filePath in directory.GetFilesRecursive())
                {
                    FileInfo file = new FileInfo(filePath);

                    string fileName = file.GetFileName(rootPath);

                    BlobClient blobClient = (await BlobContainerClientSingleton.Instance.GetBlobContainerClient()).GetBlobClient(fileName);

                    await blobClient.UploadAsync(file.FullName, true);

                    Console.WriteLine("Upload: {0}", fileName);
                    Console.WriteLine("Uri: {0}", blobClient.Uri.ToString());

                    string contentType = file.GetContentType();

                    if (!string.IsNullOrWhiteSpace(contentType))
                    {
                        BlobHttpHeaders blobHeaders = new BlobHttpHeaders
                        {
                            ContentType = contentType
                        };

                        await blobClient.SetHttpHeadersAsync(blobHeaders);

                        Console.WriteLine("Content-Type was found: {0}", contentType);
                    }

                    Console.WriteLine("****");
                }
            }
            else
            {
                throw new ArgumentException(string.Format("The path '{0}' don´t exists.", rootPath));
            }
        }
    }
}
