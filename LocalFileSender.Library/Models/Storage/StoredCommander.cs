using LocalFileSender.Library.Models.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models.Storage
{
    public static class StoredCommander
    {
        public static string SharedDirectoryFullPath { get; set; } = string.Empty;

        public static async Task<StoredDirectory> GetSharedDirectoryAsync()
        {
            if (!Directory.Exists(SharedDirectoryFullPath))
            {
                Directory.CreateDirectory(SharedDirectoryFullPath);
            }

            return await GetDirectoryAsync(SharedDirectoryFullPath);
        }

        private static async Task<StoredDirectory> GetDirectoryAsync(string directory)
        {
            StoredDirectory storedDirectory = new StoredDirectory(directory);

            string[] fileFullPaths = Directory.GetFiles(directory);
            foreach (string fullPath in fileFullPaths)
            {
                var fileInfo = new FileInfo(fullPath);
                storedDirectory.StoredFiles.Add(new StoredFile(fullPath, fileInfo.Length));
            }

            string[] directoryFullPaths = Directory.GetDirectories(directory);
            /*foreach (string fullPath in directoryFullPaths)
            {
                StoredDirectory innerDirectory = GetDirectory(fullPath);
                storedDirectory.StoredDirectories.Add(innerDirectory);
            }*/

            await Parallel.ForEachAsync(directoryFullPaths, async (fullPath, cancellationToken) =>
            {
                StoredDirectory innerDirectory = await GetDirectoryAsync(fullPath);
                storedDirectory.StoredDirectories.Add(innerDirectory);
            });

            return storedDirectory;
        }
    }
}
