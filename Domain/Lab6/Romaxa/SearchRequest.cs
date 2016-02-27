using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Lab6.Romaxa
{
    public class SearchRequest
    {
        private HttpClient httpClient;
        private readonly string Url = "https://catalog.api.onliner.by/search/products?query=";

        private AllProducts productList = new AllProducts();
        public AllProducts ProductList { get { return productList; } }

        public delegate void dlgProgress(AllProducts products);
        public event dlgProgress Progress;

        public async void Request(string productSearch)
        {
            httpClient = new HttpClient(new LoggingHandler());
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetStringAsync(Url + productSearch);
            productList = JsonConvert.DeserializeObject<AllProducts>(response);
            Progress(productList);
        }
    }
}
