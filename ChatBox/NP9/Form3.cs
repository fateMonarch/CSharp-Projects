using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Layout;
using System.Windows.Forms.VisualStyles;
using System.Data.SqlClient;
using System.Windows.Markup;
using System.Windows.Input;
using System.Windows.Forms.Automation;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms.PropertyGridInternal;

namespace NP9
{
    public partial class Form3 : Form
    {
        string ConnStr = "Server=(localdb)\\MSSQLLocalDB;Database=Ornek;Trusted_Connection=True;";
        string _Mail, _Code, image; int _Arkadas;
        List<int> Liste1 = new List<int> { };

        public Form3(string Mail, string Code)
        {
            _Code = Code;
            _Mail = Mail;   
            InitializeComponent();
        }

        public void ArkadasGuncelle()
        {
            Liste1.Clear();
            listBox1.Items.Clear();
            SqlConnection conn1 = new SqlConnection(ConnStr);
            string query1 = "SELECT Arkadaşı FROM Friends WHERE Kişi= " + _Code + ";";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);

            try
            {
                conn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    Liste1.Add(reader1.GetInt32(0));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn1.Close();

            for (int i = 0; i <Liste1.Count; i++)
            {
                SqlConnection conn2 = new SqlConnection(ConnStr);
                string query2 = "SELECT Name FROM Hesap WHERE Code= " + Liste1[i] + ";";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);

                try
                {
                    conn2.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        listBox1.Items.Add(reader2[0]);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn2.Close();
            }
        }

        public void MessageGuncelle()
        {
            listBox2.Items.Clear();
            SqlConnection conn1 = new SqlConnection(ConnStr);
            string query1 = "SELECT Code FROM Hesap WHERE Name= '"
                + listBox1.SelectedItem.ToString() + "';";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);

            try
            {
                conn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    _Arkadas = reader1.GetInt32(0);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn1.Close();

            string Tarih = "";
            SqlConnection conn2 = new SqlConnection(ConnStr);
            string query2 = "SELECT Message, Veren, Tarih, Zaman FROM Message WHERE (Veren= " + _Code
                + " AND Alan= " + _Arkadas + " ) OR ( Veren= " + _Arkadas + " AND Alan= " 
                + _Code + " );";
            SqlCommand cmd2 = new SqlCommand(query2, conn2);

            try
            {
                conn2.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    Tarih = reader2[2].ToString();
                    if (listBox2.Items.Contains("                                        " + Tarih.Substring(0,10)) == false)
                    {
                        listBox2.Items.Add("                                        " + Tarih.Substring(0, 10));
                    }

                    if (reader2[1].ToString() == _Code)
                    {
                        string boslukk = " ";
                        int kontrol = 0;

                        if(reader2[0].ToString().Trim().Length > 30)
                        {
                            for (int i = 0; i < 67 - reader2[0].ToString().Trim().Length; i++)
                            {
                                kontrol++;
                                if (kontrol == 2)
                                {
                                    boslukk += " ";
                                    kontrol = 0;
                                }
                            }
                        }

                        else
                        {
                            for (int i = 0; i < 67 - reader2[0].ToString().Trim().Length; i++)
                            {
                                boslukk += " ";
                                kontrol++;
                                if (kontrol == 15)
                                {
                                    boslukk += " ";
                                    kontrol = 0;
                                }
                            }
                        }
                        listBox2.Items.Add(boslukk + "[" + reader2[3].ToString() + "]  " + reader2[0].ToString());
                    }

                    else
                    {
                        listBox2.Items.Add(reader2[0].ToString() + "  [" + reader2[3].ToString() + "]");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn2.Close();
        }

        public void IsimResimGuncelle()
        {
            SqlConnection conn1 = new SqlConnection(ConnStr);
            string query1 = "SELECT Name, Picture FROM Hesap WHERE Code= " + _Code + ";";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);

            try
            {
                conn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    label4.Text = "İsim= " + reader1[0].ToString().Trim();
                    pictureBox2.ImageLocation = reader1[1].ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kontrol2 = 0;
            SqlConnection conn1 = new SqlConnection(ConnStr);
            string query1 = "SELECT Arkadaşı FROM Friends WHERE Kişi= " + _Code + ";";
            SqlCommand cmd1 = new SqlCommand(query1, conn1);

            try
            {
                conn1.Open();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.GetInt32(0) == Convert.ToInt32(maskedTextBox1.Text))
                        kontrol2++;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn1.Close();

            if (kontrol2 == 0)
            {
                SqlConnection conn2 = new SqlConnection(ConnStr);
                string query2 = "INSERT INTO Friends VALUES(" + _Code
                    + ", " + maskedTextBox1.Text + ");";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);

                try
                {
                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Yeni arkadaş eklendi!", "Yeni arkadaş?",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn2.Close();
            }

            else
            {
                MessageBox.Show("Bu kişiyi önceden arkadaş eklemişsiniz!", "Hata!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }               
            ArkadasGuncelle();
            IsimResimGuncelle();
            maskedTextBox1.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                pictureBox1.Visible = true;
                maskedTextBox2.Visible = true;
                button2.Visible = true;
                listBox2.Visible = true;
                label3.Visible = true;
                MessageGuncelle();
                IsimResimGuncelle();

                SqlConnection conn1 = new SqlConnection(ConnStr);
                string query1 = "SELECT Picture FROM Hesap WHERE Code= " + _Arkadas + ";";
                SqlCommand cmd1 = new SqlCommand(query1, conn1);

                try
                {
                    conn1.Open();
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        pictureBox1.ImageLocation = reader1[0].ToString();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn1.Close();
                label3.Text = "İsim= " + listBox1.SelectedItem.ToString().Trim();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text.ToString().Length > 66)
            {
                MessageBox.Show("Bu kadar büyük bir yazıyı yollayamazsınız!", "Hata!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                

            else
            {
                SqlConnection conn2 = new SqlConnection(ConnStr);
                string query2 = "INSERT INTO Message VALUES(" + _Code + ", " + _Arkadas
                    + ",'" + maskedTextBox2.Text + "' ,'" + DateTime.Now.ToLocalTime().ToString() + "' ,'"
                    + DateTime.Now.ToString().Substring(11, 5) + "');";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);

                try
                {
                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn2.Close();
            }

            MessageGuncelle();
            IsimResimGuncelle();
            maskedTextBox2.Text = null;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems == null)
            {
                MessageBox.Show("Arkadaş listenizde seçili biri yok!", "Hata!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlConnection conn2 = new SqlConnection(ConnStr);
                string query2 = "DELETE FROM Friends WHERE Arkadaşı= " + _Arkadas + ";";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);

                try
                {
                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn2.Close();

                SqlConnection conn3 = new SqlConnection(ConnStr);
                string query3 = "DELETE Message FROM Message WHERE (Veren= " + _Code
                + " AND Alan= " + _Arkadas + " ) OR ( Veren= " + _Arkadas + " AND Alan= "
                + _Code + " );";
                SqlCommand cmd3 = new SqlCommand(query3, conn3);

                try
                {
                    conn3.Open();
                    cmd3.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn3.Close();
            }

            listBox2.Visible = false;
            pictureBox1.Visible = false;
            maskedTextBox2.Visible = false;
            button2.Visible = false;
            label3.Visible = false;
            ArkadasGuncelle();
            IsimResimGuncelle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(_Mail, _Code, image);
            f4.ShowDialog();
            IsimResimGuncelle();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox2.Visible = false;
            pictureBox1.Visible = false;
            maskedTextBox2.Visible = false;
            button2.Visible = false;
            ArkadasGuncelle();
            IsimResimGuncelle();
        }
    }
}
