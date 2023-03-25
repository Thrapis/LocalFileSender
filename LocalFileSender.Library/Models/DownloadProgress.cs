using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models
{
    public class DownloadProgress
    {
        private Stopwatch _stopwatch = new Stopwatch();

        private List<TimedBytes> _history = new List<TimedBytes>();
        private MemoryBytes _fileSize;

        public bool IsRunning => _stopwatch.IsRunning;

        public void Start(long fileSize)
        {
            if (!_stopwatch.IsRunning)
            {
                _fileSize = new MemoryBytes(fileSize);
                _stopwatch.Start();
            }
        }

        public void Stop()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
            }
        }

        public void AddProgress(long bytes)
        {
            if (_stopwatch.IsRunning)
            {
                _history.Add(new TimedBytes(_stopwatch.Elapsed, bytes));
            }
        }

        public string DownloadSpeedFor(int seconds)
        {
            var now = _stopwatch.Elapsed;
            long totalBytes = _history
                .Where(t => (now - t.Moment).Seconds < seconds)
                .Sum(t => t.Bytes) / seconds;
            return $"{MemoryBytes.Format(totalBytes)}/s";
        }

        public int DownloadedPercent()
        {
            if (_fileSize.Count == 0) return 0;
            var totalBytes = _history.Sum(t => t.Bytes);
            var percent =  totalBytes * 100 / _fileSize.Count;
            return (int)percent;
        }
    }
}
