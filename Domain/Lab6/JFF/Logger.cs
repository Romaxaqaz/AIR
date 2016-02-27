using System;
using System.IO;
using System.Net.Http;

namespace Domain.Lab6.JFF
{
    internal sealed class Logger
    {
        private readonly string path;
        private const string formathString = "\n---{0}---\n{1}\n";

        public Logger(string path)
        {
            this.path = path;
            if (!File.Exists(path))
            {
                using (var stream = File.Create(path)) { }
            }
        }

        public void Log(string text)
        {
            var log = string.Format(formathString, DateTime.Now.ToString("G"), text);
            File.AppendAllText(path, log);
        }

        public void Log(HttpRequestMessage request)
        {
            var log = string.Format(formathString, DateTime.Now.ToString("G"), request);
            File.AppendAllText(path, log);
        }

        public async void Log(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var log = string.Format(formathString + "Content:\n{2}\n", DateTime.Now.ToString("G"), response, content);
            File.AppendAllText(path, log);
        }
    }
}
