﻿using System;
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
        Random sus = new Random();
        nave[,] nemico;
        int contatore=0, contatoreG=0;
        int gioco = 0;
        nave[,] battaglione;
        
        int a ;
       
      
        public Form1()
        {
           
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(907, 22);
            label1.Text = "inserisci quanto vuoi grande la tabella";
            
            

           
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
                        griglia[i, j].contaclick = 0;
                        griglia[i, j].fase = 0;
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
            else
            {
                //giocatore è la stampa della griglia del giocatore (grigliaP)
                battaglione = creazione(a, "giocatore", 400, 170);
                //nemici è la stampa della griglia dei nemici (griglaN)
                nemico = creazione(a, "bot", 1200, 170);
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
            if (gioco <1 && battaglione[salvax, salvay].fase == 0)
            {
                
                int crea = 0;
                battaglione[salvax, salvay].fase = 1;
                battaglione[salvax, salvay].bottone.BackColor = Color.Pink;
                contatoreG++;
                while (crea == 0)
                {
                    int y = a + 1;
                    int navnemx = sus.Next(1,y-1);
                    int navnemy = sus.Next(1, y-1);
                    if (nemico[navnemx, navnemy].fase == 0)
                    {
                        nemico[navnemx, navnemy].fase = 1;
                        contatore++;
                        crea = crea + 1;
                        nemico[navnemx, navnemy].bottone.BackColor = Color.LightBlue;
                    }
                
                }
               
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
                        
                        

                    }
                }

            }
<<<<<<< HEAD
<<<<<<< HEAD
            if (gioco == 1 && nemico[salvax, salvay].fase==1 || gioco == 1 &&  nemico[salvax, salvay].fase == 0 )
=======
            if (gioco == 1 && nemico[salvax, salvay].fase==1 || nemico[salvax, salvay].fase == 0 && nemico[salvax, salvay].contaclick<1)
>>>>>>> parent of 50f9c05 (sistemare bottoni che a volte non vanno)
=======
            if (gioco == 1 && nemico[salvax, salvay].fase==1 || nemico[salvax, salvay].fase == 0 && nemico[salvax, salvay].contaclick<1)
>>>>>>> parent of 50f9c05 (sistemare bottoni che a volte non vanno)
            {
                nemico[salvax, salvay].contaclick++;


                int crea = 0;
                if(nemico[salvax, salvay].fase == 1) { 
                nemico[salvax, salvay].fase = 2;
                nemico[salvax, salvay].bottone.BackColor = Color.Black;
                contatoreG--;}
                else
                {
                    nemico[salvax, salvay].fase = 3;
                    nemico[salvax, salvay].bottone.BackColor = Color.Orange;
                }
                while (crea == 0)
                {
                    int y = a + 1;
                    int navnemx = sus.Next(1, y -1);
                    int navnemy = sus.Next(1, y -1 );
                    if (battaglione[navnemx, navnemy].fase == 0)
                    {
                        battaglione[navnemx, navnemy].fase = 3;

                       crea = crea + 1;
                        battaglione[navnemx, navnemy].bottone.BackColor = Color.Yellow;
                    }
                    if (battaglione[navnemx, navnemy].fase == 1)
                    {

                        battaglione[navnemx, navnemy].fase = 2;
                        crea = crea + 1;
                        battaglione[navnemx, navnemy].bottone.BackColor = Color.Purple;
                    }
                    

                }


            }
            else if (nemico[salvax, salvay].fase == 2) { 
            }
            if (contatoreG == 0)
            {
                this.Hide();
                Form vittoria = new Form();
                vittoria.ShowDialog();
                this.Close();
            }
            if (contatore == 0)
            {
                this.Hide();
                Form perso = new Form();
                perso.ShowDialog();
                this.Close();
            }
        }


        //UwUwUwUwUwU
            private void button2_Click_1(object sender, EventArgs e)
            { 
                gioco = 1;
                button2.Hide();
                label1.Text = "comincia la battaglia, scegli dove sganciare le bombe";
            }
    }
}




    public struct nave
{
    public int contaclick;   
    public int fase;
    //fase 0 = vuota ; fase 1 = nave presente ; fase 2 = fase distrutta ; fase 3 = territorio colpito ma senza nave
    public Button bottone;
    public Label testo;
}