<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Regras.aspx.cs" Inherits="CadastroQuiz.Regras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoRegras">
        <div class="divTxtRegras">
            <p class="pTituloRegras"><b>Regras</b></p>
            <p class="pRegras"> Equipes com 5 pessoas. Aquela que terminar com mais pontos vence; </p>
            <p class="pRegras">As questões do jogo são de múltiplos assuntos e cada uma tem o mesmo tempo para resposta. Esse tempo não tem um valor fixo, mas, geralmente, não deve passar de 30 segundos. </p>  
            <p class="pRegras">Usa-se uma prancheta na qual serão escritas as respostas das questões. Ao fim do tempo de resposta de cada questão, as equipes devem mostrar sua resposta na prancheta; </p> 
            <p class="pRegras">A equipe ganha 2 pontos por acerto. Se acertar por meio de dicas, perde 1 ponto; se for a única a acertar, ganha 1 ponto extra; </p>    
            <p class="pRegras">Pode haver questões de recuperação para impedir a eliminação de equipes; </p>    
            <p class="pRegras">Quando perto do fim do jogo, as melhores equipes vão para a fase final, as últimas questões. As demais equipes são eliminadas.</p>    
            
        </div>

        <div class="divImgRegras">
            <img src="Imagens/terms.svg" class="imgTerms" />
        </div>
    </div>
</asp:Content>