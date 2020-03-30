<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CadastroQuiz.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divEspacoLogin" id="divLogin">
        <!--<div class="divTitulo">
            <h1 class="h1LoginAluno">Login Aluno</h1>
        </div>
        <p class="pLogin">Email: </p><input type="email" runat="server" id="emailField" class=""/><br/>
        <p class="pLogin">Senha: </p><input type="password" runat="server" id="passField" />  Mostrar Senha <input type="checkbox" id="showpassField" onchange="togglePass()"/><br/>
        <span id="warning" runat="server"></span><br/><br/>
        <a href="Cadastro.aspx">Primeira vez no site? Clique aqui para se cadastrar.</a>-->
        <div class="divTitulo">
            <div class="divTituloLogin"><h1 class="h1LoginAluno">Login</h1></div>
            <div class="divImgCadeado"><img src="Imagens/cadeado.png" class="imgCadeadoLogin" /></div>
        </div>

        <div class="formulario2">
                <!--<div class="espacolabel">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl1" Text="Acessar como"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddlLogin">
                        <asp:ListItem Text="Aluno" Value="Aluno"></asp:ListItem>
                        <asp:ListItem Text="Professor" Value="Professor"></asp:ListItem>
                    </asp:DropDownList>
                </div> <br />-->

                <div class="espacoAviso"><asp:Label ID="Label2" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
        </div>
        <div class="formulario1">
                <div class="espacolabel"><asp:Label ID="lblEmail" runat="server" CssClass="lbl1" Text="E-mail"></asp:Label></div>
                <div class="espacotxt"><asp:TextBox ID="txtEmail" runat="server" CssClass="txt1" Placeholder=""></asp:TextBox></div> <br />
                <div class="espacoAviso"><asp:Label ID="lblAvisoEmail" runat="server" Text="" CssClass="lblAviso"></asp:Label></div>
        </div>
         <div class="formulario1">
            <div class="espacolabel"><asp:Label ID="lblSenha" runat="server" CssClass="lbl1" Text="Senha" ></asp:Label></div>
                <div class="espacotxt">
                    <!--<div class="txtbtn" id="txtbtn">-->
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="txtSenha" Placeholder="" type="password" ClientIDMode="Static" AutoPostBack="true"></asp:TextBox>
                    <div class="olho" id="olho"><input type="button" onclick="RevelarSenha()" id="btnRevelar"/></div> 
                    <!--</div>-->
                </div> 

                <div class="espacoAviso"><asp:Label ID="lblAvisoSenha" CssClass="lblAviso" runat="server" Text=""></asp:Label></div>
        </div>

        <div class="divEsqueciSenha">
            <p class="pEsqueciSenha" onclick="EsqueceuSenha()">Esqueceu a Senha?</p>
        </div>

        <div class="formulario1">
            <div class="divBtnLogin"><input type="button" runat="server" id="loginButton" value="Login" onserverclick="loginButton_ServerClick" class="btnLogin"/></div>
            <a href="Cadastro.aspx" class="aPrimeiraVez">Primeira vez no site? Clique aqui para se cadastrar.</a>
        </div>
    </div>

    <div class="divEsqueceuSenha" id="divEsqueceuSenha">
        <div class="divTituloEsqueceuSenha">
            <div class="divForgo">
                <h1 class="h1ForgotPassword">Esqueceu a Senha?</h1>
            </div>

            <div class="divFormEsqueceuSenha">
                <p class="pEsqSenha"> Esqueceu a Senha? Digite seu e-mail e enviaremos para você um link de redirecionamento para redefinir a senha</p>
                <asp:Label ID="Label3" runat="server" Text="E-mail" CssClass="lblEmailEsqueci"></asp:Label>
                <div class="divTxtEmailEsq">
                    <asp:TextBox ID="txtEmailEsq" runat="server" CssClass="txtEmailEsq"></asp:TextBox>
                </div>               
                <asp:Label ID="lblAvisoEsqSenha" runat="server" Text="DFSDFH" CssClass="lblAviso2"></asp:Label>
                <asp:Button ID="btnEsqueceuSenha" runat="server" Text="Enviar E-mail" CssClass="btnEnviarSenha" OnClick="btnEsqueceuSenha_Click"/>
                <p onclick="VoltarLogin()" class="pVoltarLogin">Voltar para o Login</p>
            </div>

            <div class="divImgForgo">
                <img src="Imagens/senhaEsqueceu.svg" class="imgEsqueceuSenha"/>
            </div>         
        </div>
    </div>
</asp:Content>