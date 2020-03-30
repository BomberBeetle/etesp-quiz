<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CadastroQuiz.Index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="corpoIndex">
        <div class="divCadastroGeral">
            <div class="divTituloCadGeral">
                <h1> Faça sua Inscrição </h1>
            </div>

            <div class="divCadAluno">
                <a href="Cadastro.aspx">
                    <img src="Imagens/alun.jpg" class="imgCadastro" />
                </a>    
            </div>
        </div>
        <div class="divQuiz">
            <div class="divWhatIsQuiz">
                <div class="divTextWhatQuiz">
                    <div class="divH1TextWhatQuiz">
                        <h1 class="h1TextWhatQuiz">O que é ETESP Quiz? </h1>
                    </div>

                    <div class="divPTextWhatQuiz">
                        <p class="pTextWhatQuiz"> ETESP Quiz é uma das atrações da Semana da Primavera na ETESP, um evento anual. O quiz não é sobre a ETESP, mas sim sobre diversas áreas do conhecimento. É um jeito de testar os conhecimentos de um modo mais competitivo e descontraído.
                        </p>
                        <p class="pTextWhatQuiz">O jogo foi feito por um grupo da turma de Informática 2018</p>
                    </div>
                </div>

                <div class="divImgWhatQuiz">
                    <img src="Imagens/interrogacoes.jpg" class="imgQuiz1" />
                </div>
            </div>

            <div class="divHowDoYouPlayQuiz">
                <div class="divImgWhatQuiz2">
                    <img src="Imagens/homemPensando.jpg" class="imgQuiz2" />
                </div>

                <div class="divTextWhatQuiz2">
                    <div class="divH1TextWhatQuiz">
                        <h1 class="h1TextWhatQuiz2">Como jogar o ETESP Quiz? </h1>
                    </div>

                    <div class="divPTextWhatQuiz">
                        <p class="pTextWhatQuiz2"> Equipes de 5 participantes competem respondendo questões de vários assuntos. Cada uma delas tem um tempo para ser respondida. Para responder, é usada pela equipe uma prancheta com papel e um canetão. Nela será escrita a resposta da equipe e é essa prancheta que deverá ser mostrada quando o tempo da questão acabar.</p>
                        <p class="pTextWhatQuiz2"> Para mais informações sobre as regras <a href="Regras.aspx">clique aqui</a></p>
                    </div>
                </div>
            </div>

            <div class="divInscrevase">
                <div class="divTextWhatQuiz3">
                    <div class="divH1TextWhatQuiz">
                        <h1 class="h1TextWhatQuiz"> Como Participar? </h1>
                    </div>

                    <div class="divPTextWhatQuiz">
                        <p class="pTextWhatQuiz"> Diferentemente das edições passadas do ETESP Quiz, a edição de 2019 terá a inscrição dos participantes feita on-line. Se você quer participar do ETESP Quiz 2019, monte a sua equipe de 5 participantes e vá para a página de inscrição deste site para garantir a participação de toda a equipe.</p>
                        <p class="pTextWhatQuiz"> Para se inscrever <a href="Cadastro.aspx">clique aqui</a>. Se você já estiver inscrito <a href="Login.aspx">clique aqui</a> para acessar o Login</p>
                    </div>
                </div>
                <div class="divImgWhatQuiz3">
                    <img src="Imagens/mulherIdeia.jpg" class="imgQuiz3" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>