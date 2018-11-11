
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emissao.aspx.cs" Inherits="Bitocin.Content.Emissao" %>

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
                <li><a href="Emissao.aspx" data-toggle="tab"class="active">Emissão CO²</a>
                </li>
                <li><a href="Sobre.aspx" data-toggle="tab">Sobre</a>
                </li>
            </ul>
        </div>
        <br />
        <div> Durante o processo de produção de energia elétrica, algumas partículas de CO² são emitidas no meio ambiente. Apesar de ser de suma importância
            para a vida na terra, este composto causa danos diretamente à camada de ozônio. É possível calcular a quantidade de CO² emitida através da calculadora abaixo: </div>
        <br />
           <div class="dropdown">
   <%-- <button class="dropbtn"> Selecione Hardware --%>
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="#">CPU</a>
      <a href="#">GPU</a>
      <a href="#">ASIC</a>
    </div>
  </div>  



        <h3>Calculadora de Emissão de CO²</h3>
        <br />
        <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    Hardware: 
        <select id="selectHardware" multiple="false" name="selectHardware" runat="server"></select>
                    Quantidade:
                    <input type="number" id="quantidadeHw" name="quantidadeHw" value="1" class="col-md-1" runat="server" min="1" />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="ButtonCalcular" Text="Calcular Emissão" OnClick="ButtonCalcular_Click" runat="server" />
        </form>
        <br />
        <br />
        <h3>Resultado</h3>

        Hardware:
        <label id="labelHardware" runat="server"></label>
        <label id="labelQuantidade" runat="server"></label>
        <br />

        <br />
        Consumo energético total:
        <label id="labelTotalConsumo" runat="server"></label>
        Watts<br />
      
        Quantidade de CO² emitido:
        <label id="labelTotalEmissao" runat="server"></label>
        Kgs por hora<br />
        <label id="labelEmissaoDia" runat="server"></label>
        Kgs por dia<br />
        <label id="labelEmissaoMes" runat="server"></label>
        Kgs por mês<br />
        <%--colocar dia e mes--%>
        <br />

        <br />

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
<%--<script>
    function Recupera() { alert('<%= valor %>'); }
</script>--%>
