<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Bitocin.Content.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crypto Miner Analytics - Home</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link href="CSS/Bootstrap.css" rel="stylesheet" />
    <link href="CSS/estilo.css" rel="stylesheet"/>
</head>
<body>
    <div class="container">
    <div class="logotipo">
        <img src="images/logo.png"/>
    </div>
    <div class="navigation-bar col-md-12">
        <ul>
            <li><a href="Index.aspx" data-toggle="tab">Home</a>
            </li>
            <li><a href="Comparativo.aspx" data-toggle="tab">Comparativo</a>
            </li>
            <li><a href="Moedas.aspx" data-toggle="tab">Moedas</a>
            </li>
            <li><a href="Hardwares.aspx" data-toggle="tab">Hardwares</a>
            </li>
            <li><a href="Energia.aspx" data-toggle="tab">Energia</a>
            </li>
            <li><a href="Faq.aspx" data-toggle="tab">FAQ</a>
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
        
        <h2>Simulador</h2>
        <form runat="server">
      Moeda: 
      <select id="selectMoeda" multiple="false" name="selectMoeda" runat="server"></select> <br />

      Hardware: 
        <select id="selectHardware" multiple="false" name="selectHardware" runat="server"></select>
        Quantidade: <input type="number" id="quantidadeHw" name="quantidadeHw" value="1" class="col-md-1" runat="server" min="1"/>
        <br />
     
        Cidade: 
        <select id="selectCidade" multiple="false" name="selectCidade" runat="server"></select><br />

        <asp:Button ID="ButtonCalcular" Text="Calcular Rentabilidade" OnClick="ButtonCalcular_Click" runat="server" />

        </form>

        <br />
        <br />
        <h2>Resultado</h2>
        Moeda: <label id="labelMoeda" runat="server"></label><br />
        Algoritmo: <label id="labelAlgoritmo" runat="server"></label><br />
        Cotação do dia: R$ <label id="labelCotacao" runat="server"></label><br />
        Hardware: <label id="labelHardware" runat="server"></label>
        <label id="labelQuantidade" runat="server"></label> <br />
        Cidade: <label id="labelCidade" name="labelCidade" runat="server"></label><br />
        Custo de energia: R$ <label id="labelCusto" runat="server"></label><br />
        Poder total de processamento: <label id="labelTotalProcessamento" runat="server"></label>  
        <label id="labelUnidade" runat="server"></label><br />
        Consumo energético total: <label id="labelTotalConsumo" runat="server"></label> Watts<br />
</div>
</body>
</html>
<script>
    function Recupera() { alert('<%= valor %>'); }
</script>
