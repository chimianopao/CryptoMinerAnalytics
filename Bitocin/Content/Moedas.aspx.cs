using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net;
using Newtonsoft.Json;

namespace Bitocin.Content {
    public partial class Moedas : System.Web.UI.Page {
        public string valor;
        protected void Page_Load(object sender, EventArgs e)
        {

            GeraTabelaMoedas();
        }


        public void GeraTabelaMoedas()
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "criptomoedas";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT * FROM " + name_tabel, SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
            }
            catch
            {
                valor = "deu pau";
            }
        }

        public void ButtonCadastro_Click(Object sender, EventArgs e)
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "criptomoedas";

            string sigla = Request.Form["sigla"];
            string nome = Request.Form["nome"];
            string algoritmo = Request.Form["algoritmo"];

            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_tabel} (sigla,nome,algoritmo) VALUES ('{sigla}','{nome}','{algoritmo}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //  Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Moeda cadastrada com sucesso');", true);
                //   GeraTabelaMoedas();
                Rootobject vava = _download_serialized_json_data<Rootobject>("https://www.mercadobitcoin.net/api/BTC/ticker/");
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('" + vava.ticker.high + "');", true);
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Erro ao cadastrar. Por favor, preencha todos os campos.');", true);
            }
        }

        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public class Rootobject {
            public Ticker ticker { get; set; }
        }

        public class Ticker {
            public Decimal high { get; set; }
            public Decimal low { get; set; }
            public Decimal vol { get; set; }
            public Decimal last { get; set; }
            public Decimal buy { get; set; }
            public Decimal sell { get; set; }
            public int date { get; set; }
        }

    }
}





