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
        <br />
        <br />
        <form id="form1" runat="server">
            <div>
<%--                Selecione o Hardware:
      <select id="selectHardware" name="selectHardware" runat="server">
          <option value="ASIC">ASIC</option>
          <option value="CPU">CPU</option>
          <option value="GPU">GPU</option>
      </select>--%>
                Selecione a Moeda
      <select id="selectMoeda" name="selectMoeda" runat="server">
          <%--<option>Bitcoin</option>
          <option>Monero</option>
          <option>Ethereum</option>
          <option>Zcash</option>--%>
      </select>
                <asp:Button ID="loadTableButton" Text="Recarregar Tabela" OnClick="loadTableButton_Click" runat="server" />
            </div>
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
            <h3>Cadastre um novo hardware:</h3>
            <div class="col-md-6">
                <input type="text" class="form-control col-md-7" id="marca" name="marca" placeholder="Marca" />
                <input type="text" class="form-control col-md-7" id="modelo" name="modelo" placeholder="Modelo" />
                Tipo: 
                <select id="selectTypeCreation" name="selectTypeCreation" runat="server">
                    <option value="CPU">CPU</option>
                    <option value="GPU">GPU</option>
                    <option value="ASIC">ASIC</option>
                </select><br />
                <input type="number" class="form-control col-md-7 inlineClass" id="consumo" name="consumo" placeholder="Consumo" /> Watts<br />
                <input type="number" class="form-control col-md-7 inlineClass" id="preco" name="preco" placeholder="Preço" pattern="[0-9]+([,\.][0-9]+)?" min="0" step="any" /> Reais<br />
                <input type="number" class="form-control col-md-7 inlineClass" id="ano" name="ano" placeholder="Ano" /><br />
                Moeda:
                <select id="selectMoedaCadastro" name="selectMoedaCadastro" runat="server" onclick="MoedaCadastroChange" onselect="MoedaCadastroChange" onchange="MoedaCadastroChange"/><br />
                <input type="number" class="form-control col-md-7 inlineClass" id="processamento" name="processamento" placeholder="Processamento" pattern="[0-9]+([,\.][0-9]+)?" min="0" step="any" />
                <label id="labelUnidade" name="labelUnidade" class="inlineClass" runat="server">MH/s</label><br />
                <asp:Button ID="ButtonCadastro" Text="Cadastrar" OnClick="ButtonCadastro_Click" runat="server" />
            </div>
        </form>
    </div>

</body>
</html>
<script>
   <%-- function Recupera() { alert('<%= valor %>'); }--%>
    function f1() {
        
          form1.submit();
      }
</script>
