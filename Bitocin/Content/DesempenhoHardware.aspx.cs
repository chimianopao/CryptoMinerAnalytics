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
        }

        public void CarregaMenuHardwares()
        {
            string moeda = "Bitcoin";
            if (Request.Form["selectMoeda"] != null)
            {
                moeda = Request.Form["selectMoeda"];
            }

            string QueryString = "select marca, modelo from hardwares ORDER BY modelo;";

            MySqlConnection myConnection = new MySqlConnection(ConnectString);
            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
            myConnection.Open();
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "modelo");

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
    }
}