using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models
{
    public static class StoredFileCommander
    {
        public static string SharedDirectory { get; set; } = string.Empty;

        public static List<StoredFile> StoredFiles => GetFiles();

        private static List<StoredFile> GetFiles()
        {
            var list = new List<StoredFile>();

            if (!Directory.Exists(SharedDirectory))
            {
                Directory.CreateDirectory(SharedDirectory);
            }

            string[] fullPaths = Directory.GetFiles(SharedDirectory);
            foreach (string fullPath in fullPaths)
            {
                var fileInfo = new FileInfo(fullPath);
                list.Add(new StoredFile()
                {
                    FullPath = fullPath,
                    ByteSize = new MemoryBytes(fileInfo.Length)
                });
            }

            return list;
        }
    }
}
