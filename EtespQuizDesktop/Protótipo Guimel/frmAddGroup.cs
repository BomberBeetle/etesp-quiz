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
    public partial class frmAddGroup : Form
    {
        private enum FormMode
        {
            Add = 0,
            Edit = 1
        }

        FormMode Mode;
        DataTable parts;
        DataTable eqp;
        Label lb1;
        Label lb2;
        string id;
        public frmAddGroup()
        {
            InitializeComponent();
            btnCancel.borderRadius = 10;
            btnDelete.borderRadius = 10;
            btnSave.borderRadius = 10;
            button1.borderRadius = 15;
            Mode = FormMode.Add;
            Random random = new Random();
            btnDelete.Visible = false;
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
            for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
            {
                id = random.Next().ToString();
                string queryPart = "";
                queryPart = String.Format("INSERT INTO tbGrupo(GP_ID, GP_NOME, GP_FRASE, GP_COLOR) VALUES({0},'{1}', '{2}', '{3}')", id, txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), txtFrase.Text.Replace("'","''"), colorDialog1.Color.R.ToString("X2") + colorDialog1.Color.G.ToString("X2") + colorDialog1.Color.B.ToString("X2"));
                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { break; }
            }
        }
        public frmAddGroup(string id)
        {
            InitializeComponent();
            btnCancel.borderRadius = 10;
            btnDelete.borderRadius = 10;
            btnSave.borderRadius = 10;
            button1.borderRadius = 15;
            Mode = FormMode.Edit;
            this.id = id;
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
            UpdateTable();
            eqp = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbGrupo WHERE GP_ID={0}",id), Program.env);
            txtNome.Text = eqp.Rows[0]["GP_NOME"].ToString();
            txtFrase.Text = eqp.Rows[0]["GP_FRASE"].ToString();
            colorDialog1.Color = System.Drawing.ColorTranslator.FromHtml("#" + eqp.Rows[0]["GP_COLOR"].ToString());
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + eqp.Rows[0]["GP_COLOR"].ToString());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (Mode == FormMode.Edit)
            {
                this.Close();
            }
            else
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_GP_ID={id}", Program.env);
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"DELETE FROM tbGrupo WHERE GP_ID={id}", Program.env);
                Close();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Tem certeza que quer deletar este grupo? Quaisquer integrantes que estejam nele ficarão sem grupo.", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupoAdmin WHERE GP_ID = {0}", id), Program.env);
                QuizDBConnect.Query(Program.user, Program.pass,"dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_GP_ID = {0}", id),Program.env);
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupo WHERE GP_ID = {0}", id), Program.env);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEditPart frmAP = new frmEditPart(id);
            frmAP.Size = Size;
            frmAP.Location = Location;
            frmAP.Controls["label1"].Text = "Clique em um participante para adiciona-lo ao grupo";
            frmAP.UpdateTable();
            Hide();
            frmAP.ShowDialog();
            this.Size = frmAP.Size;
            Location = frmAP.Location;
            Show();
            UpdateTable();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            panel1.BackColor = colorDialog1.Color;
        }
        public void UpdateTable()
        {
            tableLayoutPanel1.SuspendLayout();
            try
            {

                parts = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbParticipante WHERE P_GP_ID={0}",id), Program.env);
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(lb1);
                tableLayoutPanel1.Controls.Add(lb2);
                if (parts.Rows.Count == 0)
                {
                    Label label1 = new Label();
                    label1.Font = label11.Font;
                    label1.Dock = DockStyle.Fill;
                    label1.Text = "Ainda não há nenhum participante! Clique em 'Adicionar Participante' para criar um novo.";
                    tableLayoutPanel1.Controls.Add(label1, 0, 1);
                }
                else
                {
                    for (int i = 0; i < parts.Rows.Count; i++)
                    {
                        Label label1 = new Label();
                        Label label2 = new Label();
                        label1.Text = parts.Rows[i]["P_NOME"].ToString();
                        label1.Font = label11.Font;
                        label1.Dock = DockStyle.Fill;
                        label1.Click += (sender, e) => { RemoveIntegrante(sender, e); };
                        label2.Text = parts.Rows[i]["P_RM"].ToString();
                        label2.Font = label11.Font;
                        label2.Dock = DockStyle.Fill;
                        label2.Click += (sender, e) => { RemoveIntegrante(sender, e); };
                        label1.Name = parts.Rows[i]["P_ID"].ToString();
                        label2.Name = parts.Rows[i]["P_ID"].ToString(); 
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
        private void RemoveIntegrante(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que quer remover este participante?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var pId = (sender as Label).Name;
                if (parts.Rows.Count == 1)
                {
                    if (MessageBox.Show("Remover o participante deletará o grupo , pois não haverá nenhum participante no grupo. Deseja realmente remover o participante do grupo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={0}", pId), Program.env);
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupoAdmin WHERE GP_ID={0}", id), Program.env);
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupo WHERE GP_ID={0}", id), Program.env);
                        Close();
                    }

                    else
                    {
                        return;
                    }
                }
                else if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbGrupoAdmin WHERE GP_ID={0} AND P_ID={1}", id,pId), Program.env).Rows.Count == 1)

                {
                    if (MessageBox.Show("Esse participante é administrador de seu grupo. Remove-lo do grupo irá transferir o cargo para outro integrante. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={0}", pId), Program.env);
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbGrupoAdmin SET P_ID='{1}' WHERE GP_ID={0}", id, QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT TOP 1 P_ID FROM tbParticipante WHERE P_GP_ID={0}", id), Program.env).Rows[0][0].ToString()), Program.env);
                        UpdateTable();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET  P_GP_ID=NULL WHERE P_ID={0}", pId), Program.env);
                    UpdateTable();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                MessageBox.Show("O nome do grupo não pode estar vazio!");
                return;
            }
            if(Mode == FormMode.Edit)
            {

                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT GP_ID FROM tbGrupo WHERE GP_NOME='{0}'", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\")), Program.env).Rows.Count < 1 || txtNome.Text == eqp.Rows[0]["GP_NOME"].ToString())
                {
                   QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbGrupo SET GP_NOME='{0}', GP_FRASE='{1}', GP_COLOR='{2}' WHERE GP_ID={3}", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), txtFrase.Text.Replace("'", "''").Replace(@"\", @"\\"), colorDialog1.Color.R.ToString("X2") + colorDialog1.Color.G.ToString("X2") + colorDialog1.Color.B.ToString("X2"), id), Program.env);
                    Close();
                }
                else
                {
                    MessageBox.Show("Este nome ja esta em uso por outro grupo.");
                }
            }
            else
            {
                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT GP_ID FROM tbGrupo WHERE GP_NOME='{0}'", txtNome.Text.Replace("'", "''").Replace(@"\", @"\\")), Program.env).Rows.Count < 1 )
                {
                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbGrupo SET GP_NOME='{1}', GP_FRASE='{2}', GP_COLOR='{3}' WHERE GP_ID={0}",id, txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), txtFrase.Text.Replace("'", "''").Replace(@"\", @"\\"), colorDialog1.Color.R.ToString("X2") + colorDialog1.Color.G.ToString("X2") + colorDialog1.Color.B.ToString("X2"), id), Program.env);
                    MessageBox.Show("Grupo adicionado com sucesso!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Este nome ja esta em uso por outro grupo.");
                }
            }
        }

        private void FrmAddGroup_Load(object sender, EventArgs e)
        {

        }
        public void ToggleReadOnly()
        {
            txtFrase.Enabled = false;
            txtNome.Enabled = false;
            panel1.Enabled = false;
            btnDelete.Visible = false;
            button1.Visible = false;
            btnSave.Visible = false;
            btnCancel.Text = "Voltar";
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                tableLayoutPanel1.Controls[i].Enabled = false;
            }
        }
    }
}
