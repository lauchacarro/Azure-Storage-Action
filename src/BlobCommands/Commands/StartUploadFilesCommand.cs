using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using AzureStorageAction.Arguments;
using AzureStorageAction.BlobCommands.Interfaces;
using AzureStorageAction.Extensions;
using AzureStorageAction.Singletons;

using Microsoft.AspNetCore.StaticFiles;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureStorageAction.BlobCommands.Commands
{
    public class StartUploadFilesCommand : ICommand
    {
        public async Task ExecuteAction()
        {
            string folderName = ArgumentContext.Instance.GetValue(ArgumentEnum.FolderName);
            string completePath = string.IsNullOrWhiteSpace(folderName)
                ? Environment.CurrentDirectory
                : Path.Combine(Environment.CurrentDirectory, folderName);


            if (Directory.Exists(completePath))
            {
                foreach (string filePath in GetFiles(completePath))
                {
                    FileInfo file = new FileInfo(filePath);

                    string fileName = file.FullName.Replace(completePath, string.Empty);

                    foreach (string slide in new[] { "\\", "\"", "/" })
                    {
                        fileName = fileName.StartsWith(slide) ? fileName.Substring(slide.Length) : fileName;
                    }

                    BlobClient blobClient = (await BlobContainerClientSingleton.GetInstance()).GetBlobClient(fileName);

                    await blobClient.UploadAsync(file.FullName, true);

                    Console.WriteLine("Upload: {0}", fileName);
                    Console.WriteLine("Uri: {0}", blobClient.Uri.ToString());

                    var provider = new FileExtensionContentTypeProvider();

                    if (provider.TryGetContentType(file.Name, out string contentType))
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
                throw new ArgumentException(string.Format("The path '{0}' don´t exists.", completePath));
            }
        }

        IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();

                foreach (string subDir in Directory.GetDirectories(path))
                {
                    queue.Enqueue(subDir);
                }

                string[] files = Directory.GetFiles(path);

                if (files.IsNotNull())
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }

        }
    }
}
