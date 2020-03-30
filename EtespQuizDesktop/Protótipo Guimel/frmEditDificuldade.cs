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
    public partial class frmEditDificuldade : Form
    {
        Label lb1;
        Label lb2;
        DataTable diff;
        public frmEditDificuldade()
        {
            InitializeComponent();
            btnAdd.borderRadius = 15;
            btnVoltar.borderRadius = 15;
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddDificuldade frmAD = new frmAddDificuldade();
            frmAD.Size = Size;
            frmAD.Location = Location;
            Hide();
            frmAD.ShowDialog();
            this.Size = frmAD.Size;
            Location = frmAD.Location;
            Show();
            UpdateTable();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEditDificuldade_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        public void UpdateTable()
        {
            tableLayoutPanel1.SuspendLayout();
            try
            {

                diff = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT * FROM tbDificuldade ORDER BY DIF_VAL", Program.env);
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(lb1);
                tableLayoutPanel1.Controls.Add(lb2);
                if (diff.Rows.Count == 0)
                {
                    Label label1 = new Label();
                    label1.Font = lb1.Font;
                    label1.Dock = DockStyle.Fill;
                    label1.ForeColor = Color.Black;
                    label1.Text = "Ainda não há nenhuma dificuldade! Clique em 'Adicionar Dificuldade' para criar uma nova.";
                    tableLayoutPanel1.Controls.Add(label1, 0, 1);
                }
                else
                {
                    for (int i = 0; i < diff.Rows.Count; i++)
                    {
                        Label label1 = new Label();
                        Label label2 = new Label();
                        label1.Text = diff.Rows[i]["DIF_NOME"].ToString();
                        label1.Font = lb1.Font;
                        label1.ForeColor = Color.Black;
                        label1.Dock = DockStyle.Fill;
                        label1.Click += (sender, e) => { OpenAddDificuldade_EditMode(sender, e); };
                        label2.Text = diff.Rows[i]["DIF_VAL"].ToString();
                        label2.Font = lb1.Font;
                        label2.ForeColor = Color.Black;
                        label2.Dock = DockStyle.Fill;
                        label2.Click += (sender, e) => { OpenAddDificuldade_EditMode(sender, e); };
                        label1.Name = diff.Rows[i]["DIF_ID"].ToString();
                        label2.Name = diff.Rows[i]["DIF_ID"].ToString();
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
        private void OpenAddDificuldade_EditMode(object sender, EventArgs e)
        {
            frmAddDificuldade frmAP = new frmAddDificuldade((sender as Label).Name);
            frmAP.TopMost = true;
            frmAP.ShowDialog();
            UpdateTable();
            Show();
        }
        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
