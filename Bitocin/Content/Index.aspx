<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Bitocin.Content.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Crypto Miner Analytics - Home</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="CSS/Bootstrap.css" rel="stylesheet" />
    <link href="CSS/estilo.css" rel="stylesheet">
</head>
<body>
    <div class="container">
    <div class="logotipo">
        <img src="images/logo.png">
    </div>
</img>
    <div class="navigation-bar col-md-12">
        <ul>
            <li><a href="index.aspx" data-toggle="tab">Home</a>
            </li>
            <li><a href="#profile-pills" data-toggle="tab">Comparativo</a>
            </li>
            <li><a href="#messages-pills" data-toggle="tab">Moedas</a>
            </li>
            <li><a href="hardwares.aspx" data-toggle="tab">Hardwares</a>
            </li>
            <li><a href="#settings-pills" data-toggle="tab">Energia</a>
            </li>
            <li><a href="#settings-pills" data-toggle="tab">FAQ</a>
            </li>
            <li><a href="#settings-pills" data-toggle="tab">Sobre</a>
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

  <div>Selecione o Hardware:
      <select>
          <option>CPU</option>
          <option>GPU</option>
          <option>ASIC</option>
      </select>
      Selecione a Moeda
      <select>
          <option>Bitcoin</option>
          <option>Monero</option>
          <option>Ethereum</option>
      </select>
  </div>

  
</div>
        tabela
  
    <form id="form1" runat="server">
        <div>
            <input type="button" value="Total" onclick="Recupera();" />

             <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            
        </div>
        
    </form>
    <div>
            
        </div>
</body>
</html>
<script>
    function Recupera() { alert('<%= valor %>'); }
</script>
