<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comparativo.aspx.cs" Inherits="Bitocin.Content.Comparativo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crypto Miner Analytics - Home</title>
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
                <li><a href="Comparativo.aspx" data-toggle="tab" class="active">Comparativo</a>
                </li>
                <li><a href="Moedas.aspx" data-toggle="tab">Moedas</a>
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
        <!--   <div class="dropdown">
    <button class="dropbtn">Selecione Hardware 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="#">CPU</a>
      <a href="#">GPU</a>
      <a href="#">ASIC</a>
    </div>
  </div>  -->

        <h2>Comparativo</h2>
        <form runat="server">
                    Hardware: 
        <select id="selectHardware" multiple="false" name="selectHardware" runat="server"></select>
                    Quantidade:
                    <input type="number" id="quantidadeHw" name="quantidadeHw" value="1" class="col-md-2" size="10" style="height: 100%" runat="server" min="1" />
                    <br />
            <asp:Button ID="ButtonCalcular" Text="Calcular Desempenho" OnClick="ButtonCalcular_Click" runat="server" />
        
        <br />
        <br />
        <h2>Resultado</h2>
            <br />
            <%= hardwareSelecionado %>
         <asp:GridView ID="GridProcessamento" runat="server" class="table table-striped table-bordered table-hover table-condensed col-md-4" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="nome"
                            HeaderText="Moeda" />
                        <asp:BoundField DataField="processamentoPorSegundo"
                            HeaderText="Processamento" />
                        <asp:BoundField DataField="unidade"
                            HeaderText="Unidade" /> 
                    </Columns>
                </asp:GridView>
        </form>


      <%--  Moeda:
        <label id="labelMoeda" runat="server"></label>
        <br />
        Algoritmo:
        <label id="labelAlgoritmo" runat="server"></label>
        <br />
        Cotação do dia: R$
        <label id="labelCotacao" runat="server"></label>
        <br />
        Hardware:
        <label id="labelHardware" runat="server"></label>
        <label id="labelQuantidade" runat="server"></label>
        <br />
        Cidade:
        <label id="labelCidade" name="labelCidade" runat="server"></label>
        <br />
        Custo de energia: R$
        <label id="labelCusto" runat="server"></label>
        <br />
        Poder total de processamento:
        <label id="labelTotalProcessamento" runat="server"></label>
        <label id="labelUnidade" runat="server"></label>
        <br />
        Consumo energético total:
        <label id="labelTotalConsumo" runat="server"></label>
        Watts<br />
        <br />
        <br />

        Custo aquisitivo do hardware: R$
        <label id="labelCustoAquisitivo" runat="server" />
        <br />

        Remuneração por hora:<br />
        Estimativa de ganho na mineração:
        <label id="labelGanhoDia" runat="server" />
        <br />
        Gasto com energia: R$
        <label id="labelCustoDia" runat="server" />
        <br />
        Estimativa de lucro: R$
        <label id="labelLucroDia" runat="server" />
        <br />
        <br />--%>

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

</script>
