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
    public partial class frmGroups : Form
    {
        public frmGroups()
        {
            InitializeComponent();
            btnEdit1.borderRadius = 15;
            btnEdit2.borderRadius = 15;
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit1_Click(object sender, EventArgs e)
        {
            frmEditGroup frmEG = new frmEditGroup();
            frmEG.Size = Size;
            frmEG.Location = Location;
            frmEG.UpdateTable();
            Hide();
            frmEG.ShowDialog();
            this.Size = frmEG.Size;
            Location = frmEG.Location;
            Show();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            frmAddGroup frmEP = new frmAddGroup();
            frmEP.Size = Size;
            frmEP.Location = Location;
            Hide();
            frmEP.ShowDialog();
            this.Size = frmEP.Size;
            Location = frmEP.Location;
            Show();
        }
    }
}
