using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Kuzem Giriş";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ogrenci_no = textBox1.Text;
            string ad_soyad = textBox2.Text;

            Form4 f4 = new Form4(ogrenci_no, ad_soyad);
            f4.ShowDialog();
        }
    }
}
