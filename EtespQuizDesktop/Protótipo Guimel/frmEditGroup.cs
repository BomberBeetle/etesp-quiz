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
    public partial class frmEditGroup : Form
    {
        Label lb1;
        Label lb2;
        Label lb3;
        DataTable eqp = new DataTable();

        public frmEditGroup()
        {
            InitializeComponent();
            btnAdd.borderRadius = 15;
            btnVoltar.borderRadius = 15;
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
            lb3 = tableLayoutPanel1.Controls[2] as Label;
        }
        
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmAddGroup frmAG = new frmAddGroup();
            frmAG.Size = Size;
            frmAG.Location = Location;
            Hide();
            frmAG.ShowDialog();
            this.Size = frmAG.Size;
            Location = frmAG.Location;
            Show();
            UpdateTable();
        }

        private void frmEditGroup_Load(object sender, EventArgs e)
        {
        }
        public void UpdateTable()
        {
            UpdateData();
            UpdatePanel();
        }
        public void UpdateData()
        {
            eqp = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT * FROM tbGrupo", Program.env);
        }
        public void UpdatePanel()
        {
            tableLayoutPanel1.SuspendLayout();
            try
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(lb1);
                tableLayoutPanel1.Controls.Add(lb2); 
                tableLayoutPanel1.Controls.Add(lb3);
                if (eqp.Rows.Count == 0)
                {
                    Label label1 = new Label();
                    label1.Font = lb1.Font;
                    label1.Dock = DockStyle.Fill;
                    label1.Text = "Ainda não há nenhum grupo! Clique em 'Adicionar Grupo' para criar um novo.";
                    tableLayoutPanel1.Controls.Add(label1, 0, 1);
                }
                else
                {
                    for (int i = 0; i < eqp.Rows.Count; i++)
                    {
                        if(eqp.Rows[i]["GP_NOME"].ToString().Contains(textBox1.Text) || eqp.Rows[i]["GP_FRASE"].ToString().Contains(textBox1.Text)|| eqp.Rows[i]["GP_ID"].ToString().Contains(textBox1.Text)) {
                            Label label1 = new Label();
                            Label label2 = new Label();
                            Label label3 = new Label();
                            label1.Text = eqp.Rows[i]["GP_NOME"].ToString();
                            label1.Font = lb1.Font;
                            label1.Dock = DockStyle.Fill;
                            label1.Click += (sender, e) => { OpenAddGroup_EditMode(sender, e); };
                            label2.Text = eqp.Rows[i]["GP_FRASE"].ToString();
                            label2.Font = lb1.Font;
                            label2.Dock = DockStyle.Fill;
                            label2.Click += (sender, e) => { OpenAddGroup_EditMode(sender, e); };
                            label3.Text = eqp.Rows[i]["GP_ID"].ToString();
                            label3.Font = lb1.Font;
                            label3.Dock = DockStyle.Fill;
                            label3.Click += (sender, e) => { OpenAddGroup_EditMode(sender, e); };
                            label1.Name = eqp.Rows[i]["GP_ID"].ToString();
                            label2.Name = eqp.Rows[i]["GP_ID"].ToString();
                            label3.Name = eqp.Rows[i]["GP_ID"].ToString();
                            label1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + eqp.Rows[i]["GP_COLOR"].ToString());
                            label2.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + eqp.Rows[i]["GP_COLOR"].ToString());
                            label3.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + eqp.Rows[i]["GP_COLOR"].ToString());
                            tableLayoutPanel1.Controls.Add(label1, 0, i + 1);
                            tableLayoutPanel1.Controls.Add(label2, 1, i + 1);
                            tableLayoutPanel1.Controls.Add(label3, 2, i + 1);
                        }
                    }
                    Label separator = new Label();
                    tableLayoutPanel1.Controls.Add(separator, 0, tableLayoutPanel1.GetColumnWidths().Length + (eqp.Rows.Count - 2) );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tableLayoutPanel1.ResumeLayout();
            }
        }                  
        private void OpenAddGroup_EditMode(object sender, EventArgs e)
        {
            frmAddGroup frmAP = new frmAddGroup((sender as Label).Name);
            frmAP.TopMost = true;
            frmAP.ShowDialog();
            UpdateTable();
            Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdatePanel();
        }
    }
}

