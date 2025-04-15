using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iktprojekt
{
    public partial class Form1 : Form
    {
        public List<string> osszes = new List<string>();

        public Form1()
        {
            InitializeComponent();

            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.LightSteelBlue;
            button1.FlatAppearance.BorderSize = 0;

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            textBox1.Hide();    
            comboBox1.Hide();
            comboBox2.Hide();
            dateTimePicker1.Hide();


            comboBox1.Items.Add("Munka");
            comboBox1.Items.Add("Szórakozás");
            comboBox1.Items.Add("Hobbi");
            comboBox1.Items.Add("Pihenés");

            comboBox2.Items.Add("Összes");
            comboBox2.Items.Add("Munka");
            comboBox2.Items.Add("Szórakozás");
            comboBox2.Items.Add("Hobbi");
            comboBox2.Items.Add("Pihenés");
        }

        private void kilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void háttérszinVálasztásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            openFileDialog1.Filter = "Szöveges fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    string[] lines = System.IO.File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            }


            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            textBox1.Show();
            comboBox1.Show();
            comboBox2.Show();
            dateTimePicker1.Show();
;
            button6.Hide();
            button7.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            textBox1.Show();
            comboBox1.Show();
            comboBox2.Show();
            dateTimePicker1.Show();
            button6.Hide();
            button7.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains(comboBox1.Text))
            {
                MessageBox.Show("Válassz érvényes kategóriát!");
                return;
            }

            string ujFeladat = textBox1.Text + "  |  " + comboBox1.Text + "  |  " + dateTimePicker1.Text;

            listBox1.Items.Add(ujFeladat);



        }

        private void button4_Click(object sender, EventArgs e)
        {

            listBox1.Items.Remove(listBox1.SelectedItem);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztosan uj fájlt nyitsz meg? \naz el nem mentett adatok eltünnek", "Open existing file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Console.WriteLine("Elfogadva, kiiratás");
            }
            else if (dialogResult == DialogResult.No)
            {
                Console.WriteLine("Elutasitva, Visszaküldés");
                return;

            }
            listBox1.Items.Clear();
            openFileDialog1.Filter = "Szöveges fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    string[] lines = System.IO.File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                saveFileDialog1.Filter = "Szöveges fájl (*.txt)|*.txt|Minden fájl (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.DefaultExt = "txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<string> items = new List<string>();
                    foreach (var item in listBox1.Items)
                    {
                        items.Add(item.ToString());
                    }

                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, items);
                }
            }

        }

        private void újListaLétrehozásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void betüszínVálasztásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    betuszinvalasztasglobalisan(this, colorDialog.Color);
                }
            }
        }
        private void betuszinvalasztasglobalisan(Control parent, Color color)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.ForeColor = color;

                if (ctrl.HasChildren)
                {
                    betuszinvalasztasglobalisan(ctrl, color);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valasztott = comboBox2.SelectedItem.ToString();

            if (osszes.Count == 0)
            {
                foreach (var i in listBox1.Items)
                {
                    osszes.Add(i.ToString());
                }
            }

            listBox1.Items.Clear();

            if (valasztott == "Összes")
            {
                foreach (var i in osszes)
                {
                    listBox1.Items.Add(i);
                }
            }
            else
            {
                foreach (var i in osszes)
                {
                    if (i.Contains(valasztott))
                    {
                        listBox1.Items.Add(i);
                    }
                }
            }
        }


    }

}

