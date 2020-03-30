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
    
    public partial class frmEditAlts : Form
    {
        public DataTable alts;
        public bool returned;
        public frmEditAlts()
        {
            InitializeComponent();
            btnCancel.borderRadius = 15;
            btnSave.borderRadius = 15;
            returned = false;
        }
        private void frmEditAlts_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void LoadAlternatives(DataTable alts)
        {
            this.alts = alts;
            for(int i = 0; i < alts.Rows.Count; i++)
            {
                panel1.Controls[i].Text = alts.Rows[i]["ALT_TEXTO"].ToString();
                (panel2.Controls[i] as RadioButton).Checked = alts.Rows[i]["ALT_CERTA"].ToString() == "True";
            }
        }

        private void txtNome_EnabledChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = (sender as TextBox).Enabled ? SystemColors.Control : Color.DarkGray;
        }

        public DataTable GetAlternativas()
        {
            List<string> lst = new List<string>();
            foreach (Control c in panel1.Controls)
            {
                lst.Add(c.Text);
            }
            Predicate<string> pre = delegate (string a) { return a == ""; };
            lst.RemoveAll(pre);
            DataTable ret = new DataTable();
            ret.Columns.Add("ALT_TEXTO");
            ret.Columns.Add("ALT_CERTA");
            for(int i = 0; i < lst.Count; i++)
            {
                ret.Rows.Add();
                ret.Rows[i]["ALT_TEXTO"] = panel1.Controls[i].Text;
                ret.Rows[i]["ALT_CERTA"] = (panel2.Controls[i] as RadioButton).Checked ? "1" : "0";
            }
            returned = true;
            return ret;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                (panel1.Controls[i] as TextBox).TextChanged -= textBox1_TextChanged;
            }

            List<string> lst = new List<string>();
            foreach(Control c in panel1.Controls)
            {
                lst.Add(c.Text);
            }
            Predicate<string> pre = delegate(string a){ return a == ""; };
            lst.RemoveAll(pre);
            int count = lst.Count;
            for (int i = count + 1; i < 5; i++)
            {
                panel1.Controls[i].Enabled = false;
                if((panel2.Controls[i] as RadioButton).Checked)
                {
                    (panel2.Controls[0] as RadioButton).Checked = true;
                }
               panel2.Controls[i].Enabled = false;
            }
            if(count < 5)
            {
                panel1.Controls[count].Text = "";
                panel1.Controls[count].Enabled = true;
                panel2.Controls[count].Enabled = false;
                if ((panel2.Controls[count] as RadioButton).Checked && count != 0)
                {
                    (panel2.Controls[count - 1] as RadioButton).Checked = true;
                }
            }
            for (int i = 0; i < count; i++)
            {
                panel1.Controls[i].Text = lst[i];
                panel1.Controls[i].Enabled = true;
                panel2.Controls[i].Enabled = true;
            }
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                (panel1.Controls[i] as TextBox).TextChanged += textBox1_TextChanged;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            foreach (Control c in panel1.Controls)
            {
                lst.Add(c.Text);
            }
            Predicate<string> pre = delegate (string a) { return a == ""; };
            lst.RemoveAll(pre);
            int count = lst.Count;
            if(count < 2)
            {
                MessageBox.Show("Insira pelo menos duas alternativas!");
                return;
            }
            returned = true;
            Close();
        }
    }
}
