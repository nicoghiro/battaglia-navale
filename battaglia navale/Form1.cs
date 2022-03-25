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
        int d=0;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(907, 22);
            label1.Text = "inserisci quanto vuoi grande la tabella";
           
            

           
        }
        public nave[,] Popi(int grandezza, ref int c)
        {
            
            char lab = '@';
            int a = 453, b = 170;
            nave[,] popi = new nave[grandezza, grandezza];
            Label GIOCATORE = new Label();
            this.Controls.Add(GIOCATORE);
            GIOCATORE.Location = new Point(a + (15 * (grandezza / 2) + 30), b - 35);
            GIOCATORE.Text = "GIOCATORE";
            for (int i=0;i < grandezza; i++) {
                for (int j = 0; j < grandezza; j++) {
                    if (i == 0 || j == 0)
                    {
                        if (i == 0)
                        {
                            if (i == 0 && j == 0)
                            {
                                a = a + 25;
                                c++;
                            }
                            else
                            {
                                popi[i, j].testo = new Label();
                                this.Controls.Add(popi[i, j].testo);
                                popi[i, j].testo.Location = new Point(a, b);
                                popi[i, j].testo.Size = new Size(25, 25);
                                
                                lab = Convert.ToChar(Convert.ToInt32(lab) + 1);
                                popi[i, j].testo.Text = Convert.ToString(lab);
                                a = a + 25;
                                
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
                                popi[i, j].testo.Size = new Size(25, 25);
                                string vert = Convert.ToString(i );
                                popi[i, j].testo.Text = vert;
                                a = a + 25;
                                
                            }                            
                        }
                    }
                    else
                    {
                        popi[i, j].bottone = new Button();
                        this.Controls.Add(popi[i, j].bottone);
                        popi[i, j].bottone.Location = new Point(a, b);
                        popi[i, j].bottone.Size = new Size(25,25);
                        string sium = Convert.ToString(c);
                        popi[i, j].bottone.Name = sium;
                        popi[i, j].bottone.Text = sium;
                        a = a + 25;
                        c++;
                    }
                 
             }
                a = 453;
                b = b + 25;
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
                a = ((int)pippo[0] - 48) + 1;
            }
            if (pippo.Length == 2)
            {
                a = (((int)pippo[0] - 48) * 10) + (((int)pippo[1] - 48)) + 1;
            }
            if (a > 27)
            {
                textBox1.Text = "la grandezza deve essere minore di < 27";
            }
            else {


                nave[,] battaglione = Popi(a, ref d);
                nave[,] nemico = nemici(a);
            
                button1.Hide();
                textBox1.Hide(); 
                label1.Text = "Scegli quante barche inserire";
                



            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        public nave[,] nemici(int grandezza)
        {
            int c = 0;
            char lab = '@';
            int a = 1200, b = 170;
            Label NEMICO = new Label();
            this.Controls.Add(NEMICO);
            NEMICO.Location = new Point(a + (15 * (grandezza / 2)+45), b -35);
            NEMICO.Text = "NEMICO";
            nave[,] grigliaP = new nave[grandezza, grandezza];
            for (int i = 0; i < grandezza; i++)
            {
                for (int j = 0; j < grandezza; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (i == 0)
                        {
                            if (i == 0 && j == 0)
                            {
                                a = a + 25;
                                c++;
                            }
                            else
                            {
                                grigliaP[i, j].testo = new Label();
                                this.Controls.Add(grigliaP[i, j].testo);
                                grigliaP[i, j].testo.Location = new Point(a, b);
                                grigliaP[i, j].testo.Size = new Size(25, 25);

                                lab = Convert.ToChar(Convert.ToInt32(lab) + 1);
                                grigliaP[i, j].testo.Text = Convert.ToString(lab);
                                a = a + 25;
                            }
                            
                        }
                        if (j == 0)
                        {
                            if (i == 0 && j == 0)
                            {

                            }
                            else
                            {
                                grigliaP[i, j].testo = new Label();
                                this.Controls.Add(grigliaP[i, j].testo);
                                grigliaP[i, j].testo.Location = new Point(a, b);
                                grigliaP[i, j].testo.Size = new Size(25, 25);
                                string vert = Convert.ToString(i);
                                grigliaP[i, j].testo.Text = vert;
                                a = a + 25;
                            }
                        }
                    }
                    else
                    {
                        grigliaP[i, j].bottone = new Button();
                        this.Controls.Add(grigliaP[i, j].bottone);
                        grigliaP[i, j].bottone.Location = new Point(a, b);
                        grigliaP[i, j].bottone.Size = new Size(25, 25);
                        string sium = Convert.ToString(c);
                        grigliaP[i, j].bottone.Name = sium;
                        grigliaP[i, j].bottone.Text = sium;
                        a = a + 25;
                        c++;
                        
                    }

                }
                a = 1200;
                b = b + 25;
            }

            return grigliaP;
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