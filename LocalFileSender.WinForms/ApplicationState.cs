using LocalFileSender.Library.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.WinForms
{
    public class ApplicationState
    {
        public int FileServicePort {  get; set; }
        public string SharedDirectory { get; set; } = string.Empty;
        public string Hostname { get; set; } = string.Empty;
        public int Hostport { get; set; }
        public string SaveDirectory { get; set; } = string.Empty;

        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var json = JsonConvert.SerializeObject(this);
                sw.Write(json);
            }
        }

        public static ApplicationState? Load(string path)
        {
            if (!File.Exists(path)) return null;
            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<ApplicationState>(json);
            }
        }
    }
}
