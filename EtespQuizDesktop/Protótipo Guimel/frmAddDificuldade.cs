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
    public partial class frmAddDificuldade : Form
    {
        DataTable dif;
        FormMode Mode;
        string id;
        private enum FormMode
        {
            Add = 0,
            Edit = 1
        }
        public frmAddDificuldade()
        {
            InitializeComponent();
            btnCancel.borderRadius = 10;
            btnDelete.borderRadius = 10;
            btnSave.borderRadius = 10;
            Mode = FormMode.Add;
            btnDelete.Visible = false;
        }
        public frmAddDificuldade(string id)
        {
            this.id = id;
            InitializeComponent();
            btnCancel.borderRadius = 10;
            btnDelete.borderRadius = 10;
            btnSave.borderRadius = 10;
            Mode = FormMode.Edit;
            dif = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbDificuldade WHERE DIF_ID={id}", Program.env);
            txtNome.Text = dif.Rows[0]["DIF_NOME"].ToString();
            nudVal.Value = Int32.Parse(dif.Rows[0]["DIF_VAL"].ToString());
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == FormMode.Edit)
            {

                if ((QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT DIF_ID FROM tbDificuldade WHERE DIF_NOME='{0}' AND NOT DIF_ID={2} OR DIF_VAL={1} AND NOT DIF_ID={2}", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), nudVal.Value, id), Program.env).Rows.Count < 1 || (txtNome.Text.Replace("'", "''").Replace(@"\", @"\\") == dif.Rows[0]["DIF_NOME"].ToString() && nudVal.Value == int.Parse(dif.Rows[0]["DIF_VAL"].ToString()))) && txtNome.Text != "")
                {
                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbDificuldade SET DIF_NOME='{0}', DIF_VAL={1} WHERE DIF_ID={2}", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), nudVal.Value, id), Program.env);
                    Close();
                }
                else
                {
                    if (txtNome.Text == "")
                    {
                        MessageBox.Show("O nome da dificuldade não pode ser vazio!");
                    }
                    else
                    {
                        MessageBox.Show("Já há uma dificuldade com este nome/intensidade!");
                    }
                }
            }
            else
            {
                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT DIF_ID FROM tbDificuldade WHERE DIF_NOME='{0}' OR DIF_VAL={1}", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), nudVal.Value), Program.env).Rows.Count < 1 && txtNome.Text != "")
                {
                    Random random = new Random();
                    for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                    {
                        id = random.Next().ToString();
                        string queryPart = "";
                        queryPart = String.Format("INSERT INTO tbDificuldade(DIF_ID, DIF_NOME, DIF_VAL) VALUES({0},'{1}', {2})", id, txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"),nudVal.Value);
                        if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { MessageBox.Show("Dificuldaade adicionada com sucesso!(e muito carinho!)"); Close(); break; }
                    }
                }
                else
                {
                    if (txtNome.Text == "")
                    {
                        MessageBox.Show("O nome da dificuldade não pode ser vazio!");
                    }
                    else
                    {
                        MessageBox.Show("Já há uma dificuldade com este nome/intensidade!");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int quests = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT Q_ID FROM tbQuestao WHERE DIF_ID={0}", id), Program.env).Rows.Count;
            var confirmResult = MessageBox.Show($"Tem certeza que quer deletar estaa dificuldade? As {quests} questões que usam ele serão deletadas permanentemente do Quiz!",
                                     "Confirmar Ação",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbQuestao WHERE DIF_ID={0}", id), Program.env);
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbDificuldade WHERE DIF_ID={0}", id), Program.env);
                Close();
            }
        }
    }
}
