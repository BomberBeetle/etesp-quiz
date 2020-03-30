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
    public partial class frmParticipantes : Form
    {
        public frmParticipantes()
        {
            InitializeComponent();
            btnEdit1.borderRadius = 20;
            btnEdit2.borderRadius = 20;
        }

       
        private void BtnEdit1_Click(object sender, EventArgs e)
        {

            frmEditPart frmEP = new frmEditPart();
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
            frmAddPart frmAP = new frmAddPart();
            frmAP.TopMost = true;
            frmAP.ShowDialog();
            Show();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
