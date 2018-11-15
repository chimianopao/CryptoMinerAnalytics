<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hardwares.aspx.cs" Inherits="Bitocin.Content.Hardwares" EnableViewState="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crypto Miner Analytics - Hardwares</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="CSS/Bootstrap.css" rel="stylesheet" />
    <link href="CSS/estilo.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="logotipo">
            <img src="images/logo.png" />
        </div>
        <div class="navigation-bar col-md-10">
            <ul>
                <li><a href="Index.aspx" data-toggle="tab">Simulador</a>
                </li>
                <li><a href="Moedas.aspx" data-toggle="tab">Moedas</a>
                </li>
                <li class="dropdown">
                    <button class="dropbtn">Hardwares</button>
                    <div class="dropdown-content">
                        <a href="Hardwares.aspx">Melhor hardware para Moeda</a>
                        <a href="Comparativo.aspx">Desempenho do Hardware</a>
                        <a href="CadastroHardwares.aspx">Cadastrar Hardware</a>
                    </div>
                </li>
                <li><a href="Energia.aspx" data-toggle="tab">Cidades</a>
                </li>
                <li><a href="Emissao.aspx" data-toggle="tab">Emissão CO<sub>2</sub></a>
                </li>
                <li><a href="Sobre.aspx" data-toggle="tab">Sobre</a>
                </li>
                </ul>
        </div>
        <br />
        <br />
        <h3>Melhor Hardware para cada Criptomoeda</h3><br />
        <form id="form1" runat="server">
            <div>
                <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                Selecione a Moeda
          <asp:DropDownList ID="selectMoeda" runat="server" AutoPostBack="false" AppendDataBoundItems="true"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="loadTableButton" Text="Recarregar Tabela" OnClick="loadTableButton_Click" runat="server" />
            </div>
            <br />
            <h3>Moeda: <%= valor %></h3>
            <div class="background-branco">
                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="tipo"
                            HeaderText="Tipo" />
                        <asp:BoundField DataField="marca"
                            HeaderText="Marca" />
                        <asp:BoundField DataField="modelo"
                            HeaderText="Modelo" /> 

                        <asp:TemplateField HeaderText="Processamento">
                            <ItemTemplate>
                                <asp:Label ID="lblProcessamento" runat="server" Text='<%# String.Format("{0} {1}", Eval("processamentoPorSegundo"), Eval("unidade")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Consumo">
                            <ItemTemplate>
                                <asp:Label ID="lblConsumo" runat="server" Text='<%# String.Format("{0} {1}", Eval("consumo"), "Watts") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Preço">
                            <ItemTemplate>
                                <asp:Label ID="lblPreco" runat="server" Text='<%# String.Format("{0} {1}", "R$ ", Eval("preco")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="ano"
                            HeaderText="Ano" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            
        
   
      <br /><br />  
        <div>
            <h2>Gráfico de poder de processamento</h2>
       <asp:Chart ID="ChartProcessamento" runat="server" Width="900px" Height="800">
            <Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
    </div>
  <br />
        <div>
            <h2>Gráfico de consumo energético</h2>
       <asp:Chart ID="ChartConsumo" runat="server" Width="900px" Height="800">
            <Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
        </asp:Chart>
    </div>
    </form>
                <footer>
            <br />
            <br />
            <hr noshade>
            <p style="color: #132235;"><b>Contato</b></p>
            <p>
                <a href="mailto:theilor.raddatz@edu.pucrs.br">theilor.raddatz@edu.pucrs.br</a><br />
                <a href="mailto:pedro.fraga@acad.pucrs.br">pedro.fraga@acad.pucrs.br</a><br />
                +55 (51) 3320-3525
            </p>
        </footer>
         </div>
</body>
</html>
<script>
   <%-- function Recupera() { alert('<%= valor %>'); }--%>
    function f1() {
        
          form1.submit();
      }
</script>
