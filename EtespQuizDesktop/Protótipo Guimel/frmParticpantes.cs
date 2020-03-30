using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protótipo_Guimel
{
    public partial class frmParticpantes : Form
    {
        public frmParticpantes()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = new Point(0, 0);
        }

        private void BtnEdit1_Click(object sender, EventArgs e)
        {

            frmEditPart frmEP = new frmEditPart();
            frmEP.MdiParent = this.MdiParent;
            frmEP.Size = Size;
            frmEP.Show();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            frmEditGroup frmEG = new frmEditGroup();
            frmEG.MdiParent = this.MdiParent;
            frmEG.Size = Size;
            frmEG.Show();
        }
    }
}
