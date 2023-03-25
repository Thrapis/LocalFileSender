using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Status
{
    public enum AnswerStatus : byte
    {
        Approved,
        AccessDenied,
        Unknownxception,
        NoFileException,
        Complete,
        Continue
    }
}
