using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Domain.Lab6.JFF;

namespace HttpLab
{
    internal sealed partial class Aform : Form
    {
        private Translator translator;

        public Aform()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            translator = new Translator(OnLanguagesArrive, OnTranslationArrive);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = richTextBox1.Text;
            if (Regex.IsMatch(text, @"^\s*$")) return;

            translator.Translate(richTextBox1.Text,comboBox1.SelectedItem.ToString());

        }

        private void OnLanguagesArrive(object obj)
        {
            var variants = obj.ToString().Split(',');
            comboBox1.Invoke(new ReqestAccepted(l =>
            {
                var items = l as string[];
                const string defaultValue = "en-ru";
                comboBox1.Items.AddRange(items ?? new object[0]);
                if (variants.Contains(defaultValue))
                {
                    comboBox1.SelectedItem = defaultValue;
                }
            }), new[] {variants});
        }

        private void OnTranslationArrive(object obj)
        {
            richTextBox2.Invoke(new ReqestAccepted(o =>
            {
                richTextBox2.Text = obj.ToString();
            }), new[] {obj});
        }
    }
}
