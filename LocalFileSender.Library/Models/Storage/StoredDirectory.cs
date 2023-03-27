using LocalFileSender.Library.Models.Bytes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models.Storage
{
    public class StoredDirectory : IStored
    {
        public List<StoredDirectory> StoredDirectories { get; set; }
        public List<StoredFile> StoredFiles { get; set; }

        [JsonIgnore]
        public List<IStored> Stored
        {
            get
            {
                var li = StoredDirectories.Select(d => (IStored)d).ToList();
                li.AddRange(StoredFiles.Select(f => (IStored)f));
                return li;
            }
        }

        public string FullPath { get; set; } = string.Empty;
        public string Name => Path
            .GetRelativePath(Path.GetDirectoryName(FullPath) ?? string.Empty, FullPath);
        public MemoryBytes ByteSize
        { 
            get
            {
                var val = StoredFiles.Sum(f => f.ByteSize.Count)
                    + StoredDirectories.Sum(d => d.ByteSize.Count);
                return new MemoryBytes(val);
            }
        }

        public StoredDirectory()
        {
            StoredDirectories = new List<StoredDirectory>();
            StoredFiles = new List<StoredFile>();
        }

        public StoredDirectory(string fullPath) : this()
        {
            FullPath = fullPath;
        }

        public StoredFile? GetStoredFileByRelativePath(string relativePath)
        {
            string? fullDirectoryName = Path.GetDirectoryName(relativePath);
            if ((fullDirectoryName ?? string.Empty) == string.Empty)
            {
                return StoredFiles
                    .FirstOrDefault(f => GetRelativePath(f) == relativePath);
            }

            string[] subDirectoriesName = fullDirectoryName!
                .Split(Path.DirectorySeparatorChar, StringSplitOptions.None);

            var targetDirectory = this;
            for (int i = 0; i < subDirectoriesName.Length; i++)
            {
                StoredDirectory? stepDirectory = targetDirectory.StoredDirectories
                    .FirstOrDefault(d => d.Name == subDirectoriesName[i]);

                if (stepDirectory == null) return null;

                targetDirectory = stepDirectory;
            }

            return targetDirectory.StoredFiles
                .FirstOrDefault(f => GetRelativePath(f) == relativePath);
        }

        public string GetRelativePath(IStored stored)
        {
            return Path.GetRelativePath(FullPath, stored.FullPath);
        }

        public override string ToString()
        {
            return $"{Name}   ({ByteSize.Formatted})";
        }
    }
}
