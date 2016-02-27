using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Lab6.JFF
{
    internal sealed class HttpLogger : DelegatingHandler
    {
        private Logger logger;

        public HttpLogger(string path)
        {
            InnerHandler = new HttpClientHandler();
            logger = new Logger(path);
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            logger.Log(request);
            var response = await base.SendAsync(request, cancellationToken);
            logger.Log(response);
            return response;
        }
    }
}
