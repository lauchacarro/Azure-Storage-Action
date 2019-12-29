using Microsoft.AspNetCore.StaticFiles;

using System.IO;

namespace AzureStorageAction.Extensions
{
    public static class FileInfoExtension
    {
        public static string GetFileName(this FileInfo fileInfo, string rootPath)
        {
            string fileName = fileInfo.FullName.Replace(rootPath, string.Empty);

            foreach (string slide in new[] { "\\", "\"", "/" })
            {
                fileName = fileName.StartsWith(slide) ? fileName.Substring(slide.Length) : fileName;
            }

            return fileName;
        }

        public static string GetContentType(this FileInfo fileInfo)
        {
            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();

            if (provider.TryGetContentType(fileInfo.Name, out string contentType))
            {
                return contentType;
            }

            return null;
        }
    }
}
