using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroQuiz
{
    public partial class VerificationEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable query = new DataTable();
            if (Session["email"] != null)
            {
                query = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT P_LOGIN_VERIFIED FROM tbPart_Login WHERE P_LOGIN_EMAIL='{0}'", Session["email"].ToString()));
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (query == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (query.Rows[0][0].ToString() == "1")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                emailSpan.InnerText = Session["email"].ToString();
            }
        }
        private void resendVerification()
        {
            DataTable query = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT tbPart_Login_Verify.P_LOGIN_VERIFY_URL, tbParticipante.P_RM,tbParticipante.P_NOME, tbPart_Login.P_LOGIN_EMAIL FROM tbPart_Login, tbParticipante, tbPart_Login_Verify WHERE tbPart_Login.P_LOGIN_EMAIL='{0}' AND tbPart_Login_Verify.P_LOGIN_ID=tbPart_Login.P_LOGIN_ID", Session["email"].ToString()));
            QuizUtils.Cadastro.SendVerification(query.Rows[0]["P_LOGIN_VERIFY_URL"].ToString(), query.Rows[0]["P_LOGIN_EMAIL"].ToString(), query.Rows[0]["P_NOME"].ToString(), query.Rows[0]["P_RM"].ToString());
        }

        protected void resendLink_ServerClick(object sender, EventArgs e)
        {
            resendVerification();
        }
    }
}