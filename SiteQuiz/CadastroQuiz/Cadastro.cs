using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace QuizUtils
{
    public static class Cadastro
    {
        static string sqlUser = "sa";
        static string sqlPass = "etesp";
        static string sqlDb = "dbQuiz2019";
        public static void CadastrarAluno(string nome, string email, string rm, string pass, string passConfirm, bool captcha)
        {
            Regex rmRgx = new Regex(@"^[0-9]{5}$");
            if (!IsValidEmail(email))
            {
                throw new InvalidEmailException(email);
            }
            if (!rmRgx.IsMatch(rm))
            {
                throw new InvalidRMException(rm);
            }
            if (QuizDBConnect.Query(sqlUser, sqlPass, sqlDb, String.Format("SELECT P_RM FROM tbParticipante WHERE P_RM='{0}'", rm)).Rows.Count != 0) throw new RMInUseException(rm);
            if (QuizDBConnect.Query(sqlUser, sqlPass, sqlDb, String.Format("SELECT P_LOGIN_EMAIL FROM tbPart_Login WHERE P_LOGIN_EMAIL='{0}'", email.Replace("'", "''"))).Rows.Count != 0) throw new EmailInUseException(email);
            if (pass != passConfirm)
            {
                throw new PassMismatchException();
            }
            if (!captcha)
            {
                throw new InvalidCaptchaException();
            }
            Random random = new Random();
            int userId = new int();
            bool success = false;
            for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
            {
                userId = random.Next();
                string queryPart = "";
                queryPart = String.Format("INSERT INTO tbParticipante(P_ID, P_NOME, P_RM) VALUES('{0}','{1}', '{2}')", userId, nome.Replace("'", "''"), rm);
                if (QuizDBConnect.Query(sqlUser, sqlPass, sqlDb, queryPart) != null) { success = true; break; }
            }
            string verifyToken = "";
            if (success)
            {
                for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e insere uma entrada.
                {
                    string queryLogin = "";
                    int loginId = random.Next();
                    verifyToken = Path.GetRandomFileName().Replace(".", "") + Path.GetRandomFileName().Replace(".", "").Remove(4);
                    queryLogin = String.Format("INSERT INTO tbPart_Login(P_ID, P_LOGIN_EMAIL, P_LOGIN_ID, P_LOGIN_PASS, P_LOGIN_VERIFIED) VALUES({0},'{1}',{2}, '{3}', 0)", userId, email.Replace("'", "''"), loginId, PasswordHasher.hash(pass, "saltGoesHere"));
                    DataTable query = QuizDBConnect.Query(sqlUser, sqlPass, sqlDb, queryLogin);
                    DataTable tkCreate = QuizDBConnect.Query(sqlUser, sqlPass, sqlDb, String.Format("INSERT INTO tbPart_Login_Verify(P_LOGIN_VERIFY_URL,P_LOGIN_ID) VALUES('{0}',{1})", verifyToken, loginId));
                    if (query != null && tkCreate != null) break;
                }
            }
            SendVerification(verifyToken, email, nome, rm);

        }
        public static void VerificarAluno(string token)
        {
            string query = string.Format("UPDATE tbPart_Login SET P_LOGIN_VERIFIED=1, P_LOGIN_VERIFY_URL=NULL WHERE P_LOGIN_VERIFY_URL='{0}'", token.Replace("'", "''"));
            QuizDBConnect.Query(sqlUser, sqlPass, sqlDb, query);
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void SendVerification(string token, string email, string nome, string rm)
        {
            try
            {
                string htmlString = string.Format("<h1>Clique neste link para verificar sua conta, {0}:</h1><br/><a href='http://siteDoQuiz.tk/Verifica.aspx?token={1}'>Verificar Conta</a><br />Seu RM é: {2}<br/>Esta é uma mensagem automática. Não responda.", nome, token, rm);
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("etespquiz@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Verifique sua conta de participante do Etesp Quiz";
                message.IsBodyHtml = true;
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("etespquiz@gmail.com", "b7fa4df2c0ba5fc40017de3990f09fe3e1fd60ef");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch
            {

            }
        }

    }
}

