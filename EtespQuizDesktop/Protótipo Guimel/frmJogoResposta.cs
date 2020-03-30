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
    public partial class frmJogoResposta : Form
    {
        public int altIndex = 0;
        public string resposta;
        public bool certa;

        public enum AnswerType
        {
            Text = 0,
            Alts = 1
        }
        public frmJogoResposta(AnswerType type)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            if (type == AnswerType.Text)
            {
                altsPanel.Visible = false;
            }
            else if(type == AnswerType.Alts)
            {
                txtPanel.Visible = false;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void FrmJogoResposta_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            altIndex = 0;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            altIndex = 1;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            altIndex = 2;
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            altIndex = 3;
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            altIndex = 4;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            certa = true;
            resposta = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            certa = false;
            resposta = textBox1.Text;
            Close();
        }
    }
}
