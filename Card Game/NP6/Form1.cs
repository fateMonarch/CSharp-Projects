using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP6
{
    public partial class Form1 : Form
    {
        public int puan1 = 0;
        public int puan2 = 0;
        public int kontrol = 0;
        public string kart1 = "  ";
        public string kart2 = "  ";
        public string kart3 = "  ";
        public string kart4 = "  ";
        public string kart5 = "  ";
        public string kart6 = "  ";
        public string kart7 = "  ";
        public string kart8 = "  ";
        public string kart9 = "  ";
        Random rnd = new Random();

        public string image = "C:\\Users\\muham\\OneDrive\\Masaüstü\\B\\Pişti\\";
        public List<string> karts1 = new List<string>() {" ","1-Sinek","2-Sinek","3-Sinek",
        "4-Sinek","5-Sinek","6-Sinek","7-Sinek","8-Sinek","9-Sinek","10-Sinek","J-Sinek",
        "Q-Sinek","K-Sinek","1-Kupa","2-Kupa","3-Kupa","4-Kupa","5-Kupa","6-Kupa","7-Kupa",
        "8-Kupa","9-Kupa","10-Kupa","J-Kupa","Q-Kupa","K-Kupa","1-Karo","2-Karo","3-Karo",
        "4-Karo","5-Karo","6-Karo","7-Karo","8-Karo","9-Karo","10-Karo","J-Karo","Q-Karo",
        "K-Karo","1-Maça","2-Maça","3-Maça","4-Maça","5-Maça","6-Maça","7-Maça","8-Maça",
        "9-Maça","10-Maça","J-Maça","Q-Maça","K-Maça"};
        public List<string> karts2 = new List<string>() {" ", " ", " ", " ", " ", " ", " ",
        " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",
        " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",
        " "," "," "," "," "," ",};
        public List<string> karts3 = new List<string>() { };
        public List<string> karts4 = new List<string>() { };
        public List<string> karts5 = new List<string>() { };

        public Form1()
        {
            InitializeComponent();
            this.Text = "Pişti";
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Kart_Dagıt();
        }

        public void Kart_Dagıt()
        {
            if (kontrol == 48)
            {
                string point1 = null;
                string point2 = null;
                int points1 = 0;
                int points2 = 0;

                for (int i = 0; i < karts4.Count; i++)
                {
                    if (karts4[i].Substring(0, 2) == "10" || karts4[i].Substring(0, 1) == "J" ||
                        karts4[i].Substring(0, 1) == "Q" || karts4[i].Substring(0, 1) == "K")
                        puan1 += 10;

                    else if (karts5[i].Substring(0, 1) != "")
                    {
                        point1 = karts4[i].Substring(0, 1);
                        points1 = Convert.ToInt32(point1);
                        puan1 += points1;
                    }
                }             

                for (int i = 0; i < karts5.Count; i++)
                {
                    if (karts5[i].Substring(0, 2) == "10" || karts5[i].Substring(0, 1) == "J" ||
                        karts5[i].Substring(0, 1) == "Q" || karts5[i].Substring(0, 1) == "K")
                        puan2 += 10;

                    else if (karts5[i].Substring(0, 1) != "")
                    {
                        point2 = karts5[i].Substring(0, 1);
                        points2 = Convert.ToInt32(point2);
                        puan2 += points2;
                    }
                }
                    
                DialogResult sonuc = MessageBox.Show("Oyun bitti.\n\nPlayer 1'in puanı= "+puan1+" \n\nPlayer 2'nin puanı= "+puan2+".",
                    "Son", MessageBoxButtons.OK,MessageBoxIcon.Information);

                if (sonuc == DialogResult.OK)
                {
                    this.Close();
                    Application.Exit();
                }
            }

            int sayi1 = 0;
            while (karts2.Contains(karts1[sayi1]) == true)
                sayi1 = rnd.Next(1, 53);

            kart1 = karts1[sayi1];
            karts2.Add(kart1);
            kontrol++;
            pictureBox1.Image = Image.FromFile(@image + kart1 + ".PNG");

            int sayi2 = 0;
            while (karts2.Contains(karts1[sayi2]) == true)
                sayi2 = rnd.Next(1, 53);

            kart2 = karts1[sayi2];
            karts2.Add(kart2);
            kontrol++;
            pictureBox2.Image = Image.FromFile(@image + kart2 + ".PNG");

            int sayi3 = 0;
            while (karts2.Contains(karts1[sayi3]) == true)
                sayi3 = rnd.Next(1, 53);

            kart3 = karts1[sayi3];
            karts2.Add(kart3);
            kontrol++;
            pictureBox3.Image = Image.FromFile(@image + kart3 + ".PNG");

            int sayi4 = 0;
            while (karts2.Contains(karts1[sayi4]) == true)
                sayi4 = rnd.Next(1, 53);

            kart4 = karts1[sayi4];
            karts2.Add(kart4);
            kontrol++;
            pictureBox4.Image = Image.FromFile(@image + kart4 + ".PNG");

            int sayi6 = 0;
            while (karts2.Contains(karts1[sayi6]) == true)
                sayi6 = rnd.Next(1, 53);

            kart6 = karts1[sayi6];
            karts2.Add(kart6);
            kontrol++;
            pictureBox6.Image = Image.FromFile(@image + kart6 + ".PNG");

            int sayi7 = 0;
            while (karts2.Contains(karts1[sayi7]) == true)
                sayi7 = rnd.Next(1, 53);

            kart7 = karts1[sayi7];
            karts2.Add(kart7);
            kontrol++;
            pictureBox7.Image = Image.FromFile(@image + kart7 + ".PNG");

            int sayi8 = 0;
            while (karts2.Contains(karts1[sayi8]) == true)
                sayi8 = rnd.Next(1, 53);

            kart8 = karts1[sayi8];
            karts2.Add(kart8);
            kontrol++;
            pictureBox8.Image = Image.FromFile(@image + kart8 + ".PNG");

            int sayi9 = 0;
            while (karts2.Contains(karts1[sayi9]) == true)
                sayi9 = rnd.Next(1, 53);

            kart9 = karts1[sayi9];
            karts2.Add(kart9);
            kontrol++;
            pictureBox9.Image = Image.FromFile(@image + kart9 + ".PNG");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            if (kart1.Substring(0,2)==kart5.Substring(0,2) || kart1.Substring(0,1)=="J")
            {
                karts3.Add(kart1);
                karts3.Add(kart5);
                for (int i=0;i<karts3.Count;i++)
                {
                    karts4.Add(karts3[i]);
                    if (listBox1.Items.Contains(karts3[i]) == false)
                        listBox1.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox1.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox1.Image;
                pictureBox1.Image = null;
                kart5 = kart1;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (kart2.Substring(0, 2) == kart5.Substring(0, 2) || kart2.Substring(0, 1) == "J")
            {
                karts3.Add(kart2);
                karts3.Add(kart5);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts4.Add(karts3[i]);
                    if (listBox1.Items.Contains(karts3[i]) == false)
                        listBox1.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox2.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox2.Image;
                pictureBox2.Image = null;
                kart5 = kart2;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (kart3.Substring(0,2) == kart5.Substring(0, 2) || kart3.Substring(0, 1) == "J")
            {
                karts3.Add(kart3);
                karts3.Add(kart5);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts4.Add(karts3[i]);
                    if (listBox1.Items.Contains(karts3[i]) == false)
                        listBox1.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox3.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox3.Image;
                pictureBox3.Image = null;
                kart5 = kart3;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (kart4.Substring(0, 2) == kart5.Substring(0, 2) || kart4.Substring(0, 1) == "J")
            {
                karts3.Add(kart4);
                karts3.Add(kart5);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts4.Add(karts3[i]);
                    if (listBox1.Items.Contains(karts3[i]) == false)
                        listBox1.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox4.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox4.Image;
                pictureBox4.Image = null;
                kart5 = kart4;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (kart6.Substring(0, 2) == kart5.Substring(0, 2) || kart6.Substring(0, 1) == "J")
            {
                karts3.Add(kart5);
                karts3.Add(kart6);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts5.Add(karts3[i]);
                    if (listBox2.Items.Contains(karts3[i]) == false)
                        listBox2.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox6.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox6.Image;
                pictureBox6.Image = null;
                kart5 = kart6;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (kart7.Substring(0, 2) == kart5.Substring(0, 2) || kart7.Substring(0, 1) == "J")
            {
                karts3.Add(kart5);
                karts3.Add(kart7);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts5.Add(karts3[i]);
                    if (listBox2.Items.Contains(karts3[i]) == false)
                        listBox2.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox7.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox7.Image;
                pictureBox7.Image = null;
                kart5 = kart7;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (kart8.Substring(0, 2) == kart5.Substring(0, 2) || kart8.Substring(0, 1) == "J")
            {
                karts3.Add(kart5);
                karts3.Add(kart8);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts5.Add(karts3[i]);
                    if (listBox2.Items.Contains(karts3[i]) == false)
                        listBox2.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox8.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox8.Image;
                pictureBox8.Image = null;
                kart5 = kart8;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (kart9.Substring(0, 2) == kart5.Substring(0, 2) || kart9.Substring(0, 1) == "J")
            {
                karts3.Add(kart5);
                karts3.Add(kart9);
                for (int i = 0; i < karts3.Count; i++)
                {
                    karts5.Add(karts3[i]);
                    if (listBox2.Items.Contains(karts3[i]) == false)
                        listBox2.Items.Add(karts3[i]);
                }

                karts3.Clear();
                kart5 = "  ";
                pictureBox9.Image = null;
                pictureBox5.Image = null;
            }

            else
            {
                pictureBox5.Image = pictureBox9.Image;
                pictureBox9.Image = null;
                kart5 = kart9;
                karts3.Add(kart5);
            }

            if (pictureBox1.Image == null && pictureBox2.Image == null && pictureBox3.Image == null &&
                pictureBox4.Image == null && pictureBox6.Image == null && pictureBox7.Image == null &&
                pictureBox8.Image == null && pictureBox9.Image == null)
                Kart_Dagıt();
        }
    }
}
