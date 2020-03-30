<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="AreaParticipante.aspx.cs" Inherits="CadastroQuiz.AreaParticipante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoAreaParticipante" id="divCorpoAreaParticipante">
        <div class="divTituloAreaParticipante">
            <h1 class="h1AreaParticante">Área do Participante </h1>
            <p class="pBemVindo">Seja bem-vindo(a) <asp:label runat="server" ID="lblNomeBemVindo" Text=""></asp:label></p>
        </div>

        <div class="divImgSair">
            <asp:ImageButton ID="btnSair" runat="server" OnClick="btnSair_Click" ImageUrl="Imagens/ImgSairLogin.svg" CssClass="imgSair"/>
            <p class="pSair">Sair</p>
        </div>
              
        <div class="divGrandeParticipante" id="divGrandeParticipante">
            <div class="divMenusParticipante" id="Mnu">
                <div class="divSeusDados">
                    <a class="aSeusDados" onclick="MostrarDados()"><h1>Seus Dados</h1> </a>
                </div>

                <div class="divSeuGrupo" id="divSeuGrupo">
                    <a class="aSeusDados" id="seuGrupo" onclick="MostrarGrupos()"> <h1>Seu Grupo</h1></a>
                </div>
            </div>

            <div class="divConteudoParticipante" id="divConteudoParticipante">
                <div class="divConteudoDados" id="divContDados">
                    <div class="divTitGerencieGrupo">
                        <h1>Verifique seus Dados</h1>
                    </div>

                    <div class="divSeusDadosParticipante">
                        <div class="divSeuNome">
                            <p><b>Seu nome:</b> <asp:Label ID="lblNomePart" runat="server" Text="" CssClass="spanRetorno"></asp:Label></p>
                        </div>

                        <div class="divSeuNome">
                            <p><b>Seu RM: </b> <asp:Label ID="lblRmPart" runat="server" Text="" CssClass="spanRetorno"></asp:Label></p>
                        </div>

                        <div class="divSeuNome">
                            <p><b>Seu E-mail: </b> <asp:Label ID="lblEmailPart" runat="server" Text="" CssClass="spanRetorno"></asp:Label></p>
                        </div>
                    </div>

                    <div class="divImgDados">
                        <img src="Imagens/dados.svg" class="imgDados" />
                    </div>
                </div>

                <div class="divConteudoGrupo" id="divContGrupo">
                    <div class="divTitGerencieGrupo">
                        <h1>Gerencie seu Grupo </h1>
                    </div>

                    <div class="divNomeFraseGrupo">    
                        <div class="divLblNomeGrupo">
                            <p><b>Nome do Grupo</b></p>
                        </div>

                        <div class="divTxtNomeGrupo">
                            <asp:TextBox ID="TxtNomeGrupo" runat="server" CssClass="txtNomeGrupo"></asp:TextBox>
                        </div>

                        <div class="divLblNomeGrupo">
                            <p><b>Frase do Grupo</b></p>
                        </div>

                        <div class="divTxtNomeGrupo">
                            <asp:TextBox ID="TxtFraseGrupo" runat="server" CssClass="txtNomeGrupo"></asp:TextBox>
                        </div>
                        <div class="divLblNomeGrupo">
                            <p><b runat="server" id="bGpLink">Link do grupo: </b></p>
                        </div>
                    </div>

                    <div class="divCorGrupo">
                        <div class="divLblNomeGrupo">
                            <p><b>Cor do Grupo</b></p>
                        </div>
                        <div class="divRadioCor2">
                            <asp:RadioButton ID="rdoBtn1" GroupName="RdoCores" runat="server" Text=" Azul Escuro" CssClass="rdoCor" Style="color:#0a0791" OnCheckedChanged="rdoBtn1_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn2" GroupName="RdoCores" runat="server" Text=" Verde Escuro" CssClass="rdoCor" Style="color:#00360b" OnCheckedChanged="rdoBtn2_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn3" GroupName="RdoCores" runat="server" Text=" Amarelo" CssClass="rdoCor" Style="color:#f0f005" OnCheckedChanged="rdoBtn3_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn4" GroupName="RdoCores" runat="server" Text=" Vermelho" CssClass="rdoCor" Style="color:#fa0000" OnCheckedChanged="rdoBtn4_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn5" GroupName="RdoCores" runat="server" Text=" Laranja" CssClass="rdoCor" Style="color:#ed7e00" OnCheckedChanged="rdoBtn5_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn6" GroupName="RdoCores" runat="server" Text=" Roxo" CssClass="rdoCor" Style="color:#5000b8" OnCheckedChanged="rdoBtn6_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn7" GroupName="RdoCores" runat="server" Text=" Preto" CssClass="rdoCor" Style="color:#222" OnCheckedChanged="rdoBtn7_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn8" GroupName="RdoCores" runat="server" Text=" Azul Claro" CssClass="rdoCor" Style="color:#45a2ff" OnCheckedChanged="rdoBtn8_CheckedChanged"/>
                        </div>
                        <div class="divRadioCor2">
                            <asp:RadioButton ID="rdoBtn9" GroupName="RdoCores" runat="server" Text=" Verde Claro" CssClass="rdoCor"  Style="color:#51ff45" OnCheckedChanged="rdoBtn9_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn10" GroupName="RdoCores" runat="server" Text=" Rosa" CssClass="rdoCor" Style="color:#ff69f5" OnCheckedChanged="rdoBtn10_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn11" GroupName="RdoCores" runat="server" Text=" Vinho" CssClass="rdoCor" Style="color:#53292a" OnCheckedChanged="rdoBtn11_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn12" GroupName="RdoCores" runat="server" Text=" Cinza" CssClass="rdoCor" Style="color:#757575" OnCheckedChanged="rdoBtn12_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn13" GroupName="RdoCores" runat="server" Text=" Marrom" CssClass="rdoCor" Style="color:#4b280a" OnCheckedChanged="rdoBtn13_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn14" GroupName="RdoCores" runat="server" Text=" Lilás" CssClass="rdoCor" Style="color:#b666d2" OnCheckedChanged="rdoBtn14_CheckedChanged"/>
                            <asp:RadioButton ID="rdoBtn15" GroupName="RdoCores" runat="server" Text=" Ciano" CssClass="rdoCor" Style="color:#1fffec" OnCheckedChanged="rdoBtn15_CheckedChanged"/>
                        </div>
                    </div> 
                    <div class="divBtnAdicionarParticipantes">
                        <asp:Button ID="BtnCriarGrupo" runat="server" Text="Criar Grupo" CssClass="btnAdicionarParticipantes" OnClick="BtnCriarGrupo_Click"/>
                        <asp:Button ID="BtnExcluirGrupo" runat="server" Text="Deletar Grupo" CssClass="btnExcluirGrupo" OnClick="BtnExcluirGrupo_Click"/>
                        <asp:Button ID="BtnGerenciarGrupo" CssClass="btnGerenciarGrupo" runat="server" Text="Gerenciar Participantes" OnClick="BtnGerenciarGrupo_Click"/>
                    </div>
                    <div class="divTitCrieGrupo" runat="server" id="divEntreGrupo">
                        <h1>Entre em um Grupo</h1>
                        <p>Clique nesse botão abaixo para entrar em um grupo existente.</p>
                    </div>
                    <div class="divBtnCriarGrupo" >  
                        <asp:TextBox ID="TxtLinkGrupo" runat="server"  Text="" CssClass="txtConvite"></asp:TextBox>
                        <asp:Button ID="BtnEntrarNoGrupo" runat="server" Text="Entrar no Grupo" CssClass="btnEntrarGrupo" OnClick="BtnEntratNoGrupo_Click"/>
                    </div>
                    </div>                    
            </div>
        </div>
    </div>
</asp:Content>