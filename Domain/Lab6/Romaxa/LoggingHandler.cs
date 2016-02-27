using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Lab6.Romaxa
{
    internal sealed class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler()
        {
            InnerHandler = new HttpClientHandler();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!File.Exists("onlinerLOG.txt"))
            {
                using (var stream = File.Create("onlinerLOG.txt")) { }
            }
            var requestMessage = string.Format("Request:\n {0}", request);
            File.AppendAllText("onlinerLOG.txt", requestMessage);
            var response = await base.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();
            var responseMessage = string.Format("Response: \n {0}\n{1}", response, content);
            File.AppendAllText("onlinerLOG.txt", responseMessage);
            return response;
        }

    }
}
