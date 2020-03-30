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
    public partial class frmQuizConfig : Form
    {
        DataTable dif;
        DataTable mat;
        DataTable eqp;
        DataTable pergs;
        DataTable parts;

        public frmQuizConfig()
        {
            InitializeComponent();
            btnJogar.borderRadius = 30;
            button1.borderRadius = 15;
            dif = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbDificuldade", Program.env);
            mat  = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbTopico", Program.env);
            parts = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbParticipante", Program.env);
            eqp = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbGrupo", Program.env);
            pergs = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbQuestao", Program.env);
            dif.Columns.Add("ENABLED");
            DataColumn num = new DataColumn();
            num.DefaultValue = 0;
            num.ColumnName = "NUM_Q";
            dif.Columns.Add(num);


            mat.Columns.Add("ENABLED");

            eqp.Columns.Add("ENABLED");
            

        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (eqp.Select("ENABLED = 'True'").Count() < 1)
            {
                MessageBox.Show("Pelo menos um grupo deve estar participando!");
                return;
            }
            if (dif.Select("ENABLED = 'True'").Count() < 1)
            {
                MessageBox.Show("Pelo menos uma dificuldade deve estar habilitada!");
                return;
            }
            if (mat.Select("ENABLED = 'True'").Count() < 1)
            {
                MessageBox.Show("Pelo menos uma matéria deve estar habilitada!");
                return;
            }
            var stringAviso = "Dificuldades Selecionadas: ";

            var dificuldades = new List<string>();
            foreach (DataRow r in dif.Select("ENABLED = 'True'"))
            {
                dificuldades.Add(r["DIF_NOME"].ToString());
            }
            stringAviso += string.Join(",", dificuldades);

            var materias = new List<string>();
            foreach (DataRow r in mat.Select("ENABLED = 'True'"))
            {
                materias.Add(r["T_NOME"].ToString());
            }
            stringAviso += "\nMaterias Selecionadas: " +  string.Join(",",  materias);

            var grupos = new List<string>();
            foreach (DataRow r in eqp.Select("ENABLED = 'True'"))
            {
                grupos.Add(r["GP_NOME"].ToString());
            }
            stringAviso += "\nGrupos Selecionados: " + string.Join(",", grupos);
            stringAviso += "\n Deseja começar o Quiz?";

            if (MessageBox.Show(stringAviso, "Continuar?", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            var dc = new DataColumn();
            dc.DefaultValue = 0;
            dc.DataType = typeof(int);
            dc.ColumnName = "PONTOS";
            eqp.Columns.Add(dc);

            var dc1 = new DataColumn();
            dc1.DefaultValue = 0;
            dc1.ColumnName = "ACERTOS";
            eqp.Columns.Add(dc1);

            
            JogoStatic.TempoQuestao = (int)numericUpDown1.Value;
            JogoStatic.ErrosPermitidos = (int)numericUpDown3.Value;
            JogoStatic.TimerAutomatic = checkBox5.Checked;
            JogoStatic.MostrarDissertativas = checkBox4.Checked;
            JogoStatic.Equipes = eqp.Select("ENABLED = 'True'").CopyToDataTable();
            var listIds = new List<string>();
            foreach(DataRow r in JogoStatic.Equipes.Rows)
            {
                listIds.Add(r["GP_ID"].ToString());
            }
            try
            {
                JogoStatic.Participantes = parts.Select($"P_GP_ID IN ({string.Join(",", listIds)})").CopyToDataTable();
            }
            catch
            {
                MessageBox.Show("Não existem participantes em nenhum dos grupos!");
                return;
            }
            JogoStatic.Imagens = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbImagem", Program.env);
            JogoStatic.Dificuldades  = dif.Select("ENABLED = 'True'").CopyToDataTable();
            JogoStatic.DifTopQuiz = dif.Rows[comboBox4.SelectedIndex];
            JogoStatic.DifRepescagem = dif.Rows[comboBox5.SelectedIndex];
            JogoStatic.Materias = mat.Select("ENABLED = 'True'").CopyToDataTable();
            var c = new DataColumn("ERROS");
            var v = new DataColumn("VIDAS_EXTRA");
            c.DefaultValue = 0;
            v.DefaultValue = 0;
            JogoStatic.Equipes.Columns.Add(c);
            JogoStatic.Equipes.Columns.Add(v);

            var listIdsD = new List<string>();
            foreach (DataRow r in JogoStatic.Dificuldades.Rows)
            {
                listIdsD.Add(r["DIF_ID"].ToString());
            }

            var listIdsT = new List<string>();
            foreach (DataRow r in JogoStatic.Materias.Rows)
            {
                listIdsT.Add(r["T_ID"].ToString());
            }
            try
            {
                JogoStatic.Perguntas = pergs.Select($"DIF_ID IN ({string.Join(",", listIdsD)},{JogoStatic.DifTopQuiz["DIF_ID"]}) AND Q_TOPICO_ID IN ({string.Join(",", listIdsT)})").CopyToDataTable();
            }
            catch
            {
                MessageBox.Show("Não há nenhuma questão elegível para o Top Quiz");
                return;
            }
            JogoStatic.TopQuizNQ = (int)numericUpDown4.Value;
            var listIdsQ = new List<string>();
            foreach (DataRow r in JogoStatic.Perguntas.Rows)
            {
                listIdsQ.Add(r["Q_ID"].ToString());
            }
            JogoStatic.Alternativas = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"SELECT * FROM tbAlternativas WHERE ALT_Q_ID IN ({string.Join(",", listIdsQ)})", Program.env);
            Hide();
            JogoStatic.GameLoop();
            Close();
        }

        private void FrmQuizConfig_Load(object sender, EventArgs e)
        {
            if (dif.Rows.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos uma dificuldade! ([EDITAR QUIZ] -> [ADICIONAR DIFICULDADE])");
                Close();
                return;
            }
            if (mat.Rows.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos uma matéria! ([EDITAR QUIZ] -> [ADICIONAR MATÉRIA])");
                Close();
                return;
            }
            if (eqp.Rows.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos uma equipe! ([EQUIPES] -> [ADICIONAR EQUIPE])");
                Close();
                return;
            }
            if (pergs.Rows.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos uma pergunta! ([EDITAR QUIZ] -> [ADICIONAR PERGUNTA])");
                Close();
                return;
            }
            foreach (DataRow r in dif.Rows)
            {
                comboBox2.Items.Add(r["DIF_NOME"]);
                comboBox4.Items.Add(r["DIF_NOME"]);
                comboBox5.Items.Add(r["DIF_NOME"]);
            }
            comboBox2.SelectedIndex = 0;

            foreach (DataRow r in mat.Rows)
            {
                comboBox1.Items.Add(r["T_NOME"]);
            }
            comboBox1.SelectedIndex = 0;

            foreach (DataRow r in eqp.Rows)
            {
                comboBox3.Items.Add(r["GP_NOME"]);
            }
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            numericUpDown4.Maximum = pergs.Select($"DIF_ID = {dif.Rows[comboBox2.SelectedIndex]["DIF_ID"]}AND Q_ENABLED = 'True'").Count();

        }

        private void numericUpDown2_Leave(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = dif.Rows[comboBox2.SelectedIndex]["ENABLED"].ToString() == "True";
            label8.Text = $"Questões Habilitadas: {pergs.Select($"DIF_ID = {dif.Rows[comboBox2.SelectedIndex]["DIF_ID"]}AND Q_ENABLED = 'True'").Count()} ";
            numericUpDown2.Maximum = pergs.Select($"DIF_ID = {dif.Rows[comboBox2.SelectedIndex]["DIF_ID"]}AND Q_ENABLED = 'True'").Count();
            numericUpDown2.Value = int.Parse(dif.Rows[comboBox2.SelectedIndex]["NUM_Q"].ToString());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0 && checkBox2.Checked)
            {
                checkBox2.Checked = false;
                MessageBox.Show("Uma dificuldade habilitada não pode ter o seu número de questões no Quiz como 0!");
                return;
            }
            dif.Rows[comboBox2.SelectedIndex]["ENABLED"] = checkBox2.Checked.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = mat.Rows[comboBox1.SelectedIndex]["ENABLED"].ToString() == "True";
            label7.Text = $"Número total de questões habilitadas da matéria: { pergs.Select($"Q_TOPICO_ID = {mat.Rows[comboBox1.SelectedIndex]["T_ID"]}AND Q_ENABLED = 'True'").Count()}\n";
            foreach(DataRow r in dif.Rows)
            {
                label7.Text += $"\nDificuldade {r["DIF_NOME"].ToString()}: {pergs.Select($"Q_TOPICO_ID = {mat.Rows[comboBox1.SelectedIndex]["T_ID"]} AND DIF_ID = {r["DIF_ID"]} AND Q_ENABLED='True'").Count()}";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mat.Rows[comboBox1.SelectedIndex]["ENABLED"] = checkBox1.Checked.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = eqp.Rows[comboBox3.SelectedIndex]["ENABLED"].ToString() == "True";
            label9.Text = $"Quantidade de Integrantes: {parts.Select($"P_GP_ID = {eqp.Rows[comboBox3.SelectedIndex]["GP_ID"].ToString()}").Count()}";

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (parts.Select($"P_GP_ID = {eqp.Rows[comboBox3.SelectedIndex]["GP_ID"].ToString()}").Count() < 1)
            {
                MessageBox.Show("Uma equipe não pode participar no Quiz sem participantes!");
                checkBox3.Checked = false;
            }
            else
            {
                eqp.Rows[comboBox3.SelectedIndex]["ENABLED"] = checkBox3.Checked.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmAddGroup(eqp.Rows[comboBox3.SelectedIndex]["GP_ID"].ToString());
            frm.ToggleReadOnly();
            frm.ShowDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0 && checkBox2.Checked)
            {
                numericUpDown2.Value = 1;
                MessageBox.Show("Uma dificuldade habilitada não pode ter o seu número de questões no Quiz como 0!");
            }
            else
            {
                dif.Rows[comboBox2.SelectedIndex]["NUM_Q"] = numericUpDown2.Value;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = $"Questões Habilitadas: {pergs.Select($"DIF_ID = {dif.Rows[comboBox4.SelectedIndex]["DIF_ID"]}AND Q_ENABLED = 'True'").Count()} ";
            numericUpDown4.Maximum = pergs.Select($"DIF_ID = {dif.Rows[comboBox4.SelectedIndex]["DIF_ID"]}AND Q_ENABLED = 'True'").Count();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            label19.Text = $"Questões Habilitadas: {pergs.Select($"DIF_ID = {dif.Rows[comboBox5.SelectedIndex]["DIF_ID"]}AND Q_ENABLED = 'True'").Count()} ";
        }
    }
  }

