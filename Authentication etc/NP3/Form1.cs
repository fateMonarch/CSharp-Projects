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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Pazar";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedItems.Contains(listBox1.Items[i]))
                {
                    listBox2.Items.Add(listBox1.Items[i]);
                    listBox1.Items.Remove(listBox1.Items[i]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (listBox2.SelectedItems.Contains(listBox2.Items[i]))
                {
                    listBox1.Items.Add(listBox2.Items[i]);
                    listBox2.Items.Remove(listBox2.Items[i]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double toplam = 0;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
               for(int j=0; j < listBox2.Items[i].ToString().Length; j++)
               {
                    if (listBox2.Items[i].ToString().Substring(j,1) == "-")
                    {
                        toplam += double.Parse(listBox2.Items[i].ToString().Substring(j+1,5));
                    }
               }
            }
            textBox2.Text = Convert.ToString(toplam)+" TL";
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                textBox1.Text = "";
            }
            else
            {
                 for (int i = 0; i < listBox2.Items[listBox2.SelectedIndex].ToString().Length; i++)
                 {
                      if (listBox2.Items[listBox2.SelectedIndex].ToString().Substring(i, 1) == "-")
                      {
                            textBox1.Text = listBox2.Items[listBox2.SelectedIndex].ToString().Substring(i+2, 5)+" TL";
                      }
                 }
            }
        }
    }
}
