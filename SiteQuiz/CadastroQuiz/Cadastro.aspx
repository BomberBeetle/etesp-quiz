<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="CadastroQuiz.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="cad">
        <div class="imgQuizCad">
            <img src="Imagens/imgCad.jpg" class="imgQuiz"/>
        </div>

        <div class="preenche">
            <div class="titulo">
                <h1 class="tit"><b>Faça a sua inscrição</b></h1>
            </div>

            <div class="formulario1">
                <div class="espacolabel"><asp:Label ID="lblNome" runat="server" CssClass="lbl1" Text="Nome"></asp:Label></div>

                <div class="espacotxt"><asp:TextBox ID="txtNome" runat="server" CssClass="txt1" Placeholder=""></asp:TextBox> </div><br />

                <div class="espacoAviso"><asp:Label ID="lblAvisoNome" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
            </div>

            <div class="formulario1">
                <div class="espacolabel"><asp:Label ID="lblRM" runat="server" CssClass="lbl1" Text="RM"></asp:Label></div>

                <div class="espacotxt"><asp:TextBox ID="txtRM" runat="server" CssClass="txt1" Placeholder="" MaxLenght="5"></asp:TextBox> </div><br />

                <div class="espacoAviso"><asp:Label ID="lblAvisoRM" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
            </div>

            <div class="formulario1">
                <div class="espacolabel"><asp:Label ID="lblEmail" runat="server" CssClass="lbl1" Text="E-mail"></asp:Label></div>

                <div class="espacotxt"><asp:TextBox ID="txtEmail" runat="server" CssClass="txt1" Placeholder=""></asp:TextBox></div> <br />

                <div class="espacoAviso"><asp:Label ID="lblAvisoEmail" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
            </div>

            <div class="formulario1">
                <div class="espacolabel"><asp:Label ID="lblSenha" runat="server" CssClass="lbl1" Text="Senha" ></asp:Label></div>

                <div class="espacotxt">
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="txtSenha" Placeholder="" type="password" ClientIDMode="Static"></asp:TextBox>
                    <div class="olho" id="olho"><input type="button" onclick="RevelarSenha()" id="btnRevelar"/></div>
                </div> <br />
                <asp:Label ID="lblAvisoSenha" runat="server" Text=""></asp:Label>
            </div>

            <div class="formulario1">
                <div class="espacolabel"><asp:Label ID="lblConfirmar" runat="server" CssClass="lbl1" Text="Confirmar Senha" ></asp:Label></div>

                <div class="espacotxt"><asp:TextBox ID="txtConfirmar" runat="server" CssClass="txt1" Placeholder="" type="password"></asp:TextBox> <br /></div>

                <div class="espacoAviso"><asp:Label ID="lblAvisoConfirmarSenha" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
            </div>

            <div class="formulario1">
                <div class="divRobo"><p class="lbl1">Não sou um robô!</p><asp:CheckBox ID="captchabox" runat="server" CssClass="inputRobo"/></div>
                <asp:Button ID="btnCadastrar" runat="server" CssClass="botao" Text="Cadastrar" OnClick="btnCadastrar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>