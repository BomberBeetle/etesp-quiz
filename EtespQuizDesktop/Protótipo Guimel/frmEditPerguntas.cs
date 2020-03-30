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
    public partial class frmEditPerguntas : Form
    {
        DataTable qst;
        public frmEditPerguntas()
        {
            InitializeComponent();
            btnAdd.borderRadius = 15;
            btnVoltar.borderRadius = 15;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
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

        private void frmEditPerguntas_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    qst = qst.Select("1=1", "Q_TITULO ASC").CopyToDataTable();
                    break;
                case 2:
                    qst = qst.Select("1=1", "T_NOME ASC").CopyToDataTable();
                    break;
                case 1:
                    qst = qst.Select("1=1", "DIF_NOME ASC").CopyToDataTable();
                    break;
                case 3:
                    qst = qst.Select("1=1", "Q_ISALTERNATIVE ASC").CopyToDataTable();
                    break;
            }
            UpdatePanel();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdatePanel();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateTable()
        {
            UpdateData();
            UpdatePanel();
        }
        public void UpdateData()
        {
            qst = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT tbQuestao.Q_TITULO, tbDificuldade.DIF_NOME, tbTopico.T_NOME, tbQuestao.Q_ISALTERNATIVE, tbQuestao.Q_ID, tbQuestao.Q_ENABLED  FROM tbQuestao, tbDificuldade, tbTopico WHERE tbQuestao.Q_TOPICO_ID=tbTopico.T_ID  AND tbQuestao.DIF_ID=tbDificuldade.DIF_ID ", Program.env);
        }
        public void UpdatePanel()
        {
            tableLayoutPanel1.SuspendLayout();
            try
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(headerT);
                tableLayoutPanel1.Controls.Add(headerD);
                tableLayoutPanel1.Controls.Add(headerM);
                tableLayoutPanel1.Controls.Add(headerTp);
                tableLayoutPanel1.Controls.Add(headerH);

                if (qst.Rows.Count == 0)
                {
                    Label label1 = new Label();
                    label1.Font = headerT.Font;
                    label1.Dock = DockStyle.Fill;
                    label1.ForeColor = Color.Black;
                    label1.Text = "Ainda não há nenhuma questão! Clique em 'Adicionar Questão' para criar uma nova.";
                    tableLayoutPanel1.Controls.Add(label1, 0, 1);
                }
                else
                {
                    for (int i = 0; i < qst.Rows.Count; i++)
                    {
                        if (qst.Rows[i]["Q_TITULO"].ToString().Contains(textBox1.Text))
                        {
                            Label label1 = new Label();
                            Label label2 = new Label();
                            Label label3 = new Label();
                            Label label4 = new Label();
                            Label label5 = new Label();
                            label1.Text = qst.Rows[i]["Q_TITULO"].ToString();
                            label1.Font = headerT.Font;
                            label1.ForeColor = Color.Black;
                            label1.Dock = DockStyle.Fill;
                            label1.Click += (sender, e) => { OpenAddPergunta_EditMode(sender, e); };

                            label2.Text = qst.Rows[i]["DIF_NOME"].ToString();
                            label2.Font = headerT.Font;
                            label2.ForeColor = Color.Black;
                            label2.Dock = DockStyle.Fill;
                            label2.Click += (sender, e) => { OpenAddPergunta_EditMode(sender, e); };

                            label3.Text = qst.Rows[i]["T_NOME"].ToString();
                            label3.Font = headerT.Font;
                            label3.ForeColor = Color.Black;
                            label3.Dock = DockStyle.Fill;
                            label3.Click += (sender, e) => { OpenAddPergunta_EditMode(sender, e); };

                            label4.Text = qst.Rows[i]["Q_ISALTERNATIVE"].ToString() == "True" ? "Teste" : "Dissertativa";
                            label4.Font = headerT.Font;
                            label4.ForeColor = Color.Black;
                            label4.Dock = DockStyle.Fill;
                            label4.Click += (sender, e) => { OpenAddPergunta_EditMode(sender, e); };

                            label5.Text = qst.Rows[i]["Q_ENABLED"].ToString() == "True" ? "Habilitada" : "Desabilitada";
                            label5.Font = headerT.Font;
                            label5.ForeColor = Color.Black;
                            label5.Dock = DockStyle.Fill;
                            label5.Click += (sender, e) => { OpenAddPergunta_EditMode(sender, e); };

                            label1.Name = qst.Rows[i]["Q_ID"].ToString();
                            label2.Name = qst.Rows[i]["Q_ID"].ToString();
                            label3.Name = qst.Rows[i]["Q_ID"].ToString();
                            label4.Name = qst.Rows[i]["Q_ID"].ToString();
                            label5.Name = qst.Rows[i]["Q_ID"].ToString();

                            tableLayoutPanel1.Controls.Add(label1, 0, i + 1);
                            tableLayoutPanel1.Controls.Add(label2, 1, i + 1);
                            tableLayoutPanel1.Controls.Add(label3, 2, i + 1);
                            tableLayoutPanel1.Controls.Add(label4, 3, i + 1);
                            tableLayoutPanel1.Controls.Add(label5, 4, i + 1);
                        }
                    }
                    Label separator = new Label();
                    tableLayoutPanel1.Controls.Add(separator, 0, tableLayoutPanel1.GetColumnWidths().Length + (qst.Rows.Count - 2));
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

        private void OpenAddPergunta_EditMode(object sender, EventArgs e)
        {
            frmAddPergunta frmAP = new frmAddPergunta((sender as Label).Name);
            frmAP.Size = Size;
            frmAP.Location = Location;
            Hide();
            frmAP.ShowDialog();
            this.Size = frmAP.Size;
            Location = frmAP.Location;
            Show();
            UpdateTable();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
