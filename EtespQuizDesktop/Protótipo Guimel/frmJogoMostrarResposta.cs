using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETESP_Quiz
{
    public partial class frmJogoMostrarResposta : Form
    {
        public frmJogoMostrarResposta()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (lblCertoErrado.Text == "Está Certa!")
            {
                lblCertoErrado.Text = "Está Errada...";
                lblCertoErrado.ForeColor = Color.Coral;
            }
            else
            {
                lblCertoErrado.Text = "Está Certa!";
                lblCertoErrado.ForeColor = Color.LimeGreen;
            }
        }

        public void setCerta()
        {
            lblCertoErrado.Text = "Está Errada...";
            lblCertoErrado.ForeColor = Color.Coral;
        }

        public void setErrada()
        {
            lblCertoErrado.Text = "Está Certa!";
            lblCertoErrado.ForeColor = Color.LimeGreen;
        }
        private void frmJogoMostrarResposta_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
