using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Classify
{
    public enum RequestType : byte
    {
        GetFileList,
        SendFile
    }
}
