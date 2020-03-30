using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroQuiz
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRevelarSenha_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            tentarCadastro();
        }
        public void tentarCadastro()
        {
           try
            {
                lblAvisoRM.Text = "";
                lblAvisoRM.Text = "";
                lblAvisoConfirmarSenha.Text = "";
                lblAvisoSenha.Text = "";
                QuizUtils.Cadastro.CadastrarAluno(txtNome.Text.Replace("'", "''"), txtEmail.Text.Replace("'", "''"), txtRM.Text.Replace("'", "''"), txtSenha.Text, txtConfirmar.Text, captchabox.Checked);
                Session["email"] = txtEmail.Text.Replace("'", "''");
                Response.Redirect("VerificationEmail.aspx");
            }
            catch (RMInUseException)
            {
                lblAvisoRM.Text = "RM já está em uso!";
            }
            catch (EmailInUseException)
            {
                lblAvisoEmail.Text = "E-Mail já está em uso!";
            }
            catch (InvalidEmailException)
            {
                lblAvisoEmail.Text = "E-Mail inválido!";
            }
            catch (InvalidRMException)
            {
                lblAvisoRM.Text = "RM Inválido!";
            }
            catch (InvalidCaptchaException)
            {
                lblAvisoConfirmarSenha.Text = "Você é um robô!";
            }
            catch (PassMismatchException)
            {
                lblAvisoSenha.Text = "Os dois campos de senha não são iguais!";
            }
        }
    }
}