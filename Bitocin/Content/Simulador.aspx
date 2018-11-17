<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simulador.aspx.cs" Inherits="Bitocin.Content.Simulador" %>

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
                <li><a href="Simulador.aspx" data-toggle="tab" class="active">Simulador</a>
                </li>
                <li><a href="Moedas.aspx" data-toggle="tab">Moedas</a>
                </li>
                <li class="dropdown">
                    <button class="dropbtn">Hardwares</button>
                    <div class="dropdown-content">
                        <a href="Hardwares.aspx">Melhor hardware para Moeda</a>
                        <a href="DesempenhoHardware.aspx">Desempenho do Hardware</a>
                        <a href="CadastroHardwares.aspx">Cadastrar Hardware</a>
                    </div>
                </li>
                <li><a href="Cidades.aspx" data-toggle="tab">Cidades</a>
                </li>
                <li><a href="Emissao.aspx" data-toggle="tab">Emissão CO<sub>2</sub></a>
                </li>
                <li><a href="Sobre.aspx" data-toggle="tab">Sobre</a>
                </li>
            </ul>
        </div>

        <h2>Simulador</h2>
        <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    Moeda: 
        <asp:DropDownList ID="selectMoeda" runat="server" AutoPostBack="true" OnSelectedIndexChanged="moedaDropDown_Change" AppendDataBoundItems="true"></asp:DropDownList>

                    Hardware: 
        <select id="selectHardware" multiple="false" name="selectHardware" runat="server"></select>
                    Quantidade:
                    <input type="number" id="quantidadeHw" name="quantidadeHw" value="1" class="col-md-1" runat="server" min="1" />
                    <br />

                    Cidade: 
        <select id="selectCidade" multiple="false" name="selectCidade" runat="server"></select>
                    Consumo de outros components do hardware:
                    <input type="number" id="ConsumoOutros" name="ConsumoOutros" class="col-md-1" runat="server" pattern="[0-9]+([,\.][0-9]+)?" step="any" value="0" min="0" />
                    Watts    
        <br />

                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="ButtonCalcular" Text="Calcular Rentabilidade" OnClick="ButtonCalcular_Click" runat="server" />
        </form>
        <br />
        <br />
        <h2>Resultado</h2>
        Moeda:
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
        <br />
       <h5><b>Remuneração por hora:</b></h5>
        Estimativa de ganho na mineração:
        <label id="labelGanhoHora" runat="server" />
        <br />
        Gasto com energia: R$
        <label id="labelCustoHora" runat="server" />
        <br />
       <b>Estimativa de lucro: R$
        <label id="labelLucroHora" runat="server" /></b>
        <br />
        Emissão de CO<sub>2</sub>: 
        <label id="labelEmissaoHora" runat="server" /> Kgs
        <br />
        <br />

          <h5><b>Remuneração por dia:</b></h5>
        Estimativa de ganho na mineração:
        <label id="labelGanhoDia" runat="server" />
        <br />
        Gasto com energia: R$
        <label id="labelCustoDia" runat="server" />
        <br />
        <b>Estimativa de lucro: R$
        <label id="labelLucroDia" runat="server" /></b>
        <br />
        Emissão de CO<sub>2</sub>: 
        <label id="labelEmissaoDia" runat="server" /> Kgs
        <br />
        <br />

        <h5><b>Remuneração por mês:</b></h5>
        Estimativa de ganho na mineração:
        <label id="labelGanhoMes" runat="server" />
        <br />
        Gasto com energia: R$
        <label id="labelCustoMes" runat="server" />
        <br />
       <b> Estimativa de lucro: R$
        <label id="labelLucroMes" runat="server" /></b>
        <br />
        Emissão de CO<sub>2</sub>: 
        <label id="labelEmissaoMes" runat="server" /> Kgs
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
<script>
    <%--function Recupera() { alert('<%= valor %>'); }--%>
</script>
