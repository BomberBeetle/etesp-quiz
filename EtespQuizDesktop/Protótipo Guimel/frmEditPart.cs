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
    public partial class frmEditPart : Form
    {
        public enum FormMode
        {
            Normal = 0,
            SelectIntegrantes = 1
        }
        FormMode Mode;
        Label lb1;
        Label lb2;
        Label lb3;
        DataTable eqp = new DataTable();
        DataTable parts = new DataTable();
        string gpId;
        
        public frmEditPart()
        {
            InitializeComponent();
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
            lb3 = tableLayoutPanel1.Controls[2] as Label;
            btnAdd.borderRadius = 15;
            btnVoltar.borderRadius = 15;
            Mode = FormMode.Normal;
        }
        public frmEditPart(string id)
        {
            InitializeComponent();
            lb1 = tableLayoutPanel1.Controls[0] as Label;
            lb2 = tableLayoutPanel1.Controls[1] as Label;
            lb3 = tableLayoutPanel1.Controls[2] as Label;
            btnAdd.borderRadius = 15;
            btnVoltar.borderRadius = 15;
            Mode = FormMode.SelectIntegrantes;
            gpId = id;
        }


        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmAddPart frmAP = new frmAddPart();
            frmAP.TopMost = true;
            frmAP.ShowDialog();
            UpdateTable();
            Show();
        }

        private void OpenAddPart_EditMode(object sender, EventArgs e)
        {
        	frmAddPart frmAP = new frmAddPart((sender as Label).Name);
            frmAP.TopMost = true;
            frmAP.ShowDialog();
            UpdateTable();
            Show();
        }
        private void frmEditPart_Load(object sender, EventArgs e)
        {
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
                    for (int i = 0; i < parts.Rows.Count; i++) {
                        if (parts.Rows[i]["P_NOME"].ToString().Contains(textBox1.Text) || parts.Rows[i]["P_RM"].ToString().Contains(textBox1.Text))
                        {

                            Label label1 = new Label();
                            Label label2 = new Label();
                            Label label3 = new Label();
                            label1.Text = parts.Rows[i]["P_NOME"].ToString();
                            label1.Font = label11.Font;
                            label1.Dock = DockStyle.Fill;
                            if (Mode == FormMode.Normal)
                            {
                                label1.Click += (sender, e) => { OpenAddPart_EditMode(sender, e); };
                            }
                            else
                            {
                                label1.Click += (sender, e) => { SelectPart(sender, e); };
                            }
                            label2.Text = parts.Rows[i]["P_RM"].ToString();
                            label2.Font = label11.Font;
                            label2.Dock = DockStyle.Fill;
                            if (Mode == FormMode.Normal)
                            {
                                label2.Click += (sender, e) => { OpenAddPart_EditMode(sender, e); };
                            }
                            else
                            {
                                label2.Click += (sender, e) => { SelectPart(sender, e); };
                            }
                            if (!DBNull.Value.Equals(parts.Rows[i]["P_GP_ID"]))
                            {
                                label3.Text = eqp.Select(String.Format("GP_ID = {0}", parts.Rows[i]["P_GP_ID"].ToString()))[0]["GP_NOME"].ToString();
                            }
                            else
                            {
                                label3.Text = "(SEM GRUPO)";
                            }
                            label3.Font = label11.Font;
                            label3.Dock = DockStyle.Fill;
                            if (Mode == FormMode.Normal)
                            {
                                label3.Click += (sender, e) => { OpenAddPart_EditMode(sender, e); };
                            }
                            else
                            {
                                label3.Click += (sender, e) => { SelectPart(sender, e); };
                            }
                            label1.Name = parts.Rows[i]["P_ID"].ToString(); ;
                            label2.Name = parts.Rows[i]["P_ID"].ToString(); ;
                            label3.Name = parts.Rows[i]["P_ID"].ToString();
                            tableLayoutPanel1.Controls.Add(label1, 0, i + 1);
                            tableLayoutPanel1.Controls.Add(label2, 1, i + 1);
                            tableLayoutPanel1.Controls.Add(label3, 2, i + 1);
                        }
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
        public void UpdateData()
        {
            parts = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT * FROM tbParticipante", Program.env);
            eqp = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", "SELECT GP_ID, GP_NOME FROM tbGrupo", Program.env);
        }
        public void UpdateTable()
        {
            UpdateData();
            UpdatePanel();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void SelectPart(object sender, EventArgs e)
        {

            string selectedPart = (sender as Label).Name;
            if (GetPartGroup(selectedPart) != "NULL")
            {
                if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbParticipante WHERE P_GP_ID={0}", gpId), Program.env).Rows.Count < 5 && gpId != GetPartGroup(selectedPart))
                {
                    if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbParticipante WHERE P_GP_ID={0}", GetPartGroup(selectedPart)), Program.env).Rows.Count == 1)
                    {

                        if (MessageBox.Show("Mudar o grupo deste participante deletará o grupo em que ele já está, pois não haverá nenhum participante no grupo. Deseja realmente mudar o grupo deste participante?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID={0} WHERE P_ID={1}", gpId, selectedPart), Program.env);
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupoAdmin WHERE GP_ID={0}", GetPartGroup(selectedPart)), Program.env);
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbGrupo WHERE GP_ID={0}", GetPartGroup(selectedPart)), Program.env);
                            Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT P_ID FROM tbGrupoAdmin WHERE GP_ID={0} AND P_ID={1}", GetPartGroup(selectedPart), selectedPart), Program.env).Rows.Count == 1)
                    {
                        if (MessageBox.Show("Esse participante é administrador de seu grupo. Remove-lo do grupo irá transferir o cargo para outro integrante. Deseja continuar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID={0} WHERE P_ID={1}", gpId, selectedPart), Program.env);
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbGrupoAdmin SET P_ID='{1}' WHERE GP_ID={0}", GetPartGroup(selectedPart), QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT TOP 1 P_ID FROM tbParticipante WHERE P_GP_ID={0}", GetPartGroup(selectedPart)), Program.env).Rows[0][0].ToString()), Program.env);
                            Close();
                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        if (MessageBox.Show("Esse participante ja esta em um grupo. Deseja mudar seu grupo?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID={1} WHERE P_ID={0}", selectedPart, gpId), Program.env);
                            Close();
                        }
                    }
                }
                else
                {
                    if (gpId == GetPartGroup(selectedPart))
                    {
                        MessageBox.Show("Este participante já está no grupo!");
                    }
                    else
                    {
                        MessageBox.Show("Este grupo já está com 5 participantes!");
                    }
                }
            }
            else
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID={0} WHERE P_ID={1}", gpId, selectedPart), Program.env);
                Close();
            }
        }
        private string GetPartGroup(string id)
        {
            return (parts.Select(String.Format("P_ID = {0}", id))[0]["P_GP_ID"].ToString() == "" ? "NULL" : parts.Select(String.Format("P_ID = {0}", id))[0]["P_GP_ID"].ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
