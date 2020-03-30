using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CadastroQuiz
{
    public partial class AreaParticipante : System.Web.UI.Page
    {
        DataTable userData = new DataTable();
        DataTable adminData = new DataTable();
        DataTable groupData = new DataTable();
        DataTable groupIntegrants = new DataTable();
        DataTable gpLink = new DataTable();
        String cor;
        bool corIsChecked = false;
        bool suasInformacoes = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((string)Session["partSession"] == "" || Session["partSession"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

                adminData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT P_ID FROM tbGrupoAdmin WHERE P_ID IN (SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {0})", Session["partSession"]));

                if (adminData.Rows.Count > 0)
                {
                    BtnGerenciarGrupo.Visible = false;
                }

                userData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT * FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {0}", Session["partSession"]));
                
                lblNomeBemVindo.Text = userData.Rows[0]["P_NOME"].ToString();
                lblNomePart.Text = userData.Rows[0]["P_NOME"].ToString();
                lblEmailPart.Text = userData.Rows[0]["P_LOGIN_EMAIL"].ToString();
                lblRmPart.Text = userData.Rows[0]["P_RM"].ToString();
                if (!userData.Rows[0]["P_GP_ID"].Equals(DBNull.Value))
                {
                    groupData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format($"SELECT * FROM tbGrupo WHERE GP_ID={userData.Rows[0]["P_GP_ID"]}"));
                    groupIntegrants = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", $"SELECT * FROM tbParticipante WHERE P_GP_ID={userData.Rows[0]["P_GP_ID"]}");
                    gpLink = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format($"SELECT * FROM tbGrupo_Link WHERE GP_ID={userData.Rows[0]["P_GP_ID"]}"));
                    bGpLink.InnerText = $"Link do grupo: {gpLink.Rows[0]["GP_LINK"]}";
                    TxtNomeGrupo.Text = groupData.Rows[0]["GP_NOME"].ToString();
                    TxtFraseGrupo.Text = groupData.Rows[0]["GP_FRASE"].ToString();
                    BtnCriarGrupo.Visible = false;
                    TxtLinkGrupo.Visible = false;
                    divEntreGrupo.Visible = false;
                    BtnEntrarNoGrupo.Visible = false;
                }
                else
                {
                    BtnGerenciarGrupo.Visible = false;
                    BtnExcluirGrupo.Visible = false;
                }
            }
        }
        protected void rdoBtn1_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn1.Checked)
            {
                cor = "0a0791";
            }
        }

        protected void rdoBtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn2.Checked)
            {
                cor = "00360b";
            }
        }

        protected void rdoBtn3_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn3.Checked)
            {
                cor = "f0f005";
            }
        }

        protected void rdoBtn4_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn4.Checked)
            {
                cor = "fa0000";
            }
        }

        protected void rdoBtn5_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn5.Checked)
            {
                cor = "ed7e00";
            }
        }

        protected void rdoBtn6_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn6.Checked)
            {
                cor = "5000b8";
            }
        }

        protected void rdoBtn7_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn7.Checked)
            {
                cor = "222222";
            }
        }

        protected void rdoBtn8_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn8.Checked)
            {
                cor = "45a2ff";
            }
        }

        protected void rdoBtn9_CheckedChanged(object sender, EventArgs e)
        {
            corIsChecked = rdoBtn9.Checked;

            if (corIsChecked == true)
            {
                cor = "51ff45";
            }
        }

        protected void rdoBtn10_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn10.Checked)
            {
                cor = "ff69f5";
            }
        }

        protected void rdoBtn11_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn11.Checked)
            {
                cor = "53292a";
            }
        }

        protected void rdoBtn12_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn12.Checked)
            {
                cor = "757575";
            }
        }

        protected void rdoBtn13_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn13.Checked)
            {
                cor = "4b280a";
            }
        }

        protected void rdoBtn14_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn14.Checked)
            {
                cor = "b666d2";
            }
        }

        protected void rdoBtn15_CheckedChanged(object sender, EventArgs e)
        {
            if (corIsChecked = rdoBtn15.Checked)
            {
                cor = "1fffec";
            }
        }

        protected void BtnCriarGrupo_Click(object sender, EventArgs e)
        {
            String gpID = "";
            String gpLink = "";
            bool succ = false;
            Random random = new Random();
            for (int i = 30; i > 0; i--) //tenta gerar um ID de participante unico 30 vezes, e inserre uma entrada..
            {
                gpID = random.Next().ToString();
                gpLink = Path.GetRandomFileName().Replace(".", "") + Path.GetRandomFileName().Replace(".", "").Remove(4);
                string queryPart = "";
                if (TxtNomeGrupo.Text != "" || TxtNomeGrupo.Text != null)
                {
                    queryPart = String.Format("INSERT INTO tbGrupo(GP_ID, GP_NOME, GP_FRASE, GP_COLOR) VALUES({0}, '{1}', '{2}', '{3}')", gpID, TxtNomeGrupo.Text.Replace("'","''"), TxtFraseGrupo.Text.Replace("'", "''"), cor);
                }
                if (QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", queryPart) != null) { succ = true;  break; }
            }
            if (!succ)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Campos preenchidos com valores já usados ou incorretos!');", true);
                return;
            }

            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("INSERT INTO tbGrupo_Link (GP_ID, GP_LINK) VALUES ({0}, '{1}')", gpID, gpLink));
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID = {0} WHERE P_ID IN (SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {1})", gpID, Session["partSession"]));
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("INSERT INTO tbGrupoAdmin (GP_ID) VALUES (SELECT P_GP_ID FROM tbParticipante WHERE P_ID IN (SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {0}))", Session["partSession"]));
            QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("UPDATE tbGrupoAdmin SET P_ID = (SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {0})", Session["partLogin"]));
            Response.Redirect("AreaParticipante.aspx");
        }

        protected void BtnExcluirGrupo_Click(object sender, EventArgs e)
        {
            
            if (!DBNull.Value.Equals(userData.Rows[0]["P_GP_ID"]))
            {
                QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("DELETE FROM tbGrupo_Link WHERE GP_ID = {0}", userData.Rows[0]["P_GP_ID"]));
                QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("DELETE FROM tbGrupoAdmin WHERE GP_ID = {0}", userData.Rows[0]["P_GP_ID"]));
                QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("UPDATE tbParticipante SET P_GP_ID=NULL WHERE P_GP_ID = {0}", userData.Rows[0]["P_GP_ID"]));
                QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("DELETE FROM tbGrupo WHERE GP_ID = {0}", userData.Rows[0]["P_GP_ID"]));
                Response.Redirect("AreaParticipante.aspx");
            }
        }

        protected void BtnEntratNoGrupo_Click(object sender, EventArgs e)
        {
            userData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("SELECT GP_LINK FROM tbGrupo_Link WHERE GP_LINK='{0}'", TxtLinkGrupo.Text));

            if (userData.Rows.Count > 0)
            {
                userData = QuizDBConnect.Query("sa", "etesp", "dbQuiz2019", String.Format("UPDATE tbParticpante SET P_GP_ID = (SELECT GP_ID FROM tbGrupo_Link WHERE GP_LINK = '{0}') WHERE P_ID IN (SELECT tP.P_ID FROM tbParticipante AS tP JOIN tbPart_Login AS tPL ON tP.P_ID = tPL.P_ID WHERE P_LOGIN_ID = {1})", TxtLinkGrupo.Text, (int)Session["partSession"]));
            }
        }

        protected void BtnGerenciarGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerenciarGrupo.aspx");
        }

        protected void btnSair_Click(object sender, ImageClickEventArgs e)
        {
            Session["partSession"] = null;
            Response.Redirect("Login.aspx");
        }

        /*protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            String cor = RadioButton1.Attributes["Value"];
        }*/
    }

    /*protected void deslogLink_ServerClick(object sender, EventArgs e)
    {
        Session["partSession"] = null;
        Response.Redirect("Login.aspx");
    }

    protected void gpSair_ServerClick(object sender,EventArgs e)
    {
        
    }

    protected void gpDele_ServerClick(object sender, EventArgs e)
    {

    }

    protected void gpAdd_ServerClick(object sender, EventArgs e)
    {

    }

    protected void gpRem_ServerClick(object sender, EventArgs e)
    {

    }*/

}
/*}*/