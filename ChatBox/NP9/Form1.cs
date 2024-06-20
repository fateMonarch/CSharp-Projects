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
    public partial class Form1 : Form
    {
        string ConnStr = "Server=(localdb)\\MSSQLLocalDB;Database=Ornek;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" && maskedTextBox2.Text == "")
            {
                DialogResult result1 = MessageBox.Show("E-mail ve Şifre kısmını boş bıraktınız. Hesabınız mı yok?",
                    "Yeni hesap açalım?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result1 == DialogResult.Yes)
                {
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
            }

            else if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "")
            {
                MessageBox.Show("Eksik veya boş bıraktığınız yerler var!", "Hata!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int kontrol1 = 0;
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
                            kontrol1++;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn1.Close();

                if(kontrol1 == 1)
                {
                    string Mail = "";
                    string Name = "";
                    string Code = "";

                    SqlConnection conn2 = new SqlConnection(ConnStr);
                    string query2 = "SELECT Mail, Name, Code FROM Hesap WHERE Mail='" + maskedTextBox1.Text + "';";
                    SqlCommand cmd2 = new SqlCommand(query2, conn2);

                    try
                    {
                        conn2.Open();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            Mail = reader2[0].ToString();
                            Name = reader2[1].ToString();
                            Code = reader2[2].ToString();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn2.Close();

                    SqlConnection conn3 = new SqlConnection(ConnStr);
                    string query3 = "SELECT Password FROM Hesap WHERE Mail='" + maskedTextBox1.Text + "';";
                    SqlCommand cmd3 = new SqlCommand(query3, conn3);

                    try
                    {
                        conn3.Open();
                        SqlDataReader reader3 = cmd3.ExecuteReader();
                        while (reader3.Read())
                        {
                            if (reader3[0].ToString() == maskedTextBox2.Text)
                            {
                                Form3 f3 = new Form3(Mail, Code);
                                f3.ShowDialog();
                            }

                            else
                            {
                                MessageBox.Show("E-Mail veya şifreyi girerken hata yaptınız!",
                                    "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }                
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn3.Close();
                }

                else
                {
                    MessageBox.Show("E-Mail veya şifreyi girerken hata yaptınız!","Hata!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();        
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }
    }
}
