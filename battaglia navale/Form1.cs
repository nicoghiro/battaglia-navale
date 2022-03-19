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
        int a;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            
           // nave [,] suca = Popi(a);
        }
        public nave[,] Popi(int grandezza)
        {
            
            int a = 197, b = 170;
            nave[,] popi = new nave[grandezza, grandezza];
            for(int i=0;i < grandezza; i++) { 
            for(int j=0;j< grandezza; j++) { 
            Button button1 = new Button();
            this.Controls.Add(button1);
            button1.Location=new Point(a, b);
                    button1.Size = new Size(20, 20);
                a = a + 20;
                 
             }
                a = 197;
                b = b + 20;
            }
            
            return popi;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a = 0;
            string ugg;
            ugg = textBox1.Text;
            char[] pippo = ugg.ToCharArray();
            
                if (pippo.Length < 2) { 
                a = ((int)pippo[0] - 48);
                }
                if(pippo.Length == 2 )
                {
                a = (((int)pippo[0] - 48) * 10) + (((int)pippo[1] - 48));
                }
            if(pippo.Length>3)
            {
                textBox1.Text = "tabella troppo grande ( < 100) ";
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nave[,] suca = Popi(a);
        }
    }
}




    public struct nave
{
    public int lung;
    public bool ceck;
}