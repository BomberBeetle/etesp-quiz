<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="EsqueceuSenha.aspx.cs" Inherits="CadastroQuiz.EsqueceuSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoVerificarEmail">
        <div class="divTextoVerificarEmail">
            <h1 class="h1VerificarEmail"> Enviamos um e-mail para você</h1>
            <p class="pVerificarEmail">Uma mensagem com um link para redefinir sua senha foi mandado para o seu endereço de email, verifique sua caixa de entrada e se não estiver nela cheque a pasta de spam <span id="emailSpan" runat="server"></span>. Por favor, verifique sua caixa de spam. O link de verificação pode ser marcado como inseguro.<br/>
    O email virá da conta etespquiz@gmail.com
                <a href="javascript:void()" id="resendLink" runat="server">Clique aqui se o E-Mail não foi mandado automaticamente.</a>
            </p>
        </div>

        <div class="divImgVerificarEmail">
            <!--<img src="Imagens/imgMulherEmail.svg" class="imgMulher"/>-->
            <img src="Imagens/imgMailBox.svg" class="imgCorreio"/>
        </div>
    </div>
</asp:Content>