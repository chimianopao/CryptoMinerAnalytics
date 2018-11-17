using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using static Bitocin.Content.API.CoinWarzAPI;

namespace Bitocin.Content {
    public partial class DesempenhoHardware : System.Web.UI.Page {
        string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
        public string hardwareSelecionado = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaMenuHardwares();
            //   Button1.Click(sender, e);
        }

        //   MySqlConnection SQL_koneksi = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PWD=;");
        //   String nama_tabel = "twitter_clone.usuarios";
        //   MySqlDataAdapter db_select;
        //  DataSet db_data;
        //   MySqlCommand SQL_cmd;
        //   string Query;



        public void CarregaMenuHardwares()
        {
            string moeda = "Bitcoin";
            if (Request.Form["selectMoeda"] != null)
            {
                moeda = Request.Form["selectMoeda"];
            }
            //    string moeda = Request.Form["selectMoeda"];

            string QueryString = "select marca, modelo from hardwares ORDER BY modelo;";

            MySqlConnection myConnection = new MySqlConnection(ConnectString);
            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
            myConnection.Open();
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "modelo");

            //ver depois como colocar marca e hardware. rodar while pra encher lista com os 2, aí preenche com essa lista

            selectHardware.DataSource = ds;
            selectHardware.DataTextField = "modelo";
            selectHardware.DataValueField = "modelo";
            selectHardware.DataBind();

            myConnection.Close();
        }


        public void ButtonCalcular_Click(Object sender, EventArgs e)
        {
            GeraTabelaHardware();
        }



        public void GeraTabelaHardware()
        {
            string hardware = Request.Form["selectHardware"];
            hardwareSelecionado = "Hardware selecionado: " + Request.Form["selectHardware"];
            MySqlConnection SQL_conection = new MySqlConnection(ConnectString);
            String name_tabel = "hardwares";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT cm.nome, pr.processamentoPorSegundo, pr.unidade FROM hardwares hw " +
                    "JOIN processamento pr ON hw.idHardware = pr.idHardware " +
                    "JOIN criptomoedas cm ON cm.idCriptomoeda = pr.idCriptomoeda " +
                    $"WHERE hw.modelo = '{hardware}'", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridProcessamento.DataSource = db_data;
                GridProcessamento.DataBind();
                SQL_conection.Close();
                
            }
            catch (Exception e)
            {
                
            }
        }



        //public void CalculaConsumo(double consumoTotal, int quantidade, double custoKWh, double poderProcessamento)
        //{
        //    double consumoOutros = double.Parse(ConsumoOutros.Value);
        //    consumoTotal = (consumoTotal * quantidade) + consumoOutros;

        //    consumoTotal = consumoTotal / 1000;  //kWh
        //  //  consumoTotal = consumoTotal * 24; //final kWh

        //    var moeda = GetCotacao();

        //    //  decimal resultado = ( ((decimal)poderProcessamento/51041010300000) * moeda.BlockReward * moeda.BlockTimeInSeconds * moeda.ExchangeRate) - ((decimal)custoKWh * (decimal)consumoTotal);
        //    // decimal resultado = (((decimal)poderProcessamento * moeda.BlockReward) / moeda.Difficulty) * 3600;

        //    //decimal resultado = (decimal)(poderProcessamento * 3600) / ((decimal)Math.Pow(2,32) * moeda.Difficulty);
        //    //resultado = resultado * moeda.BlockReward;
        //    //resultado = resultado * 24449;

        //    //decimal resultado = (((decimal)poderProcessamento*1000000) * (decimal)moeda.BlockReward * 3600) / ((decimal)Math.Pow(2, 32) * moeda.Difficulty);
        //    //resultado = resultado * 24449;
        //    decimal resultado = 0;
        //    if (Request.Form["selectMoeda"].Equals("Zcash") || Request.Form["selectMoeda"].Equals("Ethereum"))
        //    {
        //        resultado = ((decimal)poderProcessamento * 1000000) / 19006000000000 * (3600 / moeda.BlockTimeInSeconds * moeda.BlockReward) * moeda.ExchangeRate;
        //        resultado = resultado * 573;
        //    }
        //    else
        //    {
        //        resultado = (((decimal)poderProcessamento * 1000000) * (decimal)moeda.BlockReward * 3600) / ((decimal)Math.Pow(2, 32) * moeda.Difficulty);
        //        resultado = resultado * 24449;
        //    }

        //    labelCustoDia.InnerText = (consumoTotal * custoKWh).ToString("0.00");
        //    labelGanhoDia.InnerText = resultado.ToString("0.00");
        //    labelLucroDia.InnerText = (resultado-(decimal)(custoKWh*consumoTotal)).ToString("0.00");

        //}

    }
}