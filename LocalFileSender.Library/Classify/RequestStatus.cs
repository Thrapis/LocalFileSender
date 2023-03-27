using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Classify
{
    public enum RequestStatus : byte
    {
        None = 0,
        Continue,
        Stop,
        Complete,
        GetStored = 16,
        SendFile,
    }
}
