<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="RedefinirSenha.aspx.cs" Inherits="CadastroQuiz.RedefinirSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoRedefinir">

        <div class="divEsqRedefinir" id="divRedefinirSenha" runat="server">
            <h1 class="h1RedefinirSenha">Redefinir a Senha</h1>
            <p class="pRedefinirSenha"></p>

            <div class="formulario1">
                <div class="espacolabel"></div>

                <div class="espacotxt">
                    <div class="divLblRedefinir">
                        <asp:Label ID="Label2" runat="server" CssClass="lblRedSenha" Text="Senha" ></asp:Label>
                    </div>

                    <div class="divTxtRedefinir">
                        <asp:TextBox ID="txtSenha" runat="server" CssClass="txtRedefinirSenha" Placeholder="" type="password" ClientIDMode="Static"></asp:TextBox>
                        <div class="olho2" id="olho2"><input type="button" onclick="RevelarSenha2()" id="btnRevelar2"/></div>
                    </div>
                </div> <br />
                <asp:Label ID="lblAvisoSenha" runat="server" Text=""></asp:Label>
            </div>

            <div class="formulario1">
                <div class="espacolabel"></div>

                <div class="espacotxt">
                    <div class="divLblRedefinir">
                        <asp:Label ID="Label1" runat="server" CssClass="lblRedSenha" Text="Confirmar Senha" ></asp:Label>
                    </div>

                    <div class="divTxtRedefinir">
                        <asp:TextBox ID="txtConfirmar" runat="server" CssClass="txtConfirmarRedefinirSenha" Placeholder="" type="password"></asp:TextBox>
                    </div>
                </div>

                <div class="espacoAviso"><asp:Label ID="lblAvisoConfirmarSenha" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
            </div>

            <div class="divBtnRedefinirSenha">
                <asp:Button ID="BtnRedefinirSenha" runat="server" Text="Redefinir Senha" CssClass="btnRedefinirSenha" OnClick="BtnRedefinirSenha_Click"/>
            </div>
        </div>

        <div class="divDirRedefinir">
            <img src="Imagens/passwordFor.svg" class="imgRedefinir" />
        </div>
    </div>
</asp:Content>