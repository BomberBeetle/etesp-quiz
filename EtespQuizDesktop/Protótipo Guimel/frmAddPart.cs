using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETESP_Quiz
{
    public partial class frmAddPart : Form
    {
        FormMode Mode;
        DataTable part;
        DataTable eqp;
        string id;
        private enum FormMode
        {
            Add = 0,
            Edit = 1
        }
        public frmAddPart()
        {
            InitializeComponent();
            Mode = FormMode.Add;
            eqp = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT GP_ID, GP_NOME FROM tbGrupo", Program.env);
            if (eqp.Rows.Count != 0) {
                comboBox1.Items.Add("(SEM GRUPO)");
                foreach (DataRow r in eqp.Rows)
                {
                    comboBox1.Items.Add(r["GP_NOME"]);
                }
            }
            else {
                comboBox1.DropDownStyle = ComboBoxStyle.Simple;
                comboBox1.Text = "[NENHUMA EQUIPE EXISTE]";
                comboBox1.Enabled = false;
            }
            btnDelete.Visible = false;
        }
        public frmAddPart(string id)
        {
            InitializeComponent();
            Mode = FormMode.Edit;
            this.id = id;
            part = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbParticipante WHERE P_ID={0}", id), Program.env);
            eqp = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT GP_ID, GP_NOME FROM tbGrupo", Program.env);
            txtNome.Text = part.Rows[0]["P_NOME"].ToString();
            txtRm.Text = part.Rows[0]["P_RM"].ToString();
            comboBox1.Items.Add("(SEM GRUPO)");
            foreach (DataRow r in eqp.Rows)
            {
                comboBox1.Items.Add(r["GP_NOME"]);
            }
            if (!DBNull.Value.Equals(part.Rows[0]["P_GP_ID"])) comboBox1.SelectedIndex = comboBox1.FindStringExact(eqp.Select(String.Format("GP_ID={0}", part.Rows[0]["P_GP_ID"].ToString()))[0]["GP_NOME"].ToString());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza que quer deletar este participante? Esta ação não pode ser desfeita.",
                                     "Confirmar Ação",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbPart_Login WHERE P_ID={0}", id), Program.env);
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbParticipante WHERE P_ID={0}", id), Program.env);
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Regex rmRgx = new Regex(@"^[0-9]{5}$");
                if (!rmRgx.IsMatch(txtRm.Text)) throw new InvalidRMException();
                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_RM FROM tbParticipante WHERE P_RM='{0}'", txtRm.Text.Replace("'","''")), Program.env).Rows.Count != 0 && part.Rows[0]["P_RM"].ToString() != txtRm.Text) throw new RMInUseException();
                bool success = false;
                int userId;
                Random random = new Random();
                if (Mode == FormMode.Edit)
                {
                    if (comboBox1.Enabled && comboBox1.Text != "" && comboBox1.Text != "(SEM GRUPO)")
                    {
                        
                        if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbParticipante WHERE P_GP_ID={0}", eqp.Rows[comboBox1.SelectedIndex - 1]["GP_ID"].ToString()), Program.env).Rows.Count < 5 || eqp.Rows[comboBox1.SelectedIndex - 1]["GP_ID"].ToString() == part.Rows[0]["P_GP_ID"].ToString() )
                        {
                            if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbParticipante WHERE P_GP_ID={0}", GetPartGroup()), Program.env).Rows.Count == 1)
                            {

                                if (MessageBox.Show("Mudar o grupo deste participante deletará o grupo em que ele já está, pois não haverá nenhum participante no grupo. Deseja realmente mudar o grupo deste participante?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_NOME='{1}', P_RM='{2}', P_GP_ID={3} WHERE P_ID={0}", id, txtNome.Text, txtRm.Text, eqp.Rows[comboBox1.SelectedIndex - 1]["GP_ID"].ToString()), Program.env);
                                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupoAdmin WHERE GP_ID={0}", GetPartGroup()), Program.env);
                                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupo WHERE GP_ID={0}", GetPartGroup()), Program.env);
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbGrupoAdmin WHERE GP_ID={0}", GetPartGroup()), Program.env).Rows[0][0].ToString() == id)
                            {
                                if (MessageBox.Show("Esse participante é administrador de seu grupo. Remove-lo do grupo irá transferir o cargo para outro integrante. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_NOME='{1}', P_RM='{2}', P_GP_ID={3} WHERE P_ID={0}", id, txtNome.Text, txtRm.Text, eqp.Rows[comboBox1.SelectedIndex - 1]["GP_ID"].ToString()), Program.env);
                                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbGrupoAdmin SET P_ID='{1}' WHERE GP_ID={0}", GetPartGroup(), QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT TOP 1 P_ID FROM tbParticipante WHERE P_GP_ID={0}", GetPartGroup()), Program.env).Rows[0][0].ToString()), Program.env);
                                }
                                else
                                {
                                    return;
                                }

                            }
                            else
                            {
                                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_NOME='{1}', P_RM='{2}', P_GP_ID={3} WHERE P_ID={0}", id, txtNome.Text, txtRm.Text, eqp.Rows[comboBox1.SelectedIndex - 1]["GP_ID"].ToString()), Program.env);
                            }
                            }
                               
                        else
                        {
                            DatabaseInsertFail except = new DatabaseInsertFail("O grupo selecionado já tem 5 integrantes!");
                            throw except;
                        }
                    }
                    else
                    {
                        if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbParticipante WHERE P_GP_ID={0}", GetPartGroup()), Program.env).Rows.Count == 1)
                        {
                            if (MessageBox.Show("Mudar o grupo deste participante deletará o grupo em que ele já está, pois não haverá nenhum participante no grupo. Deseja realmente mudar o grupo deste participante?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_NOME='{1}', P_RM='{2}', P_GP_ID=NULL WHERE P_ID={0}", id, txtNome.Text, txtRm.Text), Program.env);
                                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupoAdmin WHERE GP_ID={0}",GetPartGroup()), Program.env);
                                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupo WHERE GP_ID={0}", GetPartGroup()), Program.env);
                            }

                            else
                            {
                                return;
                            }
                        }
                        else if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbGrupoAdmin WHERE GP_ID={0} AND P_ID={1}", GetPartGroup(), id), Program.env).Rows.Count == 1)
                        {
                            if (MessageBox.Show("Esse participante é administrador de seu grupo. Remove-lo do grupo irá transferir o cargo para outro integrante. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_NOME='{1}', P_RM='{2}', P_GP_ID=NULL WHERE P_ID={0}", id, txtNome.Text, txtRm.Text), Program.env);
                                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbGrupoAdmin SET P_ID='{1}' WHERE GP_ID={0}", GetPartGroup(), QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT TOP 1 P_ID FROM tbParticipante WHERE P_GP_ID={0}", GetPartGroup()), Program.env).Rows[0][0].ToString()), Program.env);
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_NOME='{1}', P_RM='{2}', P_GP_ID=NULL WHERE P_ID={0}", id, txtNome.Text, txtRm.Text), Program.env);
                        }
                        }

                    Close();
                }
                else
                {
                    
                    if (!comboBox1.Enabled || comboBox1.Text=="" || comboBox1.Text =="(SEM GRUPO)" )
                    {
                        for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                        {
                            userId = random.Next();
                            string queryPart = "";
                            queryPart = String.Format("INSERT INTO tbParticipante(P_ID, P_NOME, P_RM) VALUES({0},'{1}', '{2}')", userId, txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), txtRm.Text);
                            if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { success = true; MessageBox.Show("Participante adicionado com sucesso!(e muito carinho!)"); break; }
                        }
                    }
                    else
                    {
                        if (!(QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbParticipante WHERE P_GP_ID={0}", eqp.Rows[comboBox1.SelectedIndex - 1]["GP_ID"].ToString()), Program.env).Rows.Count < 5))
                        {
                            DatabaseInsertFail except = new DatabaseInsertFail("O grupo selecionado já tem 5 integrantes!");
                            throw except;
                        }
                        for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                        {
                            userId = random.Next();
                            string queryPart = "";
                            queryPart = String.Format("INSERT INTO tbParticipante(P_ID, P_NOME, P_RM, P_GP_ID) VALUES({0},'{1}', '{2}', {3})", userId, txtNome.Text.Replace("'", "''").Replace(@"\", @"\\"), txtRm.Text, eqp.Rows[comboBox1.SelectedIndex -1]["GP_ID"].ToString());
                            if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { success = true; MessageBox.Show("Participante adicionado com sucesso!(e muito carinho!)"); break; }
                        }
                    }
                    if (!success)
                    {
                        Exception exception = new Exception("Tente novamente, erro interno.");
                        throw exception;
                    }
                    Close();
                }
            }
            catch (InvalidRMException)
            {
                MessageBox.Show("O RM só deve conter 5 números (ex.: 12345)","ATENÇÃO");
            }
            catch (RMInUseException)
            {
                MessageBox.Show("O RM já está em uso", "ATENÇÃO");
            }
            catch(DatabaseInsertFail ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na operação. DEBUG: " + ex.Message, "ATENÇÃO");
            }
        }

        private void frmAddPart_Load(object sender, EventArgs e)
        {
            btnCancel.borderRadius = 10;
            btnDelete.borderRadius = 10;
            btnSave.borderRadius = 10;
        }
        private string GetPartGroup()
        {
            return (part.Rows[0]["P_GP_ID"].ToString() == "" ? "NULL" : part.Rows[0]["P_GP_ID"].ToString());
        }
    }
}
