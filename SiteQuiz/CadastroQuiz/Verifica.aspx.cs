using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroQuiz
{
    public partial class Verifica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["token"] == null) Response.Redirect("Login.aspx");
            string token = Request.Params["token"].ToString().Replace("'", "''");
            DataTable query = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT P_LOGIN_ID FROM tbPart_Login_Verify WHERE P_LOGIN_VERIFY_URL='{0}'", token));
            if (query != null)
            {
                if (query.Rows.Count != 0)
                {
                    QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("UPDATE tbPart_Login SET P_LOGIN_VERIFIED=1 WHERE P_LOGIN_ID='{0}'", query.Rows[0]["P_LOGIN_ID"]));
                    Session["email"] = null;
                    return;
                }
            }
            Response.Redirect("Login.aspx");
        }

        protected void btnVolta_ServerClick(object sender, EventArgs e)
        {

        }
    }
}