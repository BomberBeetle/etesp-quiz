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
    public partial class frmEditTopico : Form
    {
        DataTable top;
        Label lb1;
        Label lb2;
        public frmEditTopico()
        {
            InitializeComponent();
            btnAdd.borderRadius = 15;
            btnVoltar.borderRadius = 15;
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddTopico frmAT = new frmAddTopico();
            frmAT.Size = Size;
            frmAT.Location = Location;
            Hide();
            frmAT.ShowDialog();
            UpdateTable();
            this.Size = frmAT.Size;
            Location = frmAT.Location;
            Show();
        }

        private void frmEditTopico_Load(object sender, EventArgs e)
        {

        }
        public void UpdateTable()
        {
            tableLayoutPanel1.SuspendLayout();
            try
            {

                top = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT * FROM tbTopico", Program.env);
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(lb1);
                tableLayoutPanel1.Controls.Add(lb2);
                if (top.Rows.Count == 0)
                {
                    Label label1 = new Label();
                    label1.Font = lb1.Font;
                    label1.Dock = DockStyle.Fill;
                    label1.ForeColor = Color.Black;
                    label1.Text = "Ainda não há nenhuma matéria! Clique em 'Adicionar Matéria' para criar uma nova.";
                    tableLayoutPanel1.Controls.Add(label1, 0, 1);
                }
                else
                {
                    for (int i = 0; i < top.Rows.Count; i++)
                    {
                        Label label1 = new Label();
                        Label label2 = new Label();
                        label1.Text = top.Rows[i]["T_NOME"].ToString();
                        label1.Font = lb1.Font;
                        label1.ForeColor = Color.Black;
                        label1.Dock = DockStyle.Fill;
                        label1.Click += (sender, e) => { OpenAddTopico_EditMode(sender, e); };
                        label2.Text = top.Rows[i]["T_ID"].ToString();
                        label2.Font = lb1.Font;
                        label2.ForeColor = Color.Black;
                        label2.Dock = DockStyle.Fill;
                        label2.Click += (sender, e) => { OpenAddTopico_EditMode(sender, e); };
                        label1.Name = top.Rows[i]["T_ID"].ToString();
                        label2.Name = top.Rows[i]["T_ID"].ToString();
                        tableLayoutPanel1.Controls.Add(label1, 0, i + 1);
                        tableLayoutPanel1.Controls.Add(label2, 1, i + 1);
                    }
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
        private void OpenAddTopico_EditMode(object sender, EventArgs e)
        {
            frmAddTopico frmAP = new frmAddTopico((sender as Label).Name);
            frmAP.TopMost = true;
            frmAP.ShowDialog();
            UpdateTable();
            Show();
        }
    }
}
