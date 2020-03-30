using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

namespace CadastroQuiz
{
    public partial class Login : System.Web.UI.Page
    {

        DataTable userData = new DataTable();
        DataTable userData2 = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["partSession"] != null)
            {
                Response.Redirect("AreaParticipante.aspx");
            }
        }
        private void tentarLogin()
        {
            DataTable query = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT P_LOGIN_ID, P_LOGIN_VERIFIED FROM tbPart_Login WHERE P_LOGIN_EMAIL='{0}' AND P_LOGIN_PASS='{1}'", txtEmail.Text.Replace("'", "''"), PasswordHasher.hash(txtSenha.Text, "saltGoesHere")));
            if (query == null)
            {
                lblAvisoSenha.Text = "Dificuldades em alcançar o banco de dados. Tente novamente daqui á pouco.";
            }
            else if (query.Rows.Count != 0)
            {
                if (query.Rows[0][1].ToString() == "0")
                {
                    lblAvisoSenha.Text = "Sua conta ainda não foi verificada! Verifique sua caixa de entrada para obter o link de verificação";
                }
                else
                {
                    Session["partSession"] = query.Rows[0][0].ToString();
                    Response.Redirect("AreaParticipante.aspx");
                }
            }
            else
            {
                lblAvisoSenha.Text = "Senha ou Email errados!";
            }
        }

        protected void loginButton_ServerClick(object sender, EventArgs e)
        {
            tentarLogin();
        }

        protected void btnEsqueceuSenha_Click(object sender, EventArgs e)
        {
            userData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_EMAIL = '{0}'", txtEmailEsq.Text));

            if (userData.Rows.Count > 0)
            {
                string token = "";
                for (int i = 30; i > 0; i--) //tenta gerar um ID de token unico 30 vezes, e insere uma entrada.
                {
                    token = Path.GetRandomFileName().Replace(".", "") + Path.GetRandomFileName().Replace(".", "").Remove(4);
                    userData2 = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("INSERT INTO tbToken_Senha (P_TOKEN, P_LOGIN_EMAIL) VALUES ('{0}', '{1}')", token, txtEmailEsq.Text));
                    if (userData2 != null) break;
                }

                string htmlString = string.Format("<h1>Clique neste link para redefinir a senha da sua conta com o email {0}:</h1><br/><a href='http://siteDoQuiz.tk/RedefinirSenha.aspx?token={1}'>Redefinir Senha</a><br />Esta é uma mensagem automática. Não responda.", txtEmailEsq.Text, token);
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("etespquiz@gmail.com");
                message.To.Add(new MailAddress(txtEmailEsq.Text));
                message.Subject = "Verifique sua conta de participante do Etesp Quiz";
                message.IsBodyHtml = true;
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("etespquiz@gmail.com", "b7fa4df2c0ba5fc40017de3990f09fe3e1fd60ef");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }

            Response.Redirect("EsqueceuSenha.aspx");
        }
    }
}