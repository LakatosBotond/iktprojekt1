using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iktprojekt
{
    public partial class Form3 : Form
    {
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
            this.Hide();
            new Form2().Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string nev = textBox1.Text.Trim();
            string jelszo = textBox2.Text.Trim();
            string jelszo2 = textBox3.Text.Trim();

            if(nev == "" ||  jelszo == "" || jelszo2 == "")
            {
                MessageBox.Show("Minden mezöt tölts ki!");
                return;
            }else if (jelszo != jelszo2)
            {
                MessageBox.Show("Nem egyezik a kettö jelszo!!");
                return;
            }else
            {
                //regisztracio ide 29:19
            }

            
        }
    }
}
