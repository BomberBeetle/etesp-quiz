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
    public partial class frmJogoRanking : Form
    {
        public frmJogoRanking()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmJogoRanking_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Tem certeza que quer começar uma rodada de repescagem?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes){
                JogoStatic.Repescagem();
                Close();
            }
        }
    }
}
