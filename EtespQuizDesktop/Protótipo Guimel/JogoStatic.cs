using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETESP_Quiz
{
    static class JogoStatic
    {
        public static DataTable Equipes;
        public static DataTable Participantes;
        public static DataTable Perguntas;
        public static DataTable Alternativas;
        public static DataTable Imagens;
        public static DataTable Dificuldades;
        public static DataTable Materias;
        public static DataRow DifTopQuiz;
        public static DataRow DifRepescagem;
        public static int TopQuizNQ;
        public static int TempoQuestao;
        public static int ErrosPermitidos;
        public static bool MostrarDissertativas;
        public static bool TimerAutomatic;
        public static List<int> MateriasExcluidas = new List<int>();
        private static int q = 0;

        static public void Clear()
        {
            Equipes = null;
            Participantes = null;
            Perguntas = null;
            Alternativas = null;
            Imagens = null;
            Dificuldades = null;
            Materias = null;
            DifTopQuiz = null;
            q = 0;
            MateriasExcluidas = new List<int>();
        }
        static public void GameLoop()
        {
            var qMax = 0;
            var exit = false;
            foreach(DataRow r in Dificuldades.Rows)
            {
                qMax += int.Parse(r["NUM_Q"].ToString());
            }
            
            for(int i = 0; i < Dificuldades.Rows.Count; i++){
                if (exit)
                {
                    break;
                }
                for(int j = 0; j < int.Parse(Dificuldades.Rows[i]["NUM_Q"].ToString()); j++){
                    q++;
                    MateriasExcluidas = new List<int>();
                    for (int x = 0; x < Materias.Rows.Count; x++)
                    {  
                        if(Perguntas.Select($"DIF_ID={Dificuldades.Rows[i]["DIF_ID"]} AND Q_TOPICO_ID={Materias.Rows[x]["T_ID"]} AND Q_ENABLED='True'").Count() < 1)
                        {
                            MateriasExcluidas.Add(x);
                        }
                    }
                    frmRoleta fR = new frmRoleta();
                    fR.Controls["label3"].Text = "Dificuldade: " + Dificuldades.Rows[i]["DIF_NOME"].ToString();
                    fR.Controls["label4"].Text = $"Rodada {i + 1} de {Dificuldades.Rows.Count}";
                    fR.Controls["label5"].Text = $"Questão {j + 1} de {Dificuldades.Rows[i]["NUM_Q"]}";
                    fR.ShowDialog();
                    var materia = fR.materia;
                    fR.Dispose();
                    var rgen = new Random();
                    var qstIndex = new int();
                    while (true)
                    {
                        var pergs = Perguntas.Select($"DIF_ID = {Dificuldades.Rows[i]["DIF_ID"]} AND Q_TOPICO_ID = {Materias.Rows[materia]["T_ID"]}");
                        qstIndex = Perguntas.Rows.IndexOf(pergs[rgen.Next(0,pergs.Count())]);
                        if (Perguntas.Rows[qstIndex]["Q_ENABLED"].ToString() == "True") break;
                    }
                    Perguntas.Rows[qstIndex]["Q_ENABLED"] = false;

                    QuestionType qt = QuestionType.Title;
                    if (Perguntas.Rows[qstIndex]["Q_TEXTO"].ToString() != "")
                    {
                        qt = qt | QuestionType.Txt;
                    }
                    if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "True")
                    {
                        qt = qt | QuestionType.Alts;
                    }
                    if (!DBNull.Value.Equals(Perguntas.Rows[qstIndex]["Q_IMG_ID"]))
                    {
                        qt = qt | QuestionType.Img;
                    }

                    frmJogoPergunta preview = new frmJogoPergunta(qt);
                    preview.maxTime = TempoQuestao;
                    preview.Controls["lblTitle"].Text = Perguntas.Rows[qstIndex]["Q_TITULO"].ToString();
                    preview.Controls["lblTxt"].Text = Perguntas.Rows[qstIndex]["Q_TEXTO"].ToString();
                    (preview.Controls["panel1"] as Panel).Controls[0].Text = Perguntas.Rows[qstIndex]["Q_DICA"].ToString();
                    if ((preview.Controls["panel1"] as Panel).Controls[0].Text == "")
                    {
                        preview.Controls["button2"].Visible = false;
                    }
                    var imgPath = "";
                    if (!DBNull.Value.Equals(Perguntas.Rows[qstIndex]["Q_IMG_ID"]))
                    {
                        Directory.CreateDirectory("temp");
                        var img = Imagens.Select($"IMG_ID = {Perguntas.Rows[qstIndex]["Q_IMG_ID"]}").CopyToDataTable();
                        File.WriteAllBytes($"temp\\{img.Rows[0]["IMG_FILENAME"]}", (byte[])img.Rows[0]["IMG_DATA"]);
                        imgPath = $"temp\\{img.Rows[0]["IMG_FILENAME"]}";
                    }
                    (preview.Controls["questionPic"] as PictureBox).ImageLocation = imgPath;
                    DataTable alt = null;
                    try
                    {
                        alt = Alternativas.Select($"ALT_Q_ID={Perguntas.Rows[qstIndex]["Q_ID"]}").CopyToDataTable();
                        (preview.Controls["altsPanel"].Controls[4] as Label).Text = "A) " + alt.Rows[0]["ALT_TEXTO"].ToString();
                        (preview.Controls["altsPanel"].Controls[3] as Label).Text = "B) " + alt.Rows[1]["ALT_TEXTO"].ToString();
                        (preview.Controls["altsPanel"].Controls[2] as Label).Text = "C) " + alt.Rows[2]["ALT_TEXTO"].ToString();
                        (preview.Controls["altsPanel"].Controls[1] as Label).Text = "D) " + alt.Rows[3]["ALT_TEXTO"].ToString();
                        (preview.Controls["altsPanel"].Controls[0] as Label).Text = "E) " + alt.Rows[4]["ALT_TEXTO"].ToString();
                        
                    }
                    catch(Exception e)
                    {

                    }
                    if (TimerAutomatic)
                    {
                        preview.button1_Click(new object(), new EventArgs());
                    }
                    preview.ShowDialog();
                    frmJogoResposta telaRespostas = new frmJogoResposta(Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "False"? frmJogoResposta.AnswerType.Text : frmJogoResposta.AnswerType.Alts);
                    if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "True")
                    {    
                        telaRespostas.Controls["txtPanel"].Visible = false;
                        telaRespostas.Controls["altsPanel"].Visible = true;
                        for (int y = 0; y < alt.Rows.Count; y++)
                        {
                            telaRespostas.altsPanel.Controls[y].Visible = true;
                        }
                    }
                    else
                    {
                        telaRespostas.Controls["txtPanel"].Visible = true;
                        telaRespostas.Controls["altsPanel"].Visible = false;
                    }
                    
                    frmJogoRanking ranking = new frmJogoRanking();
                    
                    var dic = new Dictionary<int, bool>();
                    var respostas = new Dictionary<int, string>();
                    for (int x = 0; x < Equipes.Rows.Count; x++)
                    {
                        if (Equipes.Rows[x]["ENABLED"].ToString() == "True")
                        {
                            telaRespostas.Controls["lblTitle"].Text = $"A resposta do grupo {Equipes.Rows[x]["GP_NOME"]} (Cód {Equipes.Rows[x]["GP_ID"]}) foi:";
                            List<string> nomes = new List<string>();
                            foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[x]["GP_ID"]}"))
                            {
                                nomes.Add(r["P_NOME"].ToString());
                            }
                            telaRespostas.Controls["label3"].Text = $"Integrantes: {string.Join(",", nomes)}";
                            telaRespostas.ShowDialog();
                            respostas.Add(x, telaRespostas.Controls["txtPanel"].Controls["textBox1"].Text);
                            if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "False")
                            {
                                if (telaRespostas.certa)
                                {
                                    dic.Add(x, true);
                                }
                                else
                                {
                                    dic.Add(x, false);
                                }

                            }
                            else
                            {
                                if (alt.Rows[telaRespostas.altIndex]["ALT_CERTA"].ToString() == "True")
                                {
                                    dic.Add(x, true);
                                }
                                else
                                {
                                    dic.Add(x, false);
                                }
                            }
                        }
                    }
                    if (MostrarDissertativas)
                    {
                        frmJogoMostrarResposta mr = new frmJogoMostrarResposta();
                        foreach (int x in respostas.Keys)
                        {
                            if(respostas[x] != "")
                            {
                                List < string > nomes = new List<string>();
                                foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[x]["GP_ID"]}"))
                                {
                                    nomes.Add(r["P_NOME"].ToString());
                                }
                                mr.Controls["lblTitle"].Text = $"A resposta do grupo {Equipes.Rows[x]["GP_NOME"]}:";
                                mr.Controls["lblNomes"].Text = $"Integrantes: {string.Join(",", nomes)}";
                                mr.Controls["lblResposta"].Text = respostas[x];
                                if (dic[x]) { mr.setErrada(); } else {  mr.setCerta(); }
                                mr.ShowDialog();
                            }
                        }
                    }
                    var recompensa = 4;

                    if (preview.dicaMostrada)
                    {
                        recompensa /= 2;
                    }
                    if (dic.Where(x => x.Value == true).Count() > 1)
                    {
                        recompensa /= 2;
                    }
                    List<string> gruposE = new List<string>();
                    List<string> gruposA = new List<string>();
                    for (int x = 0; x < Equipes.Rows.Count; x++)
                    {
                        if (Equipes.Rows[x]["ENABLED"].ToString() == "True")
                        {
                            if (dic[x])
                            {
                                Equipes.Rows[x]["PONTOS"] = int.Parse(Equipes.Rows[x]["PONTOS"].ToString()) + recompensa;
                                Equipes.Rows[x]["ACERTOS"] = int.Parse(Equipes.Rows[x]["ACERTOS"].ToString()) + 1;
                            }
                            else
                            {
                                Equipes.Rows[x]["ERROS"] = int.Parse(Equipes.Rows[x]["ERROS"].ToString())+1;
                            }
                            if (int.Parse(Equipes.Rows[x]["ERROS"].ToString()) - int.Parse(Equipes.Rows[x]["VIDAS_EXTRA"].ToString()) == ErrosPermitidos)
                            {
                                gruposA.Add(Equipes.Rows[x]["GP_NOME"].ToString());
                            }
                            else if (int.Parse(Equipes.Rows[x]["ERROS"].ToString()) - int.Parse(Equipes.Rows[x]["VIDAS_EXTRA"].ToString()) > ErrosPermitidos)
                            {
                                Equipes.Rows[x]["ENABLED"] = false;
                                gruposE.Add(Equipes.Rows[x]["GP_NOME"].ToString());
                            }
                            
                        }
                    }

                    var orderedEqp = Equipes.Select("1=1", "PONTOS DESC");
                    for(int x = 0; x < orderedEqp.Count(); x++)
                    {
                        var lblPos = new Label();
                        var lblNome = new Label();
                        var lblPontos = new Label();
                        var lblAcertos = new Label();
                        var lblErros = new Label();

                        lblPos.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + orderedEqp[x]["GP_COLOR"].ToString());
                        if (orderedEqp[x]["ENABLED"].ToString() == "False")
                        {
                            lblNome.BackColor = Color.Gray;
                            lblPontos.BackColor = Color.Gray;
                            lblAcertos.BackColor = Color.Gray;
                            lblErros.BackColor = Color.Gray;
                        }

                        lblPos.Font = ranking.label4.Font;
                        lblPos.Text = (x + 1) + "";
                        lblPos.Dock = DockStyle.Fill;
                        ranking.tableLayoutPanel1.Controls.Add(lblPos, 0, x);

                        lblNome.Font = ranking.label4.Font;
                        lblNome.Text = orderedEqp[x]["GP_NOME"].ToString();
                        lblNome.Dock = DockStyle.Fill;
                        ranking.tableLayoutPanel1.Controls.Add(lblNome, 1, x);

                        lblPontos.Font = ranking.label4.Font;
                        lblPontos.Text = orderedEqp[x]["PONTOS"].ToString() + " pts";
                        lblPontos.Dock = DockStyle.Fill;
                        ranking.tableLayoutPanel1.Controls.Add(lblPontos, 2, x);


                        lblAcertos.Font = ranking.label4.Font;
                        lblAcertos.Text = orderedEqp[x]["ACERTOS"].ToString() + " ACERTOS";
                        lblAcertos.Dock = DockStyle.Fill;
                        ranking.tableLayoutPanel1.Controls.Add(lblAcertos, 3, x);

                        lblErros.Font = ranking.label4.Font;
                        lblErros.Text = orderedEqp[x]["ERROS"].ToString()  + " ERROS";
                        lblErros.Dock = DockStyle.Fill;
                        ranking.tableLayoutPanel1.Controls.Add(lblErros, 4, x);

                    }
                    if(gruposA.Count > 0)
                    {
                        ranking.Controls["lblAviso"].Text = $"CUIDADO, Grupo(s) {string.Join(", ", gruposA)}: Caso vocês não acertem a próxima questão, serão ELIMINADOS!";
                    }
                    if (gruposE.Count > 0)
                    {
                        ranking.Controls["lblElim"].Text = $"GRUPO(S) ELIMINADO(S): {string.Join(", ", gruposE)}";
                    }
                    ranking.ShowDialog();
                    if((double)Equipes.Select("ENABLED='True'").Count()/Equipes.Rows.Count <= 0.20)
                    {
                        TopQuiz();
                        exit = true;
                        break;
                    }
                }

            }
            if (!exit)
            {
                TopQuiz();
            }
            var rankFinal = Equipes.Select("1=1", "PONTOS DESC");
            frmJogoTelaFinal final = new frmJogoTelaFinal();
            try
            {
                
                final.lblTitle.Text = $"Parabéns, {rankFinal[0]["GP_NOME"]}! Você ganhou esse ETESP Quiz!";
                final.lblResposta.Text = $"Frase do Grupo: {rankFinal[0]["GP_FRASE"]}";
                List<string> i0 = new List<string>();
                foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[0]["GP_ID"]}"))
                {
                    i0.Add(r["P_NOME"].ToString());
                }
                final.lblNomes.Text = $"Integrantes: {string.Join(", ", i0)}";
                final.label3.Text = rankFinal[1]["GP_NOME"].ToString();
                final.label4.Text = rankFinal[2]["GP_NOME"].ToString();
            }
            catch
            {

            }
            final.ShowDialog();
            Clear();
        }
        static public void TopQuiz()
        {
            for(int i  = 0; i< Perguntas.Rows.Count; i++)
            {
                Perguntas.Rows[i]["Q_ENABLED"] = true;
            }
            frmTopQuiz tq = new frmTopQuiz();
            List<string> nomes = new List<string>();
            foreach(DataRow r in Equipes.Rows)
            {
                if(r["ENABLED"].ToString() == "True")
                {
                    nomes.Add(r["GP_NOME"].ToString());
                }
            }
            tq.Controls["label3"].Text += string.Join(", ", nomes);
            tq.ShowDialog();
            for (int j = 0; j < TopQuizNQ; j++)
            {
                q++;
                MateriasExcluidas = new List<int>();
                for (int x = 0; x < Materias.Rows.Count; x++)
                {
                    if (Perguntas.Select($"DIF_ID={DifTopQuiz["DIF_ID"]} AND Q_TOPICO_ID={Materias.Rows[x]["T_ID"]} AND Q_ENABLED='True'").Count() < 1)
                    {
                        MateriasExcluidas.Add(x);
                    }
                }
                frmRoleta fR = new frmRoleta();
                fR.Controls["label3"].Text = "Dificuldade: " + DifTopQuiz["DIF_NOME"].ToString();
                fR.Controls["label4"].Text = $"TOP QUIZ";
                fR.Controls["label5"].Text = $"Questão {j + 1} de {TopQuizNQ}";
                fR.ShowDialog();

                var materia = fR.materia;

                fR.Dispose();
                var rgen = new Random();
                var qstIndex = new int();
                while (true)
                {
                    var pergs = Perguntas.Select($"DIF_ID = {DifTopQuiz["DIF_ID"]} AND Q_TOPICO_ID = {Materias.Rows[materia]["T_ID"]}");
                    qstIndex = Perguntas.Rows.IndexOf(pergs[rgen.Next(0, pergs.Count())]);
                    if (Perguntas.Rows[qstIndex]["Q_ENABLED"].ToString() == "True") break;
                }
                Perguntas.Rows[qstIndex]["Q_ENABLED"] = false;
                QuestionType qt = QuestionType.Title;
                if (Perguntas.Rows[qstIndex]["Q_TEXTO"].ToString() != "")
                {
                    qt = qt | QuestionType.Txt;
                }
                if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "True")
                {
                    qt = qt | QuestionType.Alts;
                }
                if (!DBNull.Value.Equals(Perguntas.Rows[qstIndex]["Q_IMG_ID"]))
                {
                    qt = qt | QuestionType.Img;
                }

                frmJogoPergunta preview = new frmJogoPergunta(qt);
                preview.maxTime = TempoQuestao;
                preview.Controls["lblTitle"].Text = Perguntas.Rows[qstIndex]["Q_TITULO"].ToString();
                preview.Controls["lblTxt"].Text = Perguntas.Rows[qstIndex]["Q_TEXTO"].ToString();
                (preview.Controls["panel1"] as Panel).Controls[0].Text = Perguntas.Rows[qstIndex]["Q_DICA"].ToString();
                if ((preview.Controls["panel1"] as Panel).Controls[0].Text == "")
                {
                    preview.Controls["button2"].Visible = false;
                }
                var imgPath = "";
                if (!DBNull.Value.Equals(Perguntas.Rows[qstIndex]["Q_IMG_ID"]))
                {
                    Directory.CreateDirectory("temp");
                    var img = Imagens.Select($"IMG_ID = {Perguntas.Rows[qstIndex]["Q_IMG_ID"]}").CopyToDataTable();
                    File.WriteAllBytes($"temp\\{img.Rows[0]["IMG_FILENAME"]}", (byte[])img.Rows[0]["IMG_DATA"]);
                    imgPath = $"temp\\{img.Rows[0]["IMG_FILENAME"]}";
                }
                    (preview.Controls["questionPic"] as PictureBox).ImageLocation = imgPath;
                DataTable alt = null;
                try
                {
                    alt = Alternativas.Select($"ALT_Q_ID={Perguntas.Rows[qstIndex]["Q_ID"]}").CopyToDataTable();
                    (preview.Controls["altsPanel"].Controls[4] as Label).Text = "A) " + alt.Rows[0]["ALT_TEXTO"].ToString();
                    (preview.Controls["altsPanel"].Controls[3] as Label).Text = "B) " + alt.Rows[1]["ALT_TEXTO"].ToString();
                    (preview.Controls["altsPanel"].Controls[2] as Label).Text = "C) " + alt.Rows[2]["ALT_TEXTO"].ToString();
                    (preview.Controls["altsPanel"].Controls[1] as Label).Text = "D) " + alt.Rows[3]["ALT_TEXTO"].ToString();
                    (preview.Controls["altsPanel"].Controls[0] as Label).Text = "E) " + alt.Rows[4]["ALT_TEXTO"].ToString();

                }
                catch (Exception e)
                {

                }
                if (TimerAutomatic)
                {
                    preview.button1_Click(new object(), new EventArgs());
                }
                preview.ShowDialog();
                preview.Dispose();
                frmJogoResposta telaRespostas = new frmJogoResposta(Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "False" ? frmJogoResposta.AnswerType.Text : frmJogoResposta.AnswerType.Alts);
                if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "True")
                {
                    telaRespostas.Controls["txtPanel"].Visible = false;
                    telaRespostas.Controls["altsPanel"].Visible = true;
                    for (int y = 0; y < alt.Rows.Count; y++)
                    {
                        telaRespostas.altsPanel.Controls[y].Visible = true;
                    }
                }
                else
                {
                    telaRespostas.Controls["txtPanel"].Visible = true;
                    telaRespostas.Controls["altsPanel"].Visible = false;
                }

                frmJogoRanking ranking = new frmJogoRanking();

                var dic = new Dictionary<int, bool>();
                var respostas = new Dictionary<int, string>();
                for (int x = 0; x < Equipes.Rows.Count; x++)
                {
                    if (Equipes.Rows[x]["ENABLED"].ToString() == "True")
                    {
                        telaRespostas.Controls["lblTitle"].Text = $"A resposta do grupo {Equipes.Rows[x]["GP_NOME"]} (Cód {Equipes.Rows[x]["GP_ID"]}) foi:";
                        List<string> eqpNomes = new List<string>();
                        foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[x]["GP_ID"]}"))
                        {
                            eqpNomes.Add(r["P_NOME"].ToString());
                        }
                        telaRespostas.Controls["label3"].Text = $"Integrantes: {string.Join(",", nomes)}";
                        telaRespostas.ShowDialog();
                        respostas.Add(x, telaRespostas.Controls["txtPanel"].Controls["textBox1"].Text);
                        if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "False")
                        {
                            if (telaRespostas.certa)
                            {
                                dic.Add(x, true);
                            }
                            else
                            {
                                dic.Add(x, false);
                            }

                        }
                        else
                        {
                            if (alt.Rows[telaRespostas.altIndex]["ALT_CERTA"].ToString() == "True")
                            {
                                dic.Add(x, true);
                            }
                            else
                            {
                                dic.Add(x, false);
                            }
                        }
                    }
                }
                if (MostrarDissertativas)
                {
                    frmJogoMostrarResposta mr = new frmJogoMostrarResposta();
                    foreach (int x in respostas.Keys)
                    {
                        if (respostas[x] != "")
                        {
                            List<string> eqpNomes = new List<string>();
                            foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[x]["GP_ID"]}"))
                            {
                                eqpNomes.Add(r["P_NOME"].ToString());
                            }
                            mr.Controls["lblTitle"].Text = $"A resposta do grupo {Equipes.Rows[x]["GP_NOME"]}:";
                            mr.Controls["lblNomes"].Text = $"Integrantes: {string.Join(",", nomes)}";
                            mr.Controls["lblResposta"].Text = respostas[x];
                            if (dic[x]) { mr.setErrada(); } else { mr.setCerta(); }
                            mr.ShowDialog();
                        }
                    }
                }
                var recompensa = 4;

                if (preview.dicaMostrada)
                {
                    recompensa /= 2;
                }
                if (dic.Where(x => x.Value == true).Count() > 1)
                {
                    recompensa /= 2;
                }
                for (int x = 0; x < Equipes.Rows.Count; x++)
                {
                    if (Equipes.Rows[x]["ENABLED"].ToString() == "True")
                    {
                        if (dic[x])
                        {
                            Equipes.Rows[x]["PONTOS"] = int.Parse(Equipes.Rows[x]["PONTOS"].ToString()) + recompensa;
                            Equipes.Rows[x]["ACERTOS"] = int.Parse(Equipes.Rows[x]["ACERTOS"].ToString()) + 1;
                        }
                        else
                        {
                            Equipes.Rows[x]["ERROS"] = int.Parse(Equipes.Rows[x]["ERROS"].ToString()) + 1;
                        }
                    }
                }

                var orderedEqp = Equipes.Select("1=1", "PONTOS DESC");
                for (int x = 0; x < orderedEqp.Count(); x++)
                {
                    var lblPos = new Label();
                    var lblNome = new Label();
                    var lblPontos = new Label();
                    var lblAcertos = new Label();
                    var lblErros = new Label();

                    lblPos.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + orderedEqp[x]["GP_COLOR"].ToString());
                    if (orderedEqp[x]["ENABLED"].ToString() == "False")
                    {
                        lblNome.BackColor = Color.Gray;
                        lblPontos.BackColor = Color.Gray;
                        lblAcertos.BackColor = Color.Gray;
                        lblErros.BackColor = Color.Gray;
                    }

                    lblPos.Font = ranking.label4.Font;
                    lblPos.Text = (x + 1) + "";
                    lblPos.Dock = DockStyle.Fill;
                    ranking.tableLayoutPanel1.Controls.Add(lblPos, 0, x);

                    lblNome.Font = ranking.label4.Font;
                    lblNome.Text = orderedEqp[x]["GP_NOME"].ToString();
                    lblNome.Dock = DockStyle.Fill;
                    ranking.tableLayoutPanel1.Controls.Add(lblNome, 1, x);

                    lblPontos.Font = ranking.label4.Font;
                    lblPontos.Text = orderedEqp[x]["PONTOS"].ToString() + " pts";
                    lblPontos.Dock = DockStyle.Fill;
                    ranking.tableLayoutPanel1.Controls.Add(lblPontos, 2, x);


                    lblAcertos.Font = ranking.label4.Font;
                    lblAcertos.Text = orderedEqp[x]["ACERTOS"].ToString() + " ACERTOS";
                    lblAcertos.Dock = DockStyle.Fill;
                    ranking.tableLayoutPanel1.Controls.Add(lblAcertos, 3, x);

                    lblErros.Font = ranking.label4.Font;
                    lblErros.Text = orderedEqp[x]["ERROS"].ToString() + " ERROS";
                    lblErros.Dock = DockStyle.Fill;
                    ranking.tableLayoutPanel1.Controls.Add(lblErros, 4, x);

                }
                ranking.ShowDialog();
            }
         }
        static public void Repescagem()
        {
            List<string> elim = new List<string>();
            foreach(DataRow r in Equipes.Select("ENABLED='False'"))
            {
                elim.Add(r["GP_NOME"].ToString());
            }
            frmRepescagem repescagem = new frmRepescagem();
            repescagem.Controls["label3"].Text += string.Join(", ", elim);
            repescagem.ShowDialog();
            MateriasExcluidas = new List<int>();
            for (int x = 0; x < Materias.Rows.Count; x++)
            {
                if (Perguntas.Select($"DIF_ID={DifRepescagem["DIF_ID"]} AND Q_TOPICO_ID={Materias.Rows[x]["T_ID"]}").Count() < 1)
                {
                    MateriasExcluidas.Add(x);
                }
            }
            frmRoleta fR = new frmRoleta();
           fR.Controls["label3"].Text = "Dificuldade: " + DifRepescagem["DIF_NOME"].ToString();
           fR.Controls["label4"].Text = $"REPESCAGEM";
           fR.Controls["label5"].Text = $"QUESTÃO ÚNICA";
            fR.ShowDialog();
            var materia = fR.materia;
            fR.Dispose();
            var rgen = new Random();
            var qstIndex = new int();
            
             var pergs = Perguntas.Select($"DIF_ID = {DifRepescagem["DIF_ID"]} AND Q_TOPICO_ID = {Materias.Rows[materia]["T_ID"]}");
               qstIndex = Perguntas.Rows.IndexOf(pergs[rgen.Next(0, pergs.Count())]);
          

            QuestionType qt = QuestionType.Title;
            if (Perguntas.Rows[qstIndex]["Q_TEXTO"].ToString() != "")
            {
                qt = qt | QuestionType.Txt;
            }
            if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "True")
            {
                qt = qt | QuestionType.Alts;
            }
            if (!DBNull.Value.Equals(Perguntas.Rows[qstIndex]["Q_IMG_ID"]))
            {
                qt = qt | QuestionType.Img;
            }

            frmJogoPergunta preview = new frmJogoPergunta(qt);
            preview.maxTime = TempoQuestao;
            preview.Controls["lblTitle"].Text = Perguntas.Rows[qstIndex]["Q_TITULO"].ToString();
            preview.Controls["lblTxt"].Text = Perguntas.Rows[qstIndex]["Q_TEXTO"].ToString();
            (preview.Controls["panel1"] as Panel).Controls[0].Text = Perguntas.Rows[qstIndex]["Q_DICA"].ToString();
            if ((preview.Controls["panel1"] as Panel).Controls[0].Text == "")
            {
                preview.Controls["button2"].Visible = false;
            }
            var imgPath = "";
            if (!DBNull.Value.Equals(Perguntas.Rows[qstIndex]["Q_IMG_ID"]))
            {
                Directory.CreateDirectory("temp");
                var img = Imagens.Select($"IMG_ID = {Perguntas.Rows[qstIndex]["Q_IMG_ID"]}").CopyToDataTable();
                File.WriteAllBytes($"temp\\{img.Rows[0]["IMG_FILENAME"]}", (byte[])img.Rows[0]["IMG_DATA"]);
                imgPath = $"temp\\{img.Rows[0]["IMG_FILENAME"]}";
            }
                    (preview.Controls["questionPic"] as PictureBox).ImageLocation = imgPath;
            DataTable alt = null;
            try
            {
                alt = Alternativas.Select($"ALT_Q_ID={Perguntas.Rows[qstIndex]["Q_ID"]}").CopyToDataTable();
                (preview.Controls["altsPanel"].Controls[4] as Label).Text = "A) " + alt.Rows[0]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[3] as Label).Text = "B) " + alt.Rows[1]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[2] as Label).Text = "C) " + alt.Rows[2]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[1] as Label).Text = "D) " + alt.Rows[3]["ALT_TEXTO"].ToString();
                (preview.Controls["altsPanel"].Controls[0] as Label).Text = "E) " + alt.Rows[4]["ALT_TEXTO"].ToString();

            }
            catch (Exception e)
            {

            }
            if (TimerAutomatic)
            {
                preview.button1_Click(new object(), new EventArgs());
            }
            preview.ShowDialog();
            preview.Dispose();
            frmJogoResposta telaRespostas = new frmJogoResposta(Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "False" ? frmJogoResposta.AnswerType.Text : frmJogoResposta.AnswerType.Alts);
            if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "True")
            {
                telaRespostas.Controls["txtPanel"].Visible = false;
                telaRespostas.Controls["altsPanel"].Visible = true;
                for (int y = 0; y < alt.Rows.Count; y++)
                {
                    telaRespostas.altsPanel.Controls[y].Visible = true;
                }
            }
            else
            {
                telaRespostas.Controls["txtPanel"].Visible = true;
                telaRespostas.Controls["altsPanel"].Visible = false;
            }

            frmJogoRanking ranking = new frmJogoRanking();

            var dic = new Dictionary<int, bool>();
            var respostas = new Dictionary<int, string>();
            for (int x = 0; x < Equipes.Rows.Count; x++)
            {
                if (Equipes.Rows[x]["ENABLED"].ToString() != "True")
                {
                    telaRespostas.Controls["lblTitle"].Text = $"A resposta do grupo {Equipes.Rows[x]["GP_NOME"]} (Cód {Equipes.Rows[x]["GP_ID"]}) foi:";
                    List<string> nomes = new List<string>();
                    foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[x]["GP_ID"]}"))
                    {
                        nomes.Add(r["P_NOME"].ToString());
                    }
                    telaRespostas.Controls["label3"].Text = $"Integrantes: {string.Join(",", nomes)}";
                    telaRespostas.ShowDialog();
                    respostas.Add(x, telaRespostas.Controls["txtPanel"].Controls["textBox1"].Text);
                    if (Perguntas.Rows[qstIndex]["Q_ISALTERNATIVE"].ToString() == "False")
                    {
                        if (telaRespostas.certa)
                        {
                            dic.Add(x, true);
                        }
                        else
                        {
                            dic.Add(x, false);
                        }

                    }
                    else
                    {
                        if (alt.Rows[telaRespostas.altIndex]["ALT_CERTA"].ToString() == "True")
                        {
                            dic.Add(x, true);
                        }
                        else
                        {
                            dic.Add(x, false);
                        }
                    }
                }
            }
            if (MostrarDissertativas)
            {
                frmJogoMostrarResposta mr = new frmJogoMostrarResposta();
                foreach (int x in respostas.Keys)
                {
                    if (respostas[x] != "")
                    {
                        List<string> nomes = new List<string>();
                        foreach (DataRow r in Participantes.Select($"P_GP_ID = {Equipes.Rows[x]["GP_ID"]}"))
                        {
                            nomes.Add(r["P_NOME"].ToString());
                        }
                        mr.Controls["lblTitle"].Text = $"A resposta do grupo {Equipes.Rows[x]["GP_NOME"]}:";
                        mr.Controls["lblNomes"].Text = $"Integrantes: {string.Join(",", nomes)}";
                        mr.Controls["lblResposta"].Text = respostas[x];
                        if (dic[x]) { mr.setErrada(); } else { mr.setCerta(); }
                        mr.ShowDialog();
                    }
                }
            }
            var recompensa = 2;
            List<string> eqpRecup = new List<string>();
            for (int x = 0; x < Equipes.Rows.Count; x++)
            {
                if (Equipes.Rows[x]["ENABLED"].ToString() != "True")
                {
                    if (dic[x])
                    {
                        Equipes.Rows[x]["ENABLED"] = true;
                        Equipes.Rows[x]["VIDAS_EXTRA"] = int.Parse(Equipes.Rows[x]["VIDAS_EXTRA"].ToString()) + recompensa;
                        eqpRecup.Add(Equipes.Rows[x]["GP_NOME"].ToString());
                    }

                }
            }

            var orderedEqp = Equipes.Select("1=1", "PONTOS DESC");
            for (int x = 0; x < orderedEqp.Count(); x++)
            {
                var lblPos = new Label();
                var lblNome = new Label();
                var lblPontos = new Label();
                var lblAcertos = new Label();
                var lblErros = new Label();

                lblPos.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + orderedEqp[x]["GP_COLOR"].ToString());
                if (orderedEqp[x]["ENABLED"].ToString() == "False")
                {
                    lblNome.BackColor = Color.Gray;
                    lblPontos.BackColor = Color.Gray;
                    lblAcertos.BackColor = Color.Gray;
                    lblErros.BackColor = Color.Gray;
                }

                lblPos.Font = ranking.label4.Font;
                lblPos.Text = (x + 1) + "";
                lblPos.Dock = DockStyle.Fill;
                ranking.tableLayoutPanel1.Controls.Add(lblPos, 0, x);

                lblNome.Font = ranking.label4.Font;
                lblNome.Text = orderedEqp[x]["GP_NOME"].ToString();
                lblNome.Dock = DockStyle.Fill;
                ranking.tableLayoutPanel1.Controls.Add(lblNome, 1, x);

                lblPontos.Font = ranking.label4.Font;
                lblPontos.Text = orderedEqp[x]["PONTOS"].ToString() + " pts";
                lblPontos.Dock = DockStyle.Fill;
                ranking.tableLayoutPanel1.Controls.Add(lblPontos, 2, x);


                lblAcertos.Font = ranking.label4.Font;
                lblAcertos.Text = orderedEqp[x]["ACERTOS"].ToString() + " ACERTOS";
                lblAcertos.Dock = DockStyle.Fill;
                ranking.tableLayoutPanel1.Controls.Add(lblAcertos, 3, x);

                lblErros.Font = ranking.label4.Font;
                lblErros.Text = orderedEqp[x]["ERROS"].ToString() + " ERROS";
                lblErros.Dock = DockStyle.Fill;
                ranking.tableLayoutPanel1.Controls.Add(lblErros, 4, x);

            }
            if (eqpRecup.Count > 0)
            {
                ranking.Controls["lblAviso"].Text = $"OS SEGUINTES GRUPOS CONSEGUIRAM VOLTAR AO JOGO: {string.Join(", ", eqpRecup)}";
            }
            else
            {
                ranking.Controls["lblAviso"].Text = $"NENHUM GRUPO CONSEGUIU VOLTAR AO JOGO!";
            }
            ranking.Controls["button2"].Visible = false;
            ranking.ShowDialog();

        }
    }
}
