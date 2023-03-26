using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Status
{
    public enum ResponseStatus : byte
    {
        None = 0,
        Approved,
        AccessDenied,
        UnknownException = 16,
        NoFileException,
    }
}
