using LocalFileSender.Library.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.WinForms.Models
{
    public struct DownloadParameters
    {
        public HostParameters HostParameters { get; set; }
        public List<string> DownloadList { get; set; }
        public string SaveDirectory { get; set; }
    }
}
