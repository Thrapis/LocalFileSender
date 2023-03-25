using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models
{
    public struct MemoryBytes
    {
        public long Count { get; set; }

        public MemoryBytes(long count) { Count = count; }

        public string Formatted => Format(Count);

        public static string Format(long bytes)
        {
            string[] sizes = { "B", "KiB", "MiB", "GiB", "TiB" };
            int order = 0;
            double len = bytes;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
