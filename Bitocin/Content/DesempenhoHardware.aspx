<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesempenhoHardware.aspx.cs" Inherits="Bitocin.Content.DesempenhoHardware" %>

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
                <li><a href="Simulador.aspx" data-toggle="tab">Simulador</a>
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
        <br />
        <h2>Desempenho do Hardware em cada Criptomoeda</h2>
        <br />
        <form runat="server">
                    Hardware: 
        <select id="selectHardware" multiple="false" name="selectHardware" runat="server"></select>
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

        <footer>
            <br />
            <br />
            <hr noshade>
            <p style="color: #132235;"><b>Contato</b></p>
            <p>
                <a href="mailto:theilor.raddatz@edu.pucrs.br">theilor.raddatz@edu.pucrs.br<br />
                <a href="mailto:pedro.fraga@acad.pucrs.br">pedro.fraga@acad.pucrs.br</a><br />
                +55 (51) 3320-3525
            </p>
        </footer>
    </div>

</body>
</html>
<script>

</script>
