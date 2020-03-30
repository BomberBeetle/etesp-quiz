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
    public partial class frmPerguntasTopicos : Form
    {
        public frmPerguntasTopicos()
        {
            InitializeComponent();
            btnEdit1.borderRadius = 20;
            btnEdit2.borderRadius = 20;
            button1.borderRadius = 20;
            button2.borderRadius = 20;
            button3.borderRadius = 20;
            button4.borderRadius = 20;
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            frmEditPerguntas frmEP = new frmEditPerguntas();
            frmEP.Size = Size;
            frmEP.Location = Location;
            frmEP.UpdateTable();
            Hide();
            frmEP.ShowDialog();
            this.Size = frmEP.Size;
            Location = frmEP.Location;
            Show();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            frmEditTopico frmET = new frmEditTopico();
            frmET.Size = Size;
            frmET.Location = Location;
            frmET.UpdateTable();
            Hide();
            frmET.ShowDialog();
            this.Size = frmET.Size;
            Location = frmET.Location;
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditDificuldade frmED = new frmEditDificuldade();
            frmED.Size = Size;
            frmED.Location = Location;
            frmED.UpdateTable();
            Hide();
            frmED.ShowDialog();
            this.Size = frmED.Size;
            Location = frmED.Location;
            Show();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddPergunta frmAP = new frmAddPergunta();
            frmAP.Size = Size;
            frmAP.Location = Location;
            Hide();
            frmAP.ShowDialog();
            this.Size = frmAP.Size;
            Location = frmAP.Location;
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddTopico frmAT = new frmAddTopico();
            frmAT.Size = Size;
            frmAT.Location = Location;
            Hide();
            frmAT.ShowDialog();
            this.Size = frmAT.Size;
            Location = frmAT.Location;
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAddDificuldade frmAD = new frmAddDificuldade();
            frmAD.Size = Size;
            frmAD.Location = Location;
            Hide();
            frmAD.ShowDialog();
            this.Size = frmAD.Size;
            Location = frmAD.Location;
            Show();
        }

        private void frmPerguntasTopicos_Load(object sender, EventArgs e)
        {

        }
    }
}
