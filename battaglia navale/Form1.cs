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
            char lab = '@';
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
                                a = a + 25;
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
                        a = a + 25;
                    }
                 
             }
                a = 197;
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


            nave[,] battaglione = Popi(a);
            textBox1.Hide();
            button1.Hide();
            }
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