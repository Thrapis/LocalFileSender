using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models
{
    public struct TimedBytes
    {
        public TimeSpan Moment;
        public long Bytes;

        public TimedBytes(TimeSpan moment, long bytes) 
        {
            Moment = moment;
            Bytes = bytes;
        }
    }
}
