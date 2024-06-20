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
    public partial class Form4 : Form
    {
        string ConnStr = "Server=(localdb)\\MSSQLLocalDB;Database=Ornek;Trusted_Connection=True;";
        string _image = "";
        string Mmail, Ccode;

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                SqlConnection conn1 = new SqlConnection(ConnStr);
                string query1 = "UPDATE Hesap SET Name= '" + maskedTextBox1.Text +
                    "' WHERE Code= " + Ccode + ";";
                SqlCommand cmd1 = new SqlCommand(query1, conn1);

                try
                {
                    conn1.Open();
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("İsminiz başarıyla değiştirildi!", "İsim değişimi?",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn1.Close();

                maskedTextBox1.Text = null;
                SqlConnection conn2 = new SqlConnection(ConnStr);
                string query2 = "SELECT Name FROM Hesap WHERE Code= " + Ccode + ";";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);

                try
                {
                    conn2.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        label2.Text = "İsim= " + reader2[0].ToString().Trim();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn2.Close();              
            }

            else
            {
                MessageBox.Show("İsminiz tamamıyla boşluk olamaz!", "Hata!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            _image = pictureBox1.ImageLocation;

            SqlConnection conn1 = new SqlConnection(ConnStr);
            string query1 = "UPDATE Hesap SET Picture= '" + _image + "' WHERE Code= " +
               Ccode + ";";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);

            try
            {
                conn1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Resminiz değiştirildi!", "Yeni resim?",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn1.Close();
        }

        public Form4(string _Mail, string _Code, string _image)
        {
            Mmail = _Mail;
            Ccode = _Code;  
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = "Arkadaşlık Kodunuz= " + Ccode;
            SqlConnection conn1 = new SqlConnection(ConnStr);
            string query1 = "SELECT Name, Picture FROM Hesap WHERE Code= " + Ccode + ";";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);

            try
            {
                conn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    label2.Text = "İsim= " + reader1[0].ToString().Trim();
                    pictureBox1.ImageLocation = reader1[1].ToString();  
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn1.Close();
        }
    }
}
