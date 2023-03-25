using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalFileSender.Library.Models.Bytes;

namespace LocalFileSender.Library.Models.Storage
{
    public class StoredFile
    {
        public string FullPath { get; set; } = string.Empty;
        public string FileName => Path.GetFileName(FullPath);
        public MemoryBytes ByteSize { get; set; }

        public override string ToString()
        {
            return $"{FileName}\t{ByteSize.Formatted}";
        }
    }
}
