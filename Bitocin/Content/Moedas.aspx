<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Moedas.aspx.cs" Inherits="Bitocin.Content.Moedas" EnableViewState="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crypto Miner Analytics - Moedas</title>
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
        <div class="navigation-bar col-md-12">
            <ul>
                <li><a href="Index.aspx" data-toggle="tab">Simulador</a>
                </li>
                <li><a href="Comparativo.aspx" data-toggle="tab">Comparativo</a>
                </li>
                <li><a href="Moedas.aspx" data-toggle="tab" class="active">Moedas</a>
                </li>
                <li><a href="Hardwares.aspx" data-toggle="tab">Hardwares</a>
                </li>
                <li><a href="Energia.aspx" data-toggle="tab">Energia</a>
                </li>
                <li><a href="Emissao.aspx" data-toggle="tab">Emissão CO²</a>
                </li>
                <li><a href="Sobre.aspx" data-toggle="tab">Sobre</a>
                </li>
                </ul>
        </div>
        <br />
        <br />
        <form id="form1" runat="server">
            <asp:Button ID="ButtonCotacao" Text="Obter Cotação" OnClick="ButtonCotacao_Click" runat="server" />
            
            <div class="background-branco">
                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="sigla"
                            HeaderText="Sigla" />
                        <asp:BoundField DataField="nome"
                            HeaderText="Nome" />
                        <asp:BoundField DataField="algoritmo"
                            HeaderText="Algoritmo" />

                         <asp:TemplateField HeaderText="Cotação">
                            <ItemTemplate>
                                <asp:Label ID="lblCotacao" runat="server" Text='<%# String.Format("{0} {1}", "R$ ", Eval("cotacao")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="dataCotacao"
                            HeaderText="Data" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
        <br />
        <br />
          <div>
           <h2>Gráfico de cotação das Moedas</h2>   
       <asp:Chart ID="ChartCotacao" runat="server" Width="900px" Height="900">
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

                  <h2>Gráfico de histórico de cotações</h2>   
       <asp:Chart ID="ChartHistorico" runat="server" Width="1300px" Height="500" AlternateText="olaaaaaa">
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
                <footer>
            <br />
            <br />
            <hr noshade>
            <p style="color: #132235;"><b>Contato</b></p>
            <p>
                <a href="mailto:theilor@gmail.com">theilor@gmail.com</a><br />
                <a href="mailto:pedro.fraga@acad.pucrs.br">pedro.fraga@acad.pucrs.br</a><br />
                +55 (51) 3320-3525
            </p>
        </footer>
    </div>
</body>
</html>
<script>
    function Gera() { GeraTabelaHardware('GPU'); }
</script>
