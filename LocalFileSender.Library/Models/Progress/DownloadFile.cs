using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models.Progress
{
    public class DownloadFile
    {
        public string Name { get; set; } = string.Empty;
        public long Size { get; set; }
        public int PollNumber { get; set; }
        public int PollTotal { get; set; }
    }
}
