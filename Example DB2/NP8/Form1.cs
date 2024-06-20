using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP8
{
    public partial class Form1 : Form
    {
        string ConnStr = "Server=(localdb)\\MSSQLLocalDB;Database=Ornek;Trusted_Connection=True;";
        static DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();
        public int kontrol;

        public Form1()
        {
            InitializeComponent();
        }

        public void KisiEkle()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            string query = "INSERT INTO Tabloo VALUES('" + Convert.ToString(maskedTextBox1.Text) + "','" + maskedTextBox2.Text + "','" +
                maskedTextBox3.Text + "','" + Convert.ToString(maskedTextBox4.Text) + "','" + maskedTextBox5.Text + "','" + comboBox1.Text +
                "','" + comboBox2.Text + "','" + richTextBox1.Text + "');";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eklendi!","Ekleme?",MessageBoxButtons.OK);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void KisiSil()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            string query = "DELETE FROM Tabloo WHERE TC='"+Convert.ToString(maskedTextBox1.Text)+"';";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Silindi!", "Silme?", MessageBoxButtons.OK);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        public void KisiGüncelle()
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            string query = " UPDATE Tabloo SET TC='"+Convert.ToString(maskedTextBox1.Text)+"', Ad= '"+maskedTextBox2.Text+"', Soyad='" +
               maskedTextBox3.Text+ "', Telefon='"+Convert.ToString(maskedTextBox4.Text)+"', Mail='"+maskedTextBox5.Text+"', Sehir='"+
               comboBox1.Text+"', Ilce='"+ comboBox2.Text+"', Adres='"+richTextBox1.Text+"' WHERE TC='"+Convert.ToString(maskedTextBox1.Text)+"';";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Güncellendi!", "Güncelle?", MessageBoxButtons.OK);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Seçiniz!");
            comboBox1.Text = "Seçiniz!";
            comboBox2.Text = "Seçiniz!";

            SqlConnection conn = new SqlConnection(ConnStr);
            string query = "SELECT Sehir FROM Sehir;";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));  
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Seçiniz!");
            comboBox2.Text = "Seçiniz!";

            SqlConnection conn = new SqlConnection(ConnStr);
            string query = "SELECT Ilce FROM Ilce WHERE il_ID="+comboBox1.SelectedIndex+";";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0].ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == null || maskedTextBox2.Text == null ||
                maskedTextBox3.Text == null || maskedTextBox4.Text == null ||
                maskedTextBox5.Text == null || comboBox1.Text == "Seçiniz!" ||
                comboBox2.Text == "Seçiniz!" || richTextBox1.Text == null)
                MessageBox.Show("Boşluklardan birini boş bıraktınız veya hatalı doldurdunuz!",
                    "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                SqlConnection conn = new SqlConnection(ConnStr);
                string query = "SELECT TC FROM Tabloo;";
                SqlCommand cmd = new SqlCommand(query, conn);
                kontrol = 0;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        if (Convert.ToString(maskedTextBox1.Text) == reader.GetString(0))
                            kontrol++;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();

                if (kontrol != 0)
                    MessageBox.Show("Bu TC Kimliğine sahip biri zaten var.", "Hata!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                    KisiEkle();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == null)
                MessageBox.Show("Boşluklardan birini boş bıraktınız veya hatalı doldurdunuz!",
                    "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                SqlConnection conn = new SqlConnection(ConnStr);
                string query = "SELECT TC FROM Tabloo;";
                SqlCommand cmd = new SqlCommand(query, conn);
                kontrol = 0;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        if (Convert.ToString(maskedTextBox1.Text) == reader.GetString(0))
                        {
                            KisiSil();
                            kontrol++;
                        }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();

                if (kontrol == 0)
                    MessageBox.Show("Bu TC Kimliğine sahip biri yok.", "Hata!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == null || maskedTextBox2.Text == null ||
               maskedTextBox3.Text == null || maskedTextBox4.Text == null ||
               maskedTextBox5.Text == null || comboBox1.Text == "Seçiniz!" ||
               comboBox2.Text == "Seçiniz!" || richTextBox1.Text == null)
                MessageBox.Show("Boşluklardan birini boş bıraktınız veya hatalı doldurdunuz!",
                    "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                SqlConnection conn = new SqlConnection(ConnStr);
                string query = "SELECT TC FROM Tabloo;";
                SqlCommand cmd = new SqlCommand(query, conn);
                kontrol = 0;

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        if (Convert.ToString(maskedTextBox1.Text) == reader.GetString(0))
                        {
                            KisiGüncelle();
                            kontrol++;
                        }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();

                if (kontrol == 0)
                    MessageBox.Show("Bu TC Kimliğine sahip biri yok.", "Hata!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(maskedTextBox6.Text==null)
                MessageBox.Show("Boşluklardan birini boş bıraktınız veya hatalı doldurdunuz!",
                    "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                dt.Columns.Clear();
                dt.Columns.Add("TC");
                dt.Columns.Add("Ad");
                dt.Columns.Add("Soyad");
                dt.Columns.Add("Telefon");
                dt.Columns.Add("Mail");
                dt.Columns.Add("Sehir");
                dt.Columns.Add("Ilce");
                dt.Columns.Add("Adres");
                SqlConnection conn = new SqlConnection(ConnStr);
                string query = "SELECT TC, Ad, Soyad, Telefon, Mail, Sehir, Ilce, Adres FROM Tabloo WHERE TC='" + maskedTextBox6.Text +"';";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dr[0] = reader[0].ToString();
                        dr[1] = reader[1].ToString();
                        dr[2] = reader[2].ToString();
                        dr[3] = reader[3].ToString();
                        dr[4] = reader[4].ToString(); 
                        dr[5] = reader[5].ToString();
                        dr[6] = reader[6].ToString();
                        dr[7] = reader[7].ToString();
                        dt.Rows.Add(dr);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
                dataGridView1.DataSource = dt;
            }
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[0].Cells[0].Selected == true)
            {
                maskedTextBox1.Text = dr[0].ToString();
                maskedTextBox2.Text = dr[1].ToString();
                maskedTextBox3.Text = dr[2].ToString();
                maskedTextBox4.Text = dr[3].ToString();
                maskedTextBox5.Text = dr[4].ToString();
                comboBox1.Text = dr[5].ToString();
                comboBox2.Text = dr[6].ToString();
                richTextBox1.Text = dr[7].ToString();         
            }
        }
    }
}
