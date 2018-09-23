<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Moedas.aspx.cs" Inherits="Bitocin.Content.Moedas" EnableViewState="false" %>


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
            <div class="background-branco">
                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="sigla"
                            HeaderText="Sigla" />
                        <asp:BoundField DataField="nome"
                            HeaderText="Nome" />
                        <asp:BoundField DataField="algoritmo"
                            HeaderText="Algoritmo" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <h3>Cadastre uma nova Moeda:</h3>
            <div class="col-md-4">
                <input type="text" class="form-control inlineClass" id="sigla" name="sigla" placeholder="sigla" />
                <input type="text" class="form-control inlineClass" id="nome" name="nome" placeholder="nome" />
                <input type="text" class="form-control" id="algoritmo" name="algoritmo" placeholder="algoritmo" />
                <asp:Button ID="ButtonCadastro" Text="Cadastrar" OnClick="ButtonCadastro_Click" runat="server" />
            </div>
        </form>
    </div>
</body>
</html>
<script>
    function Gera() { GeraTabelaHardware('GPU'); }
</script>
