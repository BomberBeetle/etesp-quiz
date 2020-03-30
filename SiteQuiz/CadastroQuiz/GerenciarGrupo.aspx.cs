using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroQuiz
{
    public partial class GerenciarGrupo : System.Web.UI.Page
    {

        DataTable userData = new DataTable();
        DataTable groupIntegrants = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["partSession"] == null || (string)Session["partSession"] == "")
            {
                Response.Redirect("Login.aspx");
            }
            userData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT * FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {0}", Session["partSession"]));
            groupIntegrants = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"SELECT * FROM tbParticipante WHERE P_GP_ID={userData.Rows[0]["P_GP_ID"]}");
            i1.Visible = false;
            i2.Visible = false;
            i3.Visible = false;
            i4.Visible = false;
            i5.Visible = false;
            try
            {
                TxtPartRM1.Text = groupIntegrants.Rows[0]["P_RM"].ToString();
                TxtNome1.Text = groupIntegrants.Rows[0]["P_NOME"].ToString();
                i1.Visible = true;

                TxtPartRM2.Text = groupIntegrants.Rows[1]["P_RM"].ToString();
                TxtNome2.Text = groupIntegrants.Rows[1]["P_NOME"].ToString();
                i2.Visible = true;

                TxtPartRM3.Text = groupIntegrants.Rows[2]["P_RM"].ToString();
                TxtNome3.Text = groupIntegrants.Rows[2]["P_NOME"].ToString();
                i3.Visible = true;

                TxtPartRM4.Text = groupIntegrants.Rows[3]["P_RM"].ToString();
                TxtNome4.Text = groupIntegrants.Rows[3]["P_NOME"].ToString();
                i4.Visible = true;

                TxtPartRM5.Text = groupIntegrants.Rows[4]["P_RM"].ToString();
                TxtNome5.Text = groupIntegrants.Rows[4]["P_NOME"].ToString();
                i5.Visible = true;
            }
            catch
            {

            }
        }

        protected void BtnVoltarAreaParticipante_Click(object sender, EventArgs e)
        {
            Response.Redirect("AreaParticipante.aspx");
        }

        protected void BtnExcluir1_Click(object sender, EventArgs e)
        {
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={groupIntegrants.Rows[0]["P_ID"]}");
            Response.Redirect("GerenciarGrupo.aspx");
        }

        protected void BtnExcluir2_Click(object sender, EventArgs e)
        {
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={groupIntegrants.Rows[1]["P_ID"]}");
            Response.Redirect("GerenciarGrupo.aspx");
        }

        protected void BtnExcluir3_Click(object sender, EventArgs e)
        {
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={groupIntegrants.Rows[2]["P_ID"]}");
            Response.Redirect("GerenciarGrupo.aspx");
        }

        protected void BtnExcluir4_Click(object sender, EventArgs e)
        {
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={groupIntegrants.Rows[3]["P_ID"]}");
            Response.Redirect("GerenciarGrupo.aspx");
        }

        protected void BtnExcluir5_Click(object sender, EventArgs e)
        {
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_ID={groupIntegrants.Rows[4]["P_ID"]}");
            Response.Redirect("GerenciarGrupo.aspx");
        }
    }
}