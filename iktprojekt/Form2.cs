using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace iktprojekt
{
    public partial class Form2 : Form
    {
        string connString = "server=localhost;port=3306;database=ovs;user=root;password=";

        public Form2()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("nevet és jelszót kötelezö megadni!");
                return;
            }
            else
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    using (conn)
                    {
                        conn.Open();
                        string query = "SELECT username, password FROM users WHERE username=@uname AND password=@password LIMIT 1";
                        MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
                        ada.SelectCommand.Parameters.AddWithValue("@uname", username);
                        ada.SelectCommand.Parameters.AddWithValue("@password", password);

                        DataTable table = new DataTable();
                        ada.Fill(table);
                        
                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Sikeres bejelentkezés");
                            conn.Close();
                            new Form1().Show();
                            this.Hide();

                            MessageBox.Show($"Üdvözöljük, {username}");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Hibás bejelentkezési adatok!");
                            conn.Close(); 
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Siticone.Desktop.UI.WinForms.SiticoneButton btn)
                {
                    btn.FillColor = Color.DodgerBlue;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }



        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("nevet és jelszót kötelezö megadni!");
                return;
            }
            else
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    using (conn)
                    {
                        conn.Open();
                        string query = "SELECT username, password FROM users WHERE username=@uname AND password=@password LIMIT 1";
                        MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
                        ada.SelectCommand.Parameters.AddWithValue("@uname", username);
                        ada.SelectCommand.Parameters.AddWithValue("@password", password);

                        DataTable table = new DataTable();
                        ada.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Sikeres bejelentkezés");
                            conn.Close();
                            new Form1().Show();
                            this.Hide();

                            MessageBox.Show($"Üdvözöljük, {username}");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Hibás bejelentkezési adatok!");
                            conn.Close();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }


        }

        private void siticoneButton2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }
    }
}
