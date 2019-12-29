using System.Collections.Generic;
using System.IO;

namespace AzureStorageAction.Extensions
{
    public static class DirectoryInfoExtension
    {
        public static IEnumerable<string> GetFilesRecursive(this DirectoryInfo directory)
        {
            string rootPath = directory.FullName;
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(rootPath);
            while (queue.Count > 0)
            {
                rootPath = queue.Dequeue();

                foreach (string subDir in Directory.GetDirectories(rootPath))
                {
                    queue.Enqueue(subDir);
                }

                string[] files = Directory.GetFiles(rootPath);

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
