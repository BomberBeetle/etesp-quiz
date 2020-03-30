using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETESP_Quiz
{
    public partial class frmAddPergunta : Form
    {
        string id;
        string imgID;
        DataTable qst;
        DataTable top;
        DataTable dif;
        DataTable alt;
        FormMode Mode;
        DataTable img;
        private enum FormMode
        {
            Add = 0,
            Edit = 1
        }
        public frmAddPergunta()
        {
            InitializeComponent();
            for(int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i] is RoundedButton)
                {
                    (Controls[i] as RoundedButton).borderRadius = 15;
                }
            }
            top = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbTopico", id), Program.env);
            dif = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbDificuldade", id), Program.env);
            btnDelete.Visible = false;
            Mode = FormMode.Add;
            alt = new DataTable();
            alt.Columns.Add("ALT_ID");
            alt.Columns.Add("ALT_TEXTO");
            alt.Columns.Add("ALT_CERTA");
        }

        public frmAddPergunta(string id)
        {
            InitializeComponent();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is RoundedButton)
                {
                    (Controls[i] as RoundedButton).borderRadius = 15;
                }
            }
            Mode = FormMode.Edit;
            this.id = id;
            qst = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbQuestao WHERE Q_ID={0}", id), Program.env);
            txtTitulo.Text = qst.Rows[0]["Q_TITULO"].ToString();
            txtCorpo.Text = qst.Rows[0]["Q_TEXTO"].ToString();
            txtDica.Text = qst.Rows[0]["Q_DICA"].ToString();
            checkBox1.Checked = qst.Rows[0]["Q_ENABLED"].ToString() == "True" ;
            top = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbTopico", id), Program.env);
            dif = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbDificuldade", id), Program.env);
            if (qst.Rows[0]["Q_ISALTERNATIVE"].ToString() == "True")
            {
                alt = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbAlternativas WHERE ALT_Q_ID={0}", id), Program.env);
                comboBoxTipo.SelectedIndex = 1;
            }
            else
            {
                alt = new DataTable();
                alt.Columns.Add("ALT_ID");
                alt.Columns.Add("ALT_TEXTO");
                alt.Columns.Add("ALT_CERTA");
                comboBoxTipo.SelectedIndex = 0;
            }
            if (!DBNull.Value.Equals(qst.Rows[0]["Q_IMG_ID"]))
            {
                Directory.CreateDirectory("temp");
                img = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT * FROM tbImagem WHERE IMG_ID={0}", qst.Rows[0]["Q_IMG_ID"]), Program.env);
                File.WriteAllBytes($"temp\\{img.Rows[0]["IMG_FILENAME"]}",(byte[])img.Rows[0]["IMG_DATA"]);
                pictureBox1.ImageLocation = $"temp\\{img.Rows[0]["IMG_FILENAME"]}";
            }
        } 

        private void frmAddPergunta_Load(object sender, EventArgs e)
        {
            if(top.Rows.Count == 0)
            {
                MessageBox.Show("Ainda não há nenhuma matéria! Adicione uma em Editar Quiz -> Adicionar Matéria e tente novamente.");
                Close();
                return;
            }
            if (dif.Rows.Count == 0)
            {
                MessageBox.Show("Ainda não há nenhuma dificuldade! Adicione uma em Editar Quiz -> Adicionar Dificuldade e tente novamente.");
                Close();
                return;
            }
            foreach (DataRow r in top.Rows)
            {
                comboBoxTop.Items.Add(r["T_NOME"]);
            }
            foreach (DataRow r in dif.Rows)
            {
                comboBoxDif.Items.Add(r["DIF_NOME"]);
            }
            if(Mode == FormMode.Add) {
                comboBoxTop.SelectedIndex = 0;
                lblInts.Text = $"Valor de Intensidade: {dif.Rows[0]["DIF_VAL"]}";
                comboBoxDif.SelectedIndex = 0;
                comboBoxDif.SelectedIndex = 0;
                comboBoxTipo.SelectedIndex = 0;
                btnAlts.Enabled = false;
            }
            else
            {
                comboBoxTop.SelectedIndex = comboBoxTop.Items.IndexOf(top.Select($"T_ID = {qst.Rows[0]["Q_TOPICO_ID"]}")[0]["T_NOME"]);
                lblInts.Text = $"Valor de Intensidade: {dif.Select($"DIF_ID = {qst.Rows[0]["DIF_ID"]}")[0]["DIF_VAL"]}";
                comboBoxDif.SelectedIndex = comboBoxDif.Items.IndexOf(dif.Select($"DIF_ID = {qst.Rows[0]["DIF_ID"]}")[0]["DIF_NOME"]);
                comboBoxTipo.SelectedIndex = qst.Rows[0]["Q_ISALTERNATIVE"].ToString() == "True" ? 1 : 0;
                btnAlts.Enabled = (comboBoxTipo.SelectedIndex == 1);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool imageExists = false;
            if(txtTitulo.Text == "")
            {
                MessageBox.Show("O título não pode ser vazio! (Dica: Clique o botão [PREVER] para ver uma prévia da pergunta)");
                return;
            }
            if(comboBoxTipo.SelectedIndex == 1 && alt.Rows.Count < 2)
            {
                    MessageBox.Show("Adicione algumas alternativas no botão [EDITAR ALTERNATIVAS] antes de salvar ou mude o tipo da pergunta de [TESTE] para [DISSERTATIVA]");
                    return;
            }

            if(Mode == FormMode.Add)
            {
                if(pictureBox1.ImageLocation != null)
                {
                    imageExists = true;
                    Random random = new Random();
                    for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                    {
                        imgID = random.Next().ToString();
                        string queryPart = "";
                        queryPart = $"INSERT INTO tbImagem(IMG_ID,IMG_FILENAME,IMG_DATA) VALUES({imgID}, @0, @1)";
                        if (QuizDBConnect.QueryParams(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env, Tuple.Create<object, SqlDbType>(openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Count() - 1], SqlDbType.VarChar), Tuple.Create<object, SqlDbType>(File.ReadAllBytes(pictureBox1.ImageLocation), SqlDbType.VarBinary)) != null) { MessageBox.Show("Tópico adicionado com sucesso!(e muito carinho!)"); Close(); break; }
                    }

                }
                if(comboBoxTipo.SelectedIndex == 0)
                {
                    Random random = new Random();
                    for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                    {
                        id = random.Next().ToString();
                        string queryPart = "";
                        queryPart = $"INSERT INTO tbQuestao(Q_ID, DIF_ID, Q_IMG_ID, Q_TITULO, Q_ISALTERNATIVE, Q_TOPICO_ID, Q_DICA, Q_ENABLED, Q_TEXTO) VALUES({id}, {dif.Rows[comboBoxDif.SelectedIndex]["DIF_ID"]}, {(imageExists ? imgID : "NULL")},'{txtTitulo.Text.Replace("'", "''")}',0,{top.Rows[comboBoxTop.SelectedIndex]["T_ID"]},'{txtDica.Text.Replace("'", "''")}',{(checkBox1.Checked == true ? "1" : "0")}, '{txtCorpo.Text.Replace("'", "''")}')";
                        if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { MessageBox.Show("Questão adicionada com sucesso!(e muito carinho!)"); Close(); break; }
                    }
                }
                else
                {
                    Random random = new Random();
                    for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                    {
                        id = random.Next().ToString();
                        string queryPart = "";
                        queryPart = $"INSERT INTO tbQuestao(Q_ID, DIF_ID, Q_IMG_ID, Q_TITULO, Q_ISALTERNATIVE, Q_TOPICO_ID, Q_DICA, Q_ENABLED, Q_TEXTO) VALUES({id}, {dif.Rows[comboBoxDif.SelectedIndex]["DIF_ID"]}, {(imageExists ? imgID : "NULL")},'{txtTitulo.Text.Replace("'", "''")}',1,{top.Rows[comboBoxTop.SelectedIndex]["T_ID"]},'{txtDica.Text.Replace("'", "''")}',{(checkBox1.Checked == true ? "1" : "0")}, '{txtCorpo.Text.Replace("'", "''")}')";
                        if (QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env) != null) { MessageBox.Show("Questão adicionada com sucesso!(e muito carinho!)"); Close(); break; }
                    }
                    foreach(DataRow d in alt.Rows)
                    {
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"INSERT INTO tbAlternativas(ALT_Q_ID,ALT_CERTA,ALT_TEXTO) VALUES({id},{d["ALT_CERTA"]},'{d["ALT_TEXTO"].ToString().Replace("'","''").Replace("\\","\\\\")}')", Program.env);
                    }
                }
            }
            else
            {
                if (pictureBox1.ImageLocation != null)
                {

                    if (DBNull.Value.Equals(qst.Rows[0]["Q_IMG_ID"]))
                    {
                        imageExists = true;
                        Random random = new Random();
                        for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
                        {
                            imgID = random.Next().ToString();
                            string queryPart = "";
                            queryPart = $"INSERT INTO tbImagem(IMG_ID,IMG_FILENAME,IMG_DATA) VALUES({imgID}, @0, @1)";
                            DataTable ret = QuizDBConnect.QueryParams(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env, Tuple.Create<object, SqlDbType>(openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Count() - 1], SqlDbType.VarChar), Tuple.Create<object, SqlDbType>(File.ReadAllBytes(pictureBox1.ImageLocation), SqlDbType.VarBinary));
                            if (ret != null) {QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"UPDATE tbQuestao SET Q_IMG_ID={imgID} WHERE Q_ID={id}", Program.env); Close(); break; }
                        }
                    }
                    else
                    {
                        imageExists = true;
                        string queryPart = "";
                        queryPart = $"UPDATE tbImagem SET IMG_FILENAME= @0, IMG_DATA= @1 WHERE IMG_ID={qst.Rows[0]["Q_IMG_ID"]}";
                        QuizDBConnect.QueryParams(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env, Tuple.Create<object, SqlDbType>(openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Count() - 1].Replace("'","''"), SqlDbType.VarChar), Tuple.Create<object, SqlDbType>(File.ReadAllBytes(pictureBox1.ImageLocation), SqlDbType.VarBinary));
                    }
                    AtualizarTabela();
                }
                else
                {
                    if (!DBNull.Value.Equals(qst.Rows[0]["Q_IMG_ID"]))
                    {
                        AtualizarTabela();
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"UPDATE tbQuestao SET Q_IMG_ID=NULL WHERE Q_ID={id}", Program.env);
                        QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"DELETE FROM tbImagem WHERE IMG_ID={qst.Rows[0]["Q_IMG_ID"]}", Program.env);
                    }
                    else
                    {
                        AtualizarTabela();
                    }

                }
            }
            Close();
        }

        private void AtualizarTabela()
        {
            if(comboBoxTipo.SelectedIndex == 0)
            {
                string queryPart = $"UPDATE tbQuestao SET DIF_ID = {dif.Rows[comboBoxDif.SelectedIndex]["DIF_ID"]}, Q_TOPICO_ID = {top.Rows[comboBoxTop.SelectedIndex]["T_ID"]}, Q_TEXTO='{txtCorpo.Text.Replace("'", "''")}', Q_TITULO='{txtTitulo.Text.Replace("'", "''")}',Q_DICA='{txtDica.Text.Replace("'", "''")}' ,Q_ISALTERNATIVE=0,Q_ENABLED={(checkBox1.Checked == true ? "1" : "0")} WHERE Q_ID={id}";
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env);
            }
            else
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"DELETE FROM tbAlternativas WHERE ALT_Q_ID={id}", Program.env);
                foreach (DataRow r in alt.Rows)
                {
                    QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", $"INSERT INTO tbAlternativas(ALT_Q_ID, ALT_TEXTO, ALT_CERTA) VALUES({id}, '{r["ALT_TEXTO"].ToString().Replace("'","''")}', '{r["ALT_CERTA"].ToString()}')", Program.env);
                }
                string queryPart = $"UPDATE tbQuestao SET DIF_ID = {dif.Rows[comboBoxDif.SelectedIndex]["DIF_ID"]}, Q_TOPICO_ID = {top.Rows[comboBoxTop.SelectedIndex]["T_ID"]}, Q_TEXTO='{txtCorpo.Text.Replace("'", "''")}', Q_TITULO='{txtTitulo.Text.Replace("'", "''")}',Q_DICA='{txtDica.Text.Replace("'", "''")}' , Q_ISALTERNATIVE=1 ,Q_ENABLED={(checkBox1.Checked == true ? "1" : "0")} WHERE Q_ID={id}";
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", queryPart, Program.env);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmEditAlts frmEA = new frmEditAlts();
            frmEA.Size = Size;
            frmEA.Location = Location;
            if(alt != null)
            {
                frmEA.LoadAlternatives(alt);
            }
            Hide();
            frmEA.ShowDialog();
            if (frmEA.returned) alt = frmEA.GetAlternativas();
            this.Size = frmEA.Size;
            Location = frmEA.Location;
            Show();
        }

        private void comboBoxDif_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInts.Text = $"Valor de Intensidade: {dif.Rows[comboBoxDif.SelectedIndex]["DIF_VAL"]}";
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTipo.SelectedIndex == 1)
            {
                btnAlts.Enabled = true;
            }
            else
            {
                btnAlts.Enabled = false;
            }
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory("temp");
                File.WriteAllBytes($"temp\\{openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Count() - 1]}", File.ReadAllBytes(openFileDialog1.FileName));
                pictureBox1.ImageLocation = $"temp\\{openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Count() - 1]}";
            }
        }

        private void btnRemImg_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Tem certeza que quer remover a imagem?",
                                    "Confirmar Ação",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                pictureBox1.ImageLocation = null;
        }

        private void txtCorpo_TextChanged(object sender, EventArgs e)
        {
            label4.Text = $"{txtCorpo.MaxLength - txtCorpo.Text.Length} Caracteres restantes";
        }

        private void txtDica_TextChanged(object sender, EventArgs e)
        {
            label10.Text = $"{txtDica.MaxLength - txtDica.Text.Length} Caracteres restantes";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            int quests = QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("SELECT Q_ID FROM tbQuestao WHERE Q_TOPICO_ID={0}", id), Program.env).Rows.Count;
            var confirmResult = MessageBox.Show($"Tem certeza que quer deletar esta pergunta? As {quests} questões que usam ele serão deletadas do Quiz permanentemente!",
                                     "Confirmar Ação",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbAlternativas WHERE ALT_Q_ID={0}", id), Program.env);
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbQuestao WHERE Q_ID={0}", id), Program.env);
                if(!DBNull.Value.Equals(qst.Rows[0]["Q_IMG_ID"]))
                QuizDBConnect.Query(Program.user, Program.pass, "dbQuiz2019", String.Format("DELETE FROM tbImagem WHERE IMG_ID={0}", qst.Rows[0]["Q_IMG_ID"]), Program.env);
                Close();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            QuestionType qt = QuestionType.Title;
            if (txtCorpo.Text != "")
            {
                qt = qt | QuestionType.Txt;
            }
            if(comboBoxTipo.SelectedIndex == 1)
            {
                qt = qt | QuestionType.Alts;
            }
            if(pictureBox1.ImageLocation != null)
            {
                qt = qt | QuestionType.Img;
            }
            frmJogoPergunta preview = new frmJogoPergunta(qt);
            preview.maxTime = 10;
            preview.Controls["button3"].Visible = true;
            preview.Controls["lblTitle"].Text = txtTitulo.Text;
            preview.Controls["lblTxt"].Text = txtCorpo.Text;
            (preview.Controls["panel1"] as Panel).Controls[0].Text = txtDica.Text;
            if(txtDica.Text == "")
            {
                preview.Controls["button2"].Visible = false;
            }
            (preview.Controls["questionPic"] as PictureBox).ImageLocation = pictureBox1.ImageLocation;
            try
            {
                (preview.Controls["altsPanel"].Controls[4] as Label).Text = "A) " + alt.Rows[0]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[3] as Label).Text = "B) " + alt.Rows[1]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[2] as Label).Text = "C) " + alt.Rows[2]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[1] as Label).Text = "D) " + alt.Rows[3]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[0] as Label).Text = "E) " + alt.Rows[4]["ALT_TEXTO"].ToString();

            }
            catch
            {

            }
            preview.ShowDialog();
        }
    }
}
