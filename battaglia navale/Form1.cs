using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace battaglia_navale
{
    

    public partial class Form1 : Form
    {
        Random sus = new Random();
        nave[,] nemico;
        int contatore=0, contatoreG=0;
        int gioco = 0;
        nave[,] battaglione;
        
        int a;
       
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(665, 22);
            
            
            button2.Hide();
            

           
        }
        public nave[,] creazione(int grandezza,string player,int posx,int posy)
        {
            
            char lab = '@';
            int x = posx, y = posy;
            nave[,] griglia = new nave[grandezza, grandezza];
            //creazione matrice giocatore
            if(player == "giocatore") { 
            Label GIOCATORE = new Label();
            this.Controls.Add(GIOCATORE);
            GIOCATORE.Location = new Point(x + (30 * (grandezza / 2) ), y - 35);
            GIOCATORE.Text = "GIOCATORE";
            }
            //generazione matrice CPU
            if(player == "bot") {
                    Label bot = new Label();
                    this.Controls.Add(bot);
                    bot.Location = new Point(x + (30 * (grandezza / 2)+30), y - 35);
                    bot.Text = "NEMICO";
                }
            for (int i=0;i < grandezza; i++) {
                for (int j = 0; j < grandezza; j++) {
                    //creazione tabelle in generale con nomi caselle e bottoni, in base alla posizione in cui si trovano
                    if (i == 0 || j == 0)
                    {
                        if (i == 0)
                        {
                            //numeri e lettere sopra le caselle
                            if (i == 0 && j == 0)
                            {
                                x = x + 40;
                                
                            }
                            else
                            {
                                
                                griglia[i, j].testo = new Label();
                                this.Controls.Add(griglia[i, j].testo);
                                griglia[i, j].testo.Location = new Point(x, y);
                                griglia[i, j].testo.Size = new Size(35, 35);
                                
                                lab = Convert.ToChar(Convert.ToInt32(lab) + 1);
                                griglia[i, j].testo.Text = Convert.ToString(lab);
                                x = x + 35;
                                
                            }

                        }
                        if (j == 0)
                        {
                            //numeri e lettere accanto le caselle
                            if (i != 0 && j == 0)
                            {
                                griglia[i, j].testo = new Label();
                                
                                this.Controls.Add(griglia[i, j].testo);
                                griglia[i, j].testo.Location = new Point(x, y);
                                griglia[i, j].testo.Size = new Size(35, 35);
                                string vert = Convert.ToString(i);
                                griglia[i, j].testo.Text = vert;

                                x = x + 35;
                                
                            }                            
                        }
                    }
                    else
                    {
                        //creazione pulsanti appartenenti alla matrice
                        griglia[i, j].bottone = new Button();
                        this.Controls.Add(griglia[i, j].bottone);
                        griglia[i, j].bottone.Location = new Point(x, y);
                        griglia[i, j].bottone.Size = new Size(35,35);
                        griglia[i, j].contaclick = 0;
                        griglia[i, j].bottone.BackColor = Color.Aquamarine;
                        Bitmap b = new Bitmap(@"..\..\..\immagini\stock-vector-pixel-art-water-texture-for-game-platforms-vector-illustration-bit-sprite-1349125475 (1).jpg");
                        griglia[i, j].bottone.Image = b;
                        griglia[i, j].bottone.FlatStyle = FlatStyle.Flat;
                        griglia[i, j].bottone.FlatAppearance.BorderSize = 1;
                        griglia[i, j].bottone.FlatAppearance.BorderColor = Color.Aqua;
                        griglia[i, j].fase = 0;
                        string cordx = Convert.ToString(i);
                        string cordy = Convert.ToString(j);
                        griglia[i, j].bottone.Name = i + "-" + j;
                        if(player == "giocatore") { 
                        griglia[i,j].bottone.Click += new EventHandler(buttonp_Click);
                        x = x + 35;
                        }
                        else { 
                                 griglia[i, j].bottone.Click += new EventHandler(buttonn_Click);
                        x = x + 35;
                        }
                        
                    }
                 
             }
                x = posx;
                y = y + 35;
            }
          
            return griglia;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //non serve a nulla
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b;
            a = 0;
            //testo è la variabile appoggio per conversione
            string testo;
            testo = textBox1.Text;
            //conv è la variabile per trasformare in numero la dimensione inserita dall'utente 
            char[] conv = testo.ToCharArray();
            b = convertiVersoIntero(conv);
            //gestione eccezioni di grandezza della tabella
            if (textBox1.Text == ""|| b==0)
            {
                textBox1.Text = "";
                throw new Exception("è necessario inserire un numero");
                
            }
            else
            {
                if (conv.Length < 2)
                {
                    a = ((int)conv[0] - 48) + 1;
                }
                if (conv.Length == 2)
                {
                    a = (((int)conv[0] - 48) * 10) + (((int)conv[1] - 48)) + 1;
                }
                if (a > 26 || 3>a)
                {
                    textBox1.Text = "";
                    throw new Exception("il numero inserito deve essere minore di 26 e maggiore di 1");
                }

                else
                {
                    int locationx = 350 - 13 * a;
                    int locationy = 361-10*a;
                    //giocatore è la stampa della griglia del giocatore (grigliaP)
                    battaglione = creazione(a, "giocatore", locationx, locationy);
                    //nemici è la stampa della griglia dei nemici (griglaN)
                    nemico = creazione(a, "bot", locationx+950, locationy);
                    textBox1.Hide();
                    button1.Hide();
                    label1.Location = new Point(730, 22);
                    label1.Text = "Scegli quante barche inserire";
                    button2.Show();



                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
       //funzione di posizionamento navi 
        public void buttonp_Click(object sender, EventArgs e)
        {
            
            
            
            Button button = sender as Button;
            int[] trovato = Identifica(battaglione, button, a);
            int salvax = trovato[0];
            int salvay = trovato[1];
         
            if (gioco <1 && battaglione[salvax, salvay].fase == 0)
            {
                
                int crea = 0;
                battaglione[salvax, salvay].fase = 1;
                Bitmap b = new Bitmap(@"..\..\..\immagini\nave.jpg");
                battaglione[salvax, salvay].bottone.Image = b;
                contatoreG++;
                while (crea == 0)
                {
                    int y = a  + 1;
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
        //funzione di identificazione per le navi cpu
        public void buttonn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int[] trovato = Identifica(nemico, button, a);
            int salvax = trovato[0];
            int salvay = trovato[1];
            //fase di attacco navi
            if (gioco == 1 && nemico[salvax, salvay].fase == 1 || gioco == 1 && nemico[salvax, salvay].fase == 0 && nemico[salvax, salvay].contaclick < 1)
            {
                nemico[salvax, salvay].contaclick++;

                //tentativo giocatore
                int crea = 0;
                if(nemico[salvax, salvay].fase == 1) {
                    Bitmap b = new Bitmap(@"..\..\..\immagini\esplosa.jpg");
                    nemico[salvax, salvay].bottone.Image = b;
                    nemico[salvax, salvay].fase = 2;
                nemico[salvax, salvay].bottone.BackColor = Color.Black;
                contatoreG--;}
                else
                {
                    Bitmap b = new Bitmap(@"..\..\..\immagini\mancata.png");
                    nemico[salvax, salvay].bottone.Image = b;
                }
                //tentativo nemico
                while (crea == 0)
                {
                    int y = a + 1;
                    int navnemx = sus.Next(1, y - 1);
                    int navnemy = sus.Next(1, y - 1);
                    if (battaglione[navnemx, navnemy].fase == 0)
                    {
                        battaglione[navnemx, navnemy].contaclick++;
                        battaglione[navnemx, navnemy].fase = 3;
                        crea = crea + 1;
                          Bitmap b = new Bitmap(@"..\..\..\immagini\mancata.png");
                        battaglione[navnemx, navnemy].bottone.Image = b;
                    }
                    if (battaglione[navnemx, navnemy].fase == 1)
                    {
                        battaglione[navnemx, navnemy].contaclick++;
                        battaglione[navnemx, navnemy].fase = 2;
                        crea = crea + 1;
                        //biegropatelli
                        Bitmap b = new Bitmap(@"..\..\..\immagini\esplosa.jpg");
                        battaglione[navnemx, navnemy].bottone.Image = b;
                        contatore--;
                    }
                    


                }


            }
            else if (nemico[salvax, salvay].fase == 2 ) { 
            }
            if (contatoreG == 0 && gioco != 0)
            {
                this.Hide();
                vittoria vittoria = new vittoria();
                vittoria.ShowDialog();
                this.Close();
            }
            if (contatore == 0 && gioco != 0)
            {
                this.Hide();
                perso perso = new perso();
                perso.ShowDialog();
                this.Close();
            }
        }


        //stampa scritta inizio battaglia, e successivamente gioco diventa 1 per indicare che inizia la battaglia
            private void button2_Click_1(object sender, EventArgs e)
            {

            if (contatore != 0) { 
                gioco = 1;
                button2.Hide();
                label1.Location = new Point(550, 22);
                label1.Text = "comincia la battaglia, scegli dove sganciare le bombe";
            }
            else
            {
                throw new Exception("inserire almeno una barca");
            }
            }
        public static int convertiVersoIntero(char[] stringa)
        {
            for (int i = 0; i < stringa.Length; i++)
            {
                int temp = ((int)stringa[i]);
                if (temp - 48 > 9)
                {
                    return 0;
                }
            }
          
            return 1;
        }
        public static int[] Identifica(nave[,] battaglione, Button button, int a)
        {
            int[] identifica = new int[2];


            for (int i = 1; i < a; i++)
            {
                for (int j = 1; j < a; j++)
                {

                    if (button.Name == battaglione[i, j].bottone.Name)
                    {
                        identifica[0] = i;
                        identifica[1] = j;

                        return identifica;

                    }
                }

            }
            return identifica;
        }
    }
}




    public struct nave
{
    public int contaclick;   
    public int fase;
    //fase 0 = vuota ; fase 1 = nave presente ; fase 2 = fase distrutta ; fase 3 = nave attaccata ma non colpita;
    public Button bottone;
    public Label testo;
}