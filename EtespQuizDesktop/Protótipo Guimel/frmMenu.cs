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
    public partial class frmMenu : Form
    {
        
        public frmMenu()
        {
            InitializeComponent();
            btnParticipantes.borderRadius = 20;
            btnJogar.borderRadius = 20;
            btnExit.borderRadius = 20;
            btnEditQuiz.borderRadius = 20;
            btnGroup.borderRadius = 20;
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            frmQuizConfig frmQC = new frmQuizConfig();
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            frmGroups frmG = new frmGroups();
            frmG.Size = Size;
            frmG.Location = Location;
            Hide();
            frmG.ShowDialog();
            this.Size = frmG.Size;
            Location = frmG.Location;
            Show();
        }

        private void BtnParticipantes_Click(object sender, EventArgs e)
        {
            frmParticipantes frmP = new frmParticipantes();
            frmP.Size = Size;
            frmP.Location = Location;
            Hide();
            frmP.ShowDialog();
            this.Size = frmP.Size;
            Location = frmP.Location;
            Show();
        }

        private void btnEditQuiz_Click(object sender, EventArgs e)
        {
            frmPerguntasTopicos frmPT = new frmPerguntasTopicos();
            frmPT.Size = Size;
            frmPT.Location = Location;
            Hide();
            frmPT.ShowDialog();
            this.Size = frmPT.Size;
            Location = frmPT.Location;
            Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            frmDebug frmDG = new frmDebug();
            frmDG.Size = Size;
            frmDG.Location = Location;
            frmDG.ShowDialog(this);
            this.Size = frmDG.Size;
            Location = frmDG.Location;
            Show();
        }
    }
}

