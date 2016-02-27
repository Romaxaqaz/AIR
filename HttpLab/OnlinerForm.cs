using Domain.Lab6.Romaxa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace HttpLab
{
    public partial class OnlinerForm : Form
    {
        private SearchRequest request = new SearchRequest();
        private string linkProducts = string.Empty;

        public OnlinerForm()
        {
            InitializeComponent();
            request.Progress += Request_Progress;
        }

        private void Request_Progress(AllProducts products)
        {
            listBox1.Items.Clear();
            var myProducts = products;
            foreach (var item in myProducts.products)
            {
                listBox1.Items.Add(item.name);
            }
        }

        private void ClearControls()
        {
            TitleLable.Text = "";
            DescriptionTextBox1.Text = "";
            currentLable.Text = "";
            currency_signLabel.Text = "";
            pictureBox1.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            request.Request(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            int x = 0;
            var list = request.ProductList;
            if (listBox1.SelectedItems.Count > 0)
            {
                x = listBox1.SelectedIndex;
            }
            var obj = list.products[x];
            var webClient = new WebClient();
            TitleLable.Text = obj.full_name;
            DescriptionTextBox1.Text = obj.description;
            currentLable.Text = obj.prices.max.ToString();
            currency_signLabel.Text = obj.prices.currency_sign;
            linkLabel1.Text = obj.name;
            linkProducts = obj.html_url;
            Image image = Image.FromStream(webClient.OpenRead(obj.images.header));
            pictureBox1.Image = image;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkProducts);
        }
    }
}
