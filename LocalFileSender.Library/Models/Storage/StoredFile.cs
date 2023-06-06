using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalFileSender.Library.Models.Bytes;

namespace LocalFileSender.Library.Models.Storage
{
    public class StoredFile : IStored
    {
        public string FullPath { get; set; } = string.Empty;
        public string Name => Path.GetFileName(FullPath);
        public MemoryBytes ByteSize { get; set; }

        public string DotExtension => Path.GetExtension(FullPath);
        public string Extension => DotExtension.Replace(".", string.Empty);

        public StoredFile() { }

        public StoredFile(string fullPath, long byteSize) : this()
        {
            FullPath = fullPath;
            ByteSize = new MemoryBytes(byteSize);
        }

        public StoredFile(string fullPath, MemoryBytes byteSize) : this()
        {
            FullPath = fullPath;
            ByteSize = byteSize;
        }

        public override string ToString()
        {
            return $"{Name}   {ByteSize.Formatted}";
        }
    }
}
