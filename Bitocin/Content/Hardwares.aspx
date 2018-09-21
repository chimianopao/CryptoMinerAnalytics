<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hardwares.aspx.cs" Inherits="Bitocin.Content.Hardwares" %>

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
        <div class="navigation-bar col-md-12">
            <ul>
                <li><a href="index.aspx" data-toggle="tab">Home</a>
                </li>
                <li><a href="#profile-pills" data-toggle="tab">Comparativo</a>
                </li>
                <li><a href="#messages-pills" data-toggle="tab">Moedas</a>
                </li>
                <li class="active"><a href="hardwares.aspx" data-toggle="tab">Hardwares</a>
                </li>
                <li><a href="#settings-pills" data-toggle="tab">Energia</a>
                </li>
                <li><a href="#settings-pills" data-toggle="tab">FAQ</a>
                </li>
                <li><a href="#settings-pills" data-toggle="tab">Sobre</a>
                </li>
            </ul>
        </div>
        <form id="form1" runat="server">
            <div>
                Selecione o Hardware:
      <select id="selectHardware" name="selectHardware" runat="server">
          <option value="CPU">CPU</option>
          <option value="GPU">GPU</option>
          <option value="ASIC">ASIC</option>
      </select>
                Selecione a Moeda
      <select>
          <option>Bitcoin</option>
          <option>Monero</option>
          <option>Ethereum</option>
      </select>
                <asp:Button ID="loadTableButton" Text="Recarregar Tabela" OnClick="loadTableButton_Click" runat="server" />
                ESTOU ALTERANDO ISSO AQUI!!!!!!!!!!!!!!
            </div>

            <div class="background-branco">
                <input type="button" value="Total" onclick="Recupera();" />

                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="marca"
                            HeaderText="Marca" />
                        <asp:BoundField DataField="modelo"
                            HeaderText="Modelo" />
                        <asp:BoundField DataField="consumo"
                            HeaderText="Consumo" />
                        <asp:BoundField DataField="preco"
                            HeaderText="Preço" />
                        <asp:BoundField DataField="ano"
                            HeaderText="Ano" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
<script>
    function Recupera() { alert('<%= valor %>'); }
    function Gera() { GeraTabelaHardware('GPU'); }
</script>
