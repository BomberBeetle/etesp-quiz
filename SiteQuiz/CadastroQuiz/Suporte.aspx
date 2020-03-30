<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Suporte.aspx.cs" Inherits="CadastroQuiz.Suporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoSuporte">
        <div class="divSuporteGrande">
            <div class="divSuporteTexto">
                <p class="h1TituloSuporte"><b>Suporte e Ajuda</b></p>
                <p class="pComoInscrever"><b> - Como se Inscrever:</b></p>
                <p class="pResposta">Para se inscrever, primeiramente acesse a página de inscrição, depois preencha os campos de nome, e-mail, RM, senha e confirmar senha e não se esqueça de confirmar o campo "Eu não sou um Robô"
                    , feito isso clique no botão de inscrição e será enviado um e-mail de confirmação para você.
                </p>
                <p class="pComoInscrever"><b> - Como efetuar o Login:</b></p>
                <p class="pResposta">Para fazer o login, acesse a página de login clicando no texto correspondente no cabeçalho, nessa página selecione "Acessar como Aluno", e preencha os campos com seu e-mail e sua senha definidos na inscrição.
                    Em seguida clique no botão de Login e se os dados estiverem corretos você será redirecionado a Área do Participante                    
                </p>
                <p class="pComoInscrever"><b> - Esqueceu a Senha:</b></p>
                <p class="pResposta">
                    Caso tenha se esquecido de sua senha, acesse a página de Login, clique em "Esqueceu a senha" e será enviado um e-mail para você com um link para redefinir sua senha. 
                </p>
                <p class="pComoInscrever"><b> - Como cadastrar um Grupo:</b></p>
                <p class="pResposta">
                    Após efetuar o login, clique em "Seu Grupo" na página da área do participante, logo escolha um nome, uma frase e uma cor para seu grupo, lembrando que não é possível alterar a cor depois de escolhida.
                    Depois acrescente os participantes digitando o RM de cada um. Para seu grupo participar do ETESP Quiz é necessário que ele tenha 5 participantes, então certifique-se da quantidade de pessoas em seu grupo.
                </p>
                <p class="pComoInscrever"><b> - Outras Dúvidas:</b></p>
                <p class="pResposta">
                    Para mais ajuda envie um e-mail para etespquiz@gmail.com
                </p>
            </div>

            <div class="divSuporteImagem">
                <img src="Imagens/Suporte.svg" class="imgSuporte" />
            </div>
        </div>
    </div>
</asp:Content>