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
    public partial class frmAddTopico : Form
    {
        FormMode Mode;
        string id;
        DataTable top;
        private enum FormMode
        {
            Add = 0,
            Edit = 1
        }
        public frmAddTopico()
        {
            InitializeComponent();
            btnCancel.borderRadius = 15;
            btnSave.borderRadius = 15;
            btnDelete.borderRadius = 15;
            Mode = FormMode.Add;
            btnDelete.Visible = false;
        }
        public frmAddTopico(string id)
        {
            InitializeComponent();
            btnCancel.borderRadius = 15;
            btnSave.borderRadius = 15;
            btnDelete.borderRadius = 15;
            Mode = FormMode.Edit;
            top = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbTopico WHERE T_ID={0}", id), Program.env);
            txtNome.Text = top.Rows[0]["T_NOME"].ToString();
            this.id = id;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Mode == FormMode.Edit)
            {
                if(QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT T_ID FROM tbTopico WHERE T_NOME='{0}'", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\")), Program.env).Rows.Count < 1 || txtNome.Text.Replace("'","''").Replace(@"\", @"\\") == top.Rows[0]["T_NOME"].ToString() && txtNome.Text != "")
                {
                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbTopico SET T_NOME='{0}' WHERE T_ID={1}", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), id), Program.env);
                    Close();
                }
                else
                {
                    if (txtNome.Text == "")
                    {
                        MessageBox.Show("O nome da matéria não pode ser vazio!");
                    }
                    else
                    {
                        MessageBox.Show("Já há uma matéria com este nome!");
                    }
                }
            }
            else
            {
                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT T_ID FROM tbTopico WHERE T_NOME='{0}'", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\")), Program.env).Rows.Count < 1 && txtNome.Text != "")
                {
                    Random random = new Random();
                    for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                    {
                        id = random.Next().ToString();
                        string queryPart = "";
                        queryPart = String.Format("INSERT INTO tbTopico(T_ID, T_NOME) VALUES({0},'{1}')", id, txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"));
                        if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { MessageBox.Show("Tópico adicionado com sucesso!(e muito carinho!)"); Close(); break; }
                    }
                }
                else
                {
                    if (txtNome.Text == "")
                    {
                        MessageBox.Show("O nome da matéria não pode ser vazio!");
                    }
                    else
                    {
                        MessageBox.Show("Já há uma matéria com este nome!");
                    }
                }
            }
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int quests = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT Q_ID FROM tbQuestao WHERE Q_TOPICO_ID={0}", id), Program.env).Rows.Count;
            var confirmResult = MessageBox.Show($"Tem certeza que quer deletar este tópico? As {quests} questões que usam ele serão deletadas do Quiz permanentemente!",
                                     "Confirmar Ação",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELTE FROM tbQuestao WHERE Q_TOPICO_ID={0}", id), Program.env);
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbTopico WHERE T_ID={0}", id), Program.env);
                Close();
            }
        }
    }
}
