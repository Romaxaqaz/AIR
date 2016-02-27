using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace HttpLab
{
    public partial class GreyWardenForm : Form
    {
        private static readonly string url = "http://uk.shopping.com/ajaxSearchAssistant?q=";
        private static readonly HttpClient httpClient;

        static GreyWardenForm()
        {
            httpClient = new HttpClient();
        }

        public GreyWardenForm()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var searchUrl = url + this.TextBoxSearch.Text;
            var xml = Task.Run(() => this.GetRespone(searchUrl)).Result;
            var results = XDocument.Parse(xml).Descendants("S").Select(x => x.Value);
            this.ListBoxResults.DataSource = results.ToList();
        }

        private async Task<string> GetRespone(string url)
        {
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
