using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace iktprojekt
{
    public partial class Form3 : Form
    {


        string connString = "server=localhost;port=3306;database=ovs;user=root;password=";
        public Form3()
        {
            InitializeComponent();
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // asd
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text.Trim(); // ez a username is egyben
            string lastname = textBox4.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmpassword = textBox3.Text.Trim();

            if (firstname == "" || lastname == "" || password == "" || confirmpassword == "")
            {
                MessageBox.Show("Tölts ki minden mezőt.");
                return;
            }
            else if (password != confirmpassword)
            {
                MessageBox.Show("A két jelszó nem egyezik.");
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

                        string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @uname";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@uname", firstname.ToLower());

                        int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            MessageBox.Show("Ez a felhasználónév már foglalt. Válassz másikat.");
                            return;
                        }

                        string insertQuery = "INSERT INTO users(username, password, first_name, last_name) VALUES (@uname, @password, @fname, @lname)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@uname", firstname.ToLower());
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@fname", firstname);
                        insertCmd.Parameters.AddWithValue("@lname", lastname);

                        int status = insertCmd.ExecuteNonQuery();

                        if (status > 0)
                        {
                            MessageBox.Show("Fiók létrehozva.");
                            new Form2().Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba: " + ex.Message);
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text.Trim(); // ez a username is egyben
            string lastname = textBox4.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmpassword = textBox3.Text.Trim();

            if (firstname == "" || lastname == "" || password == "" || confirmpassword == "")
            {
                MessageBox.Show("Tölts ki minden mezőt.");
                return;
            }
            else if (password != confirmpassword)
            {
                MessageBox.Show("A két jelszó nem egyezik.");
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

                        string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @uname";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@uname", firstname.ToLower());

                        int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            MessageBox.Show("Ez a felhasználónév már foglalt. Válassz másikat.");
                            return;
                        }

                        string insertQuery = "INSERT INTO users(username, password, first_name, last_name) VALUES (@uname, @password, @fname, @lname)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@uname", firstname.ToLower());
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@fname", firstname);
                        insertCmd.Parameters.AddWithValue("@lname", lastname);

                        int status = insertCmd.ExecuteNonQuery();

                        if (status > 0)
                        {
                            MessageBox.Show("Fiók létrehozva.");
                            new Form2().Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba: " + ex.Message);
                }
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }
    }
}