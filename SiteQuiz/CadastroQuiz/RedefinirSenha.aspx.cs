using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroQuiz
{
    public partial class RedefinirSenha : System.Web.UI.Page
    {

        DataTable userData = new DataTable();
        DataTable userData2 = new DataTable();
        DataTable userData3 = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRedefinirSenha_Click(object sender, EventArgs e)
        {

            userData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT P_LOGIN_EMAIL FROM tbToken_Senha WHERE P_TOKEN = '{0}'", Request.Params["token"].ToString()));

            if (userData.Rows.Count > 0)
            {
                if (txtSenha.Text == txtConfirmar.Text)
                {

                    userData2 = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("UPDATE tbPart_Login SET P_LOGIN_PASS = '{0}' WHERE P_ID IN (SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_EMAIL = (SELECT P_LOGIN_EMAIL FROM tbToken_Senha WHERE P_TOKEN = '{1}'))", PasswordHasher.hash(txtSenha.Text, "saltGoesHere"), Request.Params["token"].ToString()));
                    userData3 = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("DELETE FROM tbToken_Senha WHERE P_TOKEN = '{0}'", Request.Params["token"]));
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}