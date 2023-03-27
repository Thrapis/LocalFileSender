using LocalFileSender.Library.Models.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models.Storage
{
    public interface IStored
    {
        string FullPath { get; set; }
        string Name { get; }
        MemoryBytes ByteSize { get; }
    }
}
