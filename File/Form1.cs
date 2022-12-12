using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NevDatumFeladat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTXTBX.Text))
            {
                MessageBox.Show("nincs név!");
                return;
            }
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("nincs szöveg!");
                return;
            }

            saveFileDialog1.Filter = "Szöveg file| *.txt|Vesszővel tagolt szöveg file | *.csv|Minden file| *.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szoveg = string.Join(";", NameTXTBX.Text, dateTimePicker1.Text, richTextBox1.Text);
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, szoveg);
            }
            else
            {
                MessageBox.Show("Megszakadt a folyamat!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string beolvasottSzoveg = File.ReadAllText(filename);
                string[] adat = beolvasottSzoveg.Split(';');
                NameTXTBX.Text = adat[0];
                dateTimePicker1.Text = adat[1];
                richTextBox1.Text = adat[2];
            }
        }
    }
}
