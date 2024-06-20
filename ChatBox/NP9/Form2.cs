using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NP9
{
    public partial class Form2 : Form
    {
        string ConnStr = "Server=(localdb)\\MSSQLLocalDB;Database=Ornek;Trusted_Connection=True;";
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || 
                maskedTextBox3.Text == "" || maskedTextBox4.Text == "")
            {
                MessageBox.Show("Eksik veya boş bıraktığınız yerler var!","Hata!",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else if (maskedTextBox1.Text.Contains("@") != true)
            {
                MessageBox.Show("Hatalı E-Mail girdiniz!", "Hata!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (maskedTextBox1.Text.Substring(maskedTextBox1.Text.IndexOf("@"), maskedTextBox1.Text.Length - maskedTextBox1.Text.IndexOf("@")).Contains(".com") != true)
            {
                MessageBox.Show("Hatalı E-Mail girdiniz!", "Hata!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (maskedTextBox3.Text != maskedTextBox4.Text)
            {
                MessageBox.Show("Şifreyi yeniden yazarken hata yaptınız!","Hata!",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else
            {
                int kontrol = 0;
                SqlConnection conn1 = new SqlConnection(ConnStr);
                string query1 = "SELECT Mail FROM Hesap;";
                SqlCommand cmd1 = new SqlCommand(query1, conn1);

                try
                {
                    conn1.Open();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1[0].ToString() == maskedTextBox1.Text)
                            kontrol++;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn1.Close();

                if (kontrol == 0)
                {
                    int sayi1 = 112462;
                    SqlConnection conn2 = new SqlConnection(ConnStr);
                    string query2 = "SELECT Code FROM Hesap;";
                    SqlCommand cmd2 = new SqlCommand(query2, conn2);

                    try
                    {
                        conn2.Open();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            while (reader2[0].ToString() == sayi1.ToString())
                            {
                                Random rnd = new Random();
                                sayi1 = rnd.Next(100000, 1000000);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn2.Close();

                    SqlConnection conn3 = new SqlConnection(ConnStr);
                    string query3 = "INSERT INTO Hesap VALUES('" + maskedTextBox1.Text + 
                        "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + 
                        "'," + sayi1.ToString() + ",'C:\\Users\\muham\\OneDrive\\Masaüstü\\D\\DD2\\Nesneye Yönelik Programlama\\Yeni.JPG');";
                    SqlCommand cmd3 = new SqlCommand(query3, conn3);

                    try
                    {
                        conn3.Open();
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Yeni hesap kuruldu!", "Yeni hesap?",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn3.Close();
                }

                else
                {
                    MessageBox.Show("Aynı mail hesabıyla birden fazla hesap açamazsınız!",
                        "Hata!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }      
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
