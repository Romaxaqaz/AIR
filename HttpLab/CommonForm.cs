using System;
using System.Windows.Forms;

namespace HttpLab
{
    public partial class CommonForm : Form
    {
        public CommonForm()
        {
            InitializeComponent();
        }

        private void BtnGreyWarden_Click(object sender, EventArgs e)
        {
            var greyWardenForm = new GreyWardenForm();
            greyWardenForm.Show(this);
        }

        private void BtnAnton_Click(object sender, EventArgs e)
        {
            var aform = new Aform();
            aform.Show();
        }

        private void BtnRomaxa_Click(object sender, EventArgs e)
        {
            var onlinerRomaxa = new OnlinerForm();
            onlinerRomaxa.Show();
        }
    }
}
