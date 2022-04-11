using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battaglia_navale
{
    public partial class inizio : Form
    {
        public  int a = 3;
        public inizio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = 0;
            //testo è la variabile appoggio per conversione
            string testo;
            testo = textBox1.Text;
            //conv è la variabile per trasformare in numero la dimensione inserita dall'utente (UwU)
            char[] conv = testo.ToCharArray();

            if (conv.Length < 2)
            {
                a = ((int)conv[0] - 48) + 1;
            }
            if (conv.Length == 2)
            {
                a = (((int)conv[0] - 48) * 10) + (((int)conv[1] - 48)) + 1;
            }
            if (a > 27)
            {
                textBox1.Text = "la grandezza deve essere minore di < 27";
            }
            else
            {
                
                Form1 F1 = new Form1();
                F1.ShowDialog();
                this.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

