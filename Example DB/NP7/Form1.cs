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

namespace NP7
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
            dataGridView1.Visible = false;
            comboBox1.Items.Add("Seçiniz");
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            string query = " ";
            if(radioButton1.Checked==true)
                query = "INSERT INTO Ogrenciler VALUES('" + textBox1.Text + "'," + 
                    comboBox1.Text + ",'" + radioButton1.Text + "')";

            else
                query = "INSERT INTO Ogrenciler VALUES('" + textBox1.Text +
                    "'," + comboBox1.Text + ",'" + radioButton2.Text + "')";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eklendi!");
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("Ad Soyad");
            dt.Columns.Add("Sınıf");
            dt.Columns.Add("Cinsiyet");
            SqlConnection conn = new SqlConnection(ConnStr);
            string query = "SELECT AdSoyad,Sinif,Cinsiyet FROM Ogrenciler;";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = reader[0].ToString();
                    dr[1] = reader[1].ToString();
                    dr[2] = reader[2].ToString();
                    dt.Rows.Add(dr);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("HATA!");
            }

            conn.Close();
            dataGridView1.DataSource = dt;
        }
    }
}
