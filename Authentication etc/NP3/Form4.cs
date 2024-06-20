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
    public partial class Form4 : Form
    {
        string number, isim;
        public Form4(string ogrenci_no, string ad_soyad)
        {
            number = ogrenci_no;
            isim = ad_soyad;
            InitializeComponent();
            this.Text = "Ana Sayfa";
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "Öğrenci No: " + number;
            label2.Text = "Ad Soyad: " + isim;
        }
    }
}
