using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Logger
{
    public class ResponsibleLogger
    {
        public delegate void Log();
        public delegate void LogMessage(DateTime time, string message);
        public event Log OnLogged; 
        public event LogMessage? OnLoggedMessage; 

        public Dictionary<DateTime, string> LogHistory { get; private set; }

        public ResponsibleLogger()
        {
            LogHistory = new Dictionary<DateTime, string>();
        }

        public void MakeLog(string message)
        {
            DateTime time = DateTime.Now;
            LogHistory.Add(time, message);
            OnLoggedMessage?.Invoke(time, message);
            OnLogged?.Invoke();
        }
    }
}
