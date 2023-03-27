using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models.Progress
{
    public class DownloadProgress
    {
        public int Progress { get; set; }
        public string ProgressDetails { get; set; } = string.Empty;
        public DownloadFile File { get; set; } = new();
    }
}
