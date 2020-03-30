<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="VerificationEmail.aspx.cs" Inherits="CadastroQuiz.VerificationEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoVerificarEmail">
        <div class="divTextoVerificarEmail">
            <h1 class="h1VerificarEmail"> Inscrição feita com sucesso</h1>
            <p class="pVerificarEmail">Um email com link de verificação foi mandado para o seu endereço de email <span id="emailSpan" runat="server"></span>. Por favor, verifique sua caixa de spam. O link de verificação pode ser marcado como inseguro.<br/>
    O email virá da conta etespquiz@gmail.com
                <a href="javascript:void()" id="resendLink" onserverclick="resendLink_ServerClick" runat="server">Clique aqui se o E-Mail não foi mandado automaticamente.</a>
            </p>
        </div>

        <div class="divImgVerificarEmail">
            <img src="Imagens/imgMailBox.svg" class="imgCorreio"/>
        </div>
    </div>
</asp:Content>