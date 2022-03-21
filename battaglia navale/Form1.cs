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
    

    public partial class Form1 : Form
    {
        string vuota;
        int a;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "inserisci quanto vuoi grande la tabella";
            
            

           
        }
        public nave[,] Popi(int grandezza)
        {
           
            int a = 197, b = 170;
            nave[,] popi = new nave[grandezza, grandezza];
            for(int i=0;i < grandezza; i++) {
                for (int j = 0; j < grandezza; j++) {
                    if (i == 0 || j == 0)
                    {
                        if (i == 0)
                        {
                            if (i == 0 && j == 0)
                            {
                                a = a + 20;
                            }
                            else
                            {
                                popi[i, j].testo = new Label();
                                this.Controls.Add(popi[i, j].testo);
                                popi[i, j].testo.Location = new Point(a, b);
                                popi[i, j].testo.Size = new Size(20, 20);
                                string lab = Convert.ToString(j + 48);
                                popi[i, j].testo.Text = lab;
                                a = a + 20;
                            }

                        }
                        if (j == 0)
                        {
                            if (i == 0 && j == 0)
                            {

                            }
                            else
                            {
                                popi[i, j].testo = new Label();
                                this.Controls.Add(popi[i, j].testo);
                                popi[i, j].testo.Location = new Point(a, b);
                                popi[i, j].testo.Size = new Size(20, 20);
                                string lab = Convert.ToString(i + 48);
                                popi[i, j].testo.Text = lab;
                                a = a + 20;
                            }                            
                        }
                    }
                    else
                    {
                        popi[i, j].bottone = new Button();
                        this.Controls.Add(popi[i, j].bottone);
                        popi[i, j].bottone.Location = new Point(a, b);
                        popi[i, j].bottone.Size = new Size(20, 20);
                        a = a + 20;
                    }
                 
             }
                a = 197;
                b = b + 20;
            }
            return popi;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = 0;
            string ugg;
            ugg = textBox1.Text;
            char[] pippo = ugg.ToCharArray();

            if (pippo.Length < 2)
            {
                a = ((int)pippo[0] - 48)+1;
            }
            if (pippo.Length == 2)
            {
                a = (((int)pippo[0] - 48) * 10) + (((int)pippo[1] - 48))+1 ;
            }
            if (pippo.Length > 3)
            {
                textBox1.Text = "tabella troppo grande ( < 100) ";
            }


            nave[,] suca = Popi(a);
            textBox1.Hide();
            button1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}




    public struct nave
{
    public int lung;
    public bool ceck;
    public Button bottone;
    public Label testo;
}