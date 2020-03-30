using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETESP_Quiz
{
    public partial class frmJogoTelaFinal : Form
    {
        SoundPlayer sp = new SoundPlayer(Properties.Resources.win);
        public frmJogoTelaFinal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.cU3A0ff;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmJogoTelaFinal_Load(object sender, EventArgs e)
        {
            sp.Load();
            sp.Play();
        }

        private void frmJogoTelaFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Stop();
        }
    }
}
