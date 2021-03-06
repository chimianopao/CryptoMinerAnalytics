﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cidades.aspx.cs" Inherits="Bitocin.Content.Cidades" EnableViewState="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                <li><a href="Cidades.aspx" data-toggle="tab" class="active">Cidades</a>
                </li>
                <li><a href="Emissao.aspx" data-toggle="tab">Emissão CO<sub>2</sub></a>
                </li>
                <li><a href="Sobre.aspx" data-toggle="tab">Sobre</a>
                </li>
                </ul>
        </div>
        <br />
        <br />
        <h3>Preço da energia elétrica por cidade</h3><br />
        <form id="form1" runat="server">
            <div>
            </div>
            <div class="background-branco">
                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed table-sm dataTable sorting" AllowSorting="false" onsorting="GridView2_Sorting" AutoGenerateColumns="false">
                    <Columns> 
                        <asp:BoundField DataField="pais"
                            HeaderText="País" sortexpression="pais"/>
                        <asp:BoundField DataField="cidade"
                            HeaderText="Cidade" sortexpression="cidade"/>
                        <asp:BoundField DataField="estado"
                            HeaderText="Estado"  SortExpression="Estado"/>
                        <asp:BoundField DataField="concessionaria"
                            HeaderText="Concessionária" sortexpression="concessionaria"/> 

                         <asp:TemplateField HeaderText="Custo por KW/h">
                            <ItemTemplate>
                                <asp:Label ID="lblCustoKWh" runat="server" Text='<%# String.Format("{0} {1}", "R$ ", Eval("custoKWh")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="emissaoCO2porWh"
                            HeaderText="CO2/Wh" sortexpression="emissaoCO2porWh"/>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            
            <br />
    <div>
        <h2>Gráfico de custo energético das cidades</h2>
       <asp:Chart ID="Chart2" runat="server" Width="900px" Height="900">
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
    function f1() {
        
          form1.submit();
    }
</script>
