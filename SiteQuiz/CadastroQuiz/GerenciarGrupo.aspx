<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="GerenciarGrupo.aspx.cs" Inherits="CadastroQuiz.GerenciarGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCorpo" runat="server">
    <div class="divCorpoGerenciarGrupo">
        <div class="divTituloAreaParticipante">
            <h1 class="h1AreaParticante">Área do Participante </h1>
            <p class="pBemVindo">Seja bem-vindo(a) <asp:label runat="server" ID="lblNomeBemVindo" Text=""></asp:label></p>
        </div>

        <div class="divImgSair">
            <a href="javascript:void()" class="aSair" runat="server">
                <img src="Imagens/imgSairLogin.svg" class="imgSair"/>
                <p class="pSair">Sair</p>
            </a>
        </div>
        <div class="divParticipantesGen">
            <div class="divPartGerenciar">
                <div class="divPartGen">
                    <div class="divTitGerencieGrupo">
                        <h1>Gerencie os Participantes </h1>
                    </div>

                    <div runat="server" id="i1">
                    <div class="divTitParticipantes">
                        <p class="pParticipantes"><b>Participante 1</b></p>
                    </div>

                    <div class="divParticipantes">
                        <div class="divParticipanteRM">
                            <asp:Label ID="Label1" runat="server" Text="RM" CssClass="lblRmParticipante"></asp:Label>
                            <asp:TextBox ID="TxtPartRM1" runat="server" CssClass="txtParticipanteRM" MaxLength="5"></asp:TextBox>
                        </div>

                        <div class="divParticipanteNome">
                            <asp:Label ID="Label2" runat="server" Text="Nome" CssClass="lblParticipanteNome"></asp:Label>
                            <asp:TextBox ID="TxtNome1" runat="server" CssClass="txtParticipanteNome" ReadOnly="true" Text=""></asp:TextBox>
                        </div>

                        <div class="divBtnExcluirParticipante">
                            <asp:Button ID="BtnExcluir1" runat="server" Text="Excluir" CssClass="btnExcluirParticipante" OnClick="BtnExcluir1_Click"/>
                        </div>                        
                    </div>

                    <div class="divAlertParticipante">
                        <asp:Label ID="Label14" runat="server" Text="" CssClass="lblAlertParticipante"></asp:Label>
                    </div>
                    </div>

                    <div runat="server" id="i2">
                    <div class="divTitParticipantes">
                        <p class="pParticipantes"><b>Participante 2</b></p>
                    </div>

                    <div class="divParticipantes">
                        <div class="divParticipanteRM">
                            <asp:Label ID="Label3" runat="server" Text="RM" CssClass="lblRmParticipante"></asp:Label>
                            <asp:TextBox ID="TxtPartRM2" runat="server" CssClass="txtParticipanteRM" MaxLength="5"></asp:TextBox>
                        </div>

                        <div class="divParticipanteNome">
                            <asp:Label ID="Label4" runat="server" Text="Nome" CssClass="lblParticipanteNome"></asp:Label>
                            <asp:TextBox ID="TxtNome2" runat="server" CssClass="txtParticipanteNome" ReadOnly="true" Text=""></asp:TextBox>
                        </div>

                        <div class="divBtnExcluirParticipante">
                            <asp:Button ID="BtnExcluir2" runat="server" Text="Excluir" CssClass="btnExcluirParticipante" OnClick="BtnExcluir2_Click"/>
                        </div>                                               
                    </div>

                    <div class="divAlertParticipante">
                        <asp:Label ID="Label15" runat="server" Text="" CssClass="lblAlertParticipante"></asp:Label>
                    </div>
                    </div>

                    <div runat="server" id="i3">
                    <div class="divTitParticipantes">
                        <p class="pParticipantes"><b>Participante 3</b></p>
                    </div>

                    <div class="divParticipantes">
                        <div class="divParticipanteRM">
                            <asp:Label ID="Label5" runat="server" Text="RM" CssClass="lblRmParticipante"></asp:Label>
                            <asp:TextBox ID="TxtPartRM3" runat="server" CssClass="txtParticipanteRM" MaxLength="5"></asp:TextBox>
                        </div>

                        <div class="divParticipanteNome">
                            <asp:Label ID="Label6" runat="server" Text="Nome" CssClass="lblParticipanteNome"></asp:Label>
                            <asp:TextBox ID="TxtNome3" runat="server" CssClass="txtParticipanteNome" ReadOnly="true" Text=""></asp:TextBox>
                        </div>

                        <div class="divBtnExcluirParticipante">
                            <asp:Button ID="BtnExcluir3" runat="server" Text="Excluir" CssClass="btnExcluirParticipante" OnClick="BtnExcluir3_Click"/>
                        </div>                                               
                    </div>
                    <div class="divAlertParticipante">
                        <asp:Label ID="Label11" runat="server" Text="" CssClass="lblAlertParticipante"></asp:Label>
                    </div> 
                    </div>

                    <div runat="server" id="i4">
                    <div class="divTitParticipantes">
                        <p class="pParticipantes"><b>Participante 4</b></p>
                    </div>

                    <div class="divParticipantes">
                        <div class="divParticipanteRM">
                            <asp:Label ID="Label7" runat="server" Text="RM" CssClass="lblRmParticipante"></asp:Label>
                            <asp:TextBox ID="TxtPartRM4" runat="server" CssClass="txtParticipanteRM" MaxLength="5"></asp:TextBox>
                        </div>

                        <div class="divParticipanteNome">
                            <asp:Label ID="Label8" runat="server" Text="Nome" CssClass="lblParticipanteNome"></asp:Label>
                            <asp:TextBox ID="TxtNome4" runat="server" CssClass="txtParticipanteNome" ReadOnly="true" Text=""></asp:TextBox>
                        </div>

                        <div class="divBtnExcluirParticipante">
                            <asp:Button ID="BtnExcluir4" runat="server" Text="Excluir" CssClass="btnExcluirParticipante" OnClick="BtnExcluir4_Click" />
                        </div>                         
                    </div>

                    <div class="divAlertParticipante">
                        <asp:Label ID="Label12" runat="server" Text="" CssClass="lblAlertParticipante"></asp:Label>
                    </div> 
                    </div>

                    <div runat="server" id="i5">
                    <div class="divTitParticipantes">
                        <p class="pParticipantes"><b>Participante 5</b></p>
                    </div>

                    <div class="divParticipantes">
                        <div class="divParticipanteRM">
                            <asp:Label ID="Label9" runat="server" Text="RM" CssClass="lblRmParticipante"></asp:Label>
                            <asp:TextBox ID="TxtPartRM5" runat="server" CssClass="txtParticipanteRM" MaxLength="5"></asp:TextBox>
                        </div>

                        <div class="divParticipanteNome">
                            <asp:Label ID="Label10" runat="server" Text="Nome" CssClass="lblParticipanteNome"></asp:Label>
                            <asp:TextBox ID="TxtNome5" runat="server" CssClass="txtParticipanteNome" ReadOnly="true" Text=""></asp:TextBox>
                        </div>

                        <div class="divBtnExcluirParticipante">
                            <asp:Button ID="BtnExcluir5" runat="server" Text="Excluir" CssClass="btnExcluirParticipante" OnClick="BtnExcluir5_Click" />
                        </div>                                                
                    </div>
                    <div class="divAlertParticipante">
                        <asp:Label ID="Label13" runat="server" Text="" CssClass="lblAlertParticipante"></asp:Label>
                    </div>
                    </div>
                    <div class="divBtnAdicionarParticipantes">
                        <asp:Button ID="BtnVoltarAreaParticipante" runat="server" Text="Voltar" CssClass="btnAdicionarParticipantes" OnClick="BtnVoltarAreaParticipante_Click"/>
                    </div>
                </div>             
            </div>
        </div>
    </div>
</asp:Content>
