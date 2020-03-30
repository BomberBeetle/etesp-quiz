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
    public partial class frmMdi : Form
    {
        public frmMdi()
        {
            InitializeComponent();
            frmMenu frmM = new frmMenu();
            frmM.MdiParent = this;
            frmM.Show();
        }

        private void FrmMdi_Resize(object sender, EventArgs e)
        {
            for (int i=0; i < MdiChildren.Length;i++)
            {
                MdiChildren[i].Size = new Size(Size.Width - 20, Size.Height - 44);
            }
        }
    }
}
