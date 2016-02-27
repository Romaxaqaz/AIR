using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Lab6.JFF
{
    public delegate void ReqestAccepted(object obj);

    public class Translator
    {
        private event ReqestAccepted onLangsAccepted;
        private event ReqestAccepted onTranslate;

        private readonly HttpClient client;
        private readonly string getLangsUrl, token;

        public Translator(ReqestAccepted onLangsAccepted, ReqestAccepted onTranslate)
        {
            this.onLangsAccepted = onLangsAccepted;
            this.onTranslate = onTranslate;
            client = new HttpClient(new HttpLogger(ConfigurationManager.AppSettings["logger"]));
            token = ConfigurationManager.AppSettings["token"];
            getLangsUrl = string.Format(ConfigurationManager.AppSettings["langs"], token);
            Task.Factory.StartNew(GetLags);
        }

        private async void GetLags()
        {
            var jsonlangs = await client.GetStringAsync(getLangsUrl);
            var langs = JsonConvert.DeserializeObject<LangsDTO>(jsonlangs);
            onLangsAccepted(langs);
        }

        public void Translate(string text, string langs)
        {
            Task.Factory.StartNew(() => TranslateCore(text, langs));
        }

        private async void TranslateCore(string text, string langs)
        {
            var translationJson = await client.GetStringAsync(string.Format(ConfigurationManager.AppSettings["translate"], token, text, langs));
            var translation = JsonConvert.DeserializeObject<TranslationDTO>(translationJson);
            onTranslate(translation.ToString());
        }
    }
}
