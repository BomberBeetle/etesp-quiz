 <%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Verifica.aspx.cs" Inherits="CadastroQuiz.Verifica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
     <div class="divCorpoVerifica">
        <h1 class="h1Verifica">Parabéns, sua conta foi verificada!</h1>
        <p class="pAVolta"><a id="aVolta" href="Login.aspx">Clique aqui para voltar para a página de login</a></p>
        <img src="Imagens/imgMailSent.svg" class="imgOk" />
    </div>
</asp:Content>