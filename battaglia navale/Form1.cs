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
        nave[,] nemico;
        int contatore=0;
        int gioco = 0;
        nave[,] battaglione;
        
        int a;
       
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(907, 22);
            label1.Text = "inserisci quanto vuoi grande la tabella";
            button2.Hide();
            

           
        }
        public nave[,] creazione(int grandezza,string player,int posx,int posy)
        {
            
            char lab = '@';
            int x = posx, y = posy;
            nave[,] griglia = new nave[grandezza, grandezza];
            if(player == "giocatore") { 
            Label GIOCATORE = new Label();
            this.Controls.Add(GIOCATORE);
            GIOCATORE.Location = new Point(x + (15 * (grandezza / 2) + 30), y - 35);
            GIOCATORE.Text = "GIOCATORE";
            }
            if(player == "bot") {
                    Label bot = new Label();
                    this.Controls.Add(bot);
                    bot.Location = new Point(x + (15 * (grandezza / 2) + 30), y - 35);
                    bot.Text = "NEMICO";
                }
            for (int i=0;i < grandezza; i++) {
                for (int j = 0; j < grandezza; j++) {
                    if (i == 0 || j == 0)
                    {
                        if (i == 0)
                        {
                            if (i == 0 && j == 0)
                            {
                                x = x + 25;
                                
                            }
                            else
                            {
                                griglia[i, j].testo = new Label();
                                this.Controls.Add(griglia[i, j].testo);
                                griglia[i, j].testo.Location = new Point(x, y);
                                griglia[i, j].testo.Size = new Size(25, 25);
                                
                                lab = Convert.ToChar(Convert.ToInt32(lab) + 1);
                                griglia[i, j].testo.Text = Convert.ToString(lab);
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
                                griglia[i, j].testo = new Label();
                                this.Controls.Add(griglia[i, j].testo);
                                griglia[i, j].testo.Location = new Point(x, y);
                                griglia[i, j].testo.Size = new Size(25, 25);
                                string vert = Convert.ToString(i );
                                griglia[i, j].testo.Text = vert;
                                x = x + 25;
                                
                            }                            
                        }
                    }
                    else
                    {
                        griglia[i, j].bottone = new Button();
                        this.Controls.Add(griglia[i, j].bottone);
                        griglia[i, j].bottone.Location = new Point(x, y);
                        griglia[i, j].bottone.Size = new Size(25,25);
                        string cordx = Convert.ToString(i);
                        string cordy = Convert.ToString(j);
                        griglia[i, j].bottone.Name = i + "-" + j;
                        if(player == "giocatore") { 
                        griglia[i,j].bottone.Click += new EventHandler(buttonp_Click);
                        x = x + 25;
                        }
                        else { 
                                 griglia[i, j].bottone.Click += new EventHandler(buttonn_Click);
                        x = x + 25;
                        }
                        
                    }
                 
             }
                x = posx;
                y = y + 25;
            }
            button2.Show();
            return griglia;
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
                battaglione = creazione(a,"giocatore",400,170);
                //nemici è la stampa della griglia dei nemici (griglaN)
                nemico = creazione(a,"bot",1200,170);
            
                button1.Hide();
                
                label1.Text = "Scegli quante barche inserire";
                



            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
       
        public void buttonp_Click(object sender, EventArgs e)
        {
            
            int salvax=0;
            int salvay=0;
            
            Button button = sender as Button;
            for (int i = 1; i < a; i++)
            {//ciao Uwu
                for (int j = 1; j < a; j++)
                {

                    if (button.Name == battaglione[i, j].bottone.Name)
                    {
                        
                        salvax =i;
                        salvay = j;

                    }
                }
            
            }
            if (gioco <1)
            {
                battaglione[salvax, salvay].fase = 1;
                battaglione[salvax, salvay].bottone.BackColor = Color.Pink;
                contatore = contatore + 1; 
               
            }

        }
        public void buttonn_Click(object sender, EventArgs e)
        {
            int salvax = 0;
            int salvay = 0;

            Button button = sender as Button;
            for (int i = 1; i < a; i++)
            {
                for (int j = 1; j < a; j++)
                {

                    if (button.Name == nemico[i, j].bottone.Name)
                    {
                        salvax = i;
                        salvay = j;
                        nemico[salvax, salvay].bottone.BackColor = Color.Green;
                        

                    }
                }

            }
        }



            private void button2_Click_1(object sender, EventArgs e)
        {
            gioco = 1;
            button2.Hide();
        }
    }
}




    public struct nave
{
    
    public int fase;
    //fase 1 = vuota ; fase 2 = nave presente ; fase 3 = fase distrutta
    public Button bottone;
    public Label testo;
}