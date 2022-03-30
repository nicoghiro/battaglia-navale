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


        nave[,] battaglione;
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
        public nave[,] giocatore(int grandezza, ref int c)
        {
            
            char lab = '@';
            int x = 453, y = 170;
            nave[,] grigliaP = new nave[grandezza, grandezza];
            Label GIOCATORE = new Label();
            this.Controls.Add(GIOCATORE);
            GIOCATORE.Location = new Point(x + (15 * (grandezza / 2) + 30), y - 35);
            GIOCATORE.Text = "GIOCATORE";
            for (int i=0;i < grandezza; i++) {
                for (int j = 0; j < grandezza; j++) {
                    if (i == 0 || j == 0)
                    {
                        if (i == 0)
                        {
                            if (i == 0 && j == 0)
                            {
                                x = x + 25;
                                c++;
                            }
                            else
                            {
                                grigliaP[i, j].testo = new Label();
                                this.Controls.Add(grigliaP[i, j].testo);
                                grigliaP[i, j].testo.Location = new Point(x, y);
                                grigliaP[i, j].testo.Size = new Size(25, 25);
                                
                                lab = Convert.ToChar(Convert.ToInt32(lab) + 1);
                                grigliaP[i, j].testo.Text = Convert.ToString(lab);
                                x = x + 25;
                                
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
                                grigliaP[i, j].testo.Location = new Point(x, y);
                                grigliaP[i, j].testo.Size = new Size(25, 25);
                                string vert = Convert.ToString(i );
                                grigliaP[i, j].testo.Text = vert;
                                x = x + 25;
                                
                            }                            
                        }
                    }
                    else
                    {
                        grigliaP[i, j].bottone = new Button();
                        this.Controls.Add(grigliaP[i, j].bottone);
                        grigliaP[i, j].bottone.Location = new Point(x, y);
                        grigliaP[i, j].bottone.Size = new Size(25,25);
                        string cordx = Convert.ToString(i);
                        string cordy = Convert.ToString(j);
                        grigliaP[i, j].bottone.Name = i + "-" + j;
                        grigliaP[i,j].bottone.Click += new EventHandler(buttonp_Click);
                        x = x + 25;
                        c++;
                    }
                 
             }
                x = 453;
                y = y + 25;
            }
            
            return grigliaP;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
            
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
            else {

                //giocatore è la stampa della griglia del giocatore (grigliaP)
                battaglione = giocatore(a, ref d);
                //nemici è la stampa della griglia dei nemici (griglaN)
                nave[,] nemico = nemici(a);
            
                button1.Hide();
                
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
            int x = 1200, y = 170;
            Label NEMICO = new Label();
            this.Controls.Add(NEMICO);
            NEMICO.Location = new Point(x + (15 * (grandezza / 2)+45), y -35);
            NEMICO.Text = "NEMICO";
            nave[,] grigliaN = new nave[grandezza, grandezza];
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
                                x = x + 25;
                                c++;
                            }
                            else
                            {
                                grigliaN[i, j].testo = new Label();
                                this.Controls.Add(grigliaN[i, j].testo);
                                grigliaN[i, j].testo.Location = new Point(x, y);
                                grigliaN[i, j].testo.Size = new Size(25, 25);
                                lab = Convert.ToChar(Convert.ToInt32(lab) + 1);
                                grigliaN[i, j].testo.Text = Convert.ToString(lab);
                                x = x + 25;
                            }
                            
                        }
                        if (j == 0)
                        {
                            if (i == 0 && j == 0)
                            {

                            }
                            else
                            {
                                grigliaN[i, j].testo = new Label();
                                this.Controls.Add(grigliaN[i, j].testo);
                                grigliaN[i, j].testo.Location = new Point(x, y);
                                grigliaN[i, j].testo.Size = new Size(25, 25);
                                string vert = Convert.ToString(i);
                                grigliaN[i, j].testo.Text = vert;
                                x = x + 25;
                            }
                        }
                    }
                    else
                    {
                        grigliaN[i, j].bottone = new Button();
                        this.Controls.Add(grigliaN[i, j].bottone);
                        grigliaN[i, j].bottone.Location = new Point(x, y);
                        grigliaN[i, j].bottone.Size = new Size(25, 25);
                        string cordx = Convert.ToString(i);
                        string cordy = Convert.ToString(j);
                        grigliaN[i, j].bottone.Name = i+"-"+j;

                        x = x + 25;
                        c++;
                        
                    }

                }
                x = 1200;
                y = y + 25;
            }

            return grigliaN;
        }
        public void buttonp_Click(object sender, EventArgs e)
        {
            /*
            Button button = (Button)sender;
            button.
            */
            
            Button button = sender as Button;
            for (int i = 1; i < a; i++)
            {
                for (int j = 1; j < a; j++)
                {

                    if (button.Name == battaglione[i, j].bottone.Name)
                    {
                        battaglione[i, j].fase = 1;
                    }
                }
            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}




    public struct nave
{
    public int lung;
    public int fase;
    //fase 1 = vuota ; fase 2 = nave presente ; fase 3 = fase distrutta
    public Button bottone;
    public Label testo;
}