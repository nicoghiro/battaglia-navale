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
    public partial class vittoria : Form
    {
        public vittoria()
        {
            InitializeComponent();
        }

        private void vittoria_Load(object sender, EventArgs e)
        {
            Vittoria(); 
        }
        public void Vittoria()
        {
            Label vittoria = new Label();
            this.Controls.Add(vittoria);
            vittoria.Location = new Point(500, 156);
            vittoria.Text = "Congratulazioni! Hai vinto";
            
        }
    }
}
