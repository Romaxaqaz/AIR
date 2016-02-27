using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Lab6.Romaxa
{
    public class AllProducts
    {
        public List<Products> products;
        public int total { get; set; }
        public Page page { get; set; }
    }

    #region Page
    public class Page
    {
        public int limit { get; set; }
        public int items { get; set; }
        public int current { get; set; }
        public int last { get; set; }
    }
    #endregion

    #region Products
    public class Products
    {
        public int id { get; set; }
        public string description { get; set; }
        public string full_name { get; set; }
        public string html_url { get; set; }
        public Images images { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public Prices prices { get; set; }
        public string review_url { get; set; }
        public Reviews reviews { get; set; }
        public string status { get; set; }
        public string url { get; set; }
    }

    public class Prices
    {
        public string currency_sign { get; set; }
        public string html_url { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public Offers offers { get; set; }
    }

    public class Reviews
    {
        public int count { get; set; }
        public string html_url { get; set; }
        public int rating { get; set; }
        public string url { get; set; }
    }

    public class Images
    {
        public string header { get; set; }
        public string icon { get; set; }
    }

    public class Offers
    {
        public int count { get; set; }
    }
    #endregion

}
