<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Energia.aspx.cs" Inherits="Bitocin.Content.Energia" EnableViewState="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crypto Miner Analytics - Energia</title>
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
            </div>
            <div class="background-branco">
                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="cidade"
                            HeaderText="Cidade" />
                        <asp:BoundField DataField="estado"
                            HeaderText="Estado" />
                        <asp:BoundField DataField="concessionaria"
                            HeaderText="Concessionária" /> 
                        <asp:BoundField DataField="custoKWh"
                            HeaderText="Custo por KW/h" />
                        <asp:BoundField DataField="emissaoCO2porWh"
                            HeaderText="CO2/Wh" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <h3>Cadastre uma nova cidade:</h3>
            <div class="col-md-6">
                <input type="text" class="form-control col-md-7" id="cidade" name="cidade" placeholder="Cidade" />
                <input type="text" class="form-control col-md-7" id="estado" name="estado" placeholder="UF" />
                <input type="text" class="form-control col-md-7" id="concessionaria" name="concessionaria" placeholder="Concessionária" /> 
                <input type="number" class="form-control col-md-7 inlineClass" id="custo" name="custo" placeholder="Custo por KW/h" pattern="[0-9]+([,\.][0-9]+)?" min="0" step="any" /> Reais<br />
                <input type="number" class="form-control col-md-7 inlineClass" id="co2" name="co2" pattern="[0-9]+([,\.][0-9]+)?" min="0" step="any" placeholder="CO2/Wh" /><br />
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
