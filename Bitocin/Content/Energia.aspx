<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Energia.aspx.cs" Inherits="Bitocin.Content.Energia" EnableViewState="false" %>

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
                <%--AllowSorting="True" onsorting="GridView2_Sorting"--%>
                <asp:GridView ID="GridView2" runat="server" class="table table-striped table-bordered table-hover table-condensed table-sm dataTable sorting" AllowSorting="True" onsorting="GridView2_Sorting" AutoGenerateColumns="false">
                    <Columns> 
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

<%--    <div class="col-lg-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Bar Chart Example
                        </div>
                        <!-- /.panel-heading -->
                        
                        <div class="panel-body">
                            <div class="flot-chart">
                                <div class="flot-chart-content" id="flot-bar-chart" style="padding: 0px; position: relative;">
                                    <canvas class="flot-base" width="727" height="400" style="direction: ltr; position: absolute; left: 0px; top: 0px; width: 727px; height: 400px;"></canvas>
                                    <div class="flot-text" style="position: absolute; top: 0px; left: 0px; bottom: 0px; right: 0px; font-size: smaller; color: rgb(84, 84, 84);">
                                        <div class="flot-x-axis flot-x1-axis xAxis x1Axis" style="position: absolute; top: 0px; left: 0px; bottom: 0px; right: 0px;">
                                            <div class="flot-tick-label tickLabel" style="position: absolute; max-width: 90px; top: 382px; left: 108px; text-align: center;">12/05</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; max-width: 90px; top: 382px; left: 215px; text-align: center;">12/07</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; max-width: 90px; top: 382px; left: 322px; text-align: center;">12/09</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; max-width: 90px; top: 382px; left: 430px; text-align: center;">12/11</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; max-width: 90px; top: 382px; left: 537px; text-align: center;">12/13</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; max-width: 90px; top: 382px; left: 644px; text-align: center;">12/15</div>

                                        </div><div class="flot-y-axis flot-y1-axis yAxis y1Axis" style="position: absolute; top: 0px; left: 0px; bottom: 0px; right: 0px;">
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 369px; left: 21px; text-align: right;">0</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 316px; left: 2px; text-align: right;">1000</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 264px; left: 2px; text-align: right;">2000</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 211px; left: 2px; text-align: right;">3000</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 158px; left: 2px; text-align: right;">4000</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 105px; left: 2px; text-align: right;">5000</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 53px; left: 2px; text-align: right;">6000</div>
                                            <div class="flot-tick-label tickLabel" style="position: absolute; top: 0px; left: 2px; text-align: right;">7000</div>
                                              </div></div><canvas class="flot-overlay" width="727" height="400" style="direction: ltr; position: absolute; left: 0px; top: 0px; width: 727px; height: 400px;"></canvas>

                                </div>
                            </div>
                        </div><!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>--%>

<%--    <div>

        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1"  ChartType="Bar" XValueMember="custoKWh" YValueMembers="cidade"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

    </div>--%>
   <%-- <div>
<asp:Chart ID="ColumnChart" runat="server" BackColor="WhiteSmoke" BackGradientStyle="TopBottom"
    BackSecondaryColor="White" BorderColor="26, 59, 105" BorderlineDashStyle="Solid"
    BorderWidth="2" Height="350px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
    Palette="BrightPastel" Width="900px">
    <Legends>
        <asp:Legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1"
            Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent"
            Alignment="Center">
        </asp:Legend>
    </Legends>
    <BorderSkin SkinStyle="Emboss" />
    <Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series1">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series2">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series3">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series4">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series5">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series6">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series7">
        </asp:Series>
        <asp:Series BorderColor="180, 26, 59, 105" Name="Series8">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea BackColor="Gainsboro" BackGradientStyle="TopBottom" BackSecondaryColor="White"
            BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="Transparent">
            <AxisY2 Interval="25" IsLabelAutoFit="False">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid Enabled="False" />
            </AxisY2>
            <AxisX2 Interval="25" IsLabelAutoFit="False">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid Enabled="False" />
            </AxisX2>
            <Area3DStyle Inclination="15" IsClustered="False" IsRightAngleAxes="False" LightStyle="Realistic"
                Rotation="10" WallWidth="0" />
            <AxisY LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid LineColor="64, 64, 64, 64" />
            </AxisY>
            <AxisX LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid LineColor="64, 64, 64, 64" />
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>  
        </div>--%>
</body>
</html>
<script>
   <%-- function Recupera() { alert('<%= valor %>'); }--%>
    function f1() {
        
          form1.submit();
    }
</script>
