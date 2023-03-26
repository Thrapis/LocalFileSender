﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalFileSender.Library.Models.Bytes;

namespace LocalFileSender.Library.Models.Progress
{
    public class DownloadProgressTimer
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private List<TimedBytes> _history = new List<TimedBytes>();

        private string _fileName;
        private MemoryBytes _fileSize;

        private int _eventEveryMilisec;
        private TimeSpan _lastEvent;


        // Results percent and loading speed
        public event Action<DownloadProgress> ProgressChanged;

        public bool IsRunning => _stopwatch.IsRunning;

        public DownloadProgressTimer(string fileName, long fileSize, int eventEveryMilisec)
        {
            _fileName = fileName;
            _fileSize = new MemoryBytes(fileSize);
            _eventEveryMilisec = eventEveryMilisec;
        }

        public void Start()
        {
            if (!_stopwatch.IsRunning)
            {
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
                if ((_stopwatch.Elapsed - _lastEvent).TotalMilliseconds > _eventEveryMilisec)
                {
                    ProgressChanged.Invoke(GetProgress());
                    _lastEvent = _stopwatch.Elapsed;
                }
            }
        }

        private DownloadProgress GetProgress(int seconds = 1)
        {
            var now = _stopwatch.Elapsed;
            long totalBytes = _history
                .Where(t => (now - t.Moment).Seconds < seconds)
                .Sum(t => t.Bytes) / seconds;

            var percent = _fileSize.Count == 0 ? 0 :
                _history.Sum(t => t.Bytes) * 100d / _fileSize.Count;

            return new DownloadProgress()
            {
                FileName = _fileName,
                Progress = (int)Math.Round(percent),
                ProgressDetails = $"{MemoryBytes.Format(totalBytes)}/s" 
            };
        }
    }
}
