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
using static Bitocin.Content.API.BraziliexAPI;

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
            String name_table = "criptomoedas";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT distinct cm.sigla as sigla, cm.nome, cm.algoritmo, hc.cotacao, hc.dataCotacao from criptomoedas cm JOIN historicocotacao hc on cm.idCriptomoeda = hc.idCriptomoeda order BY hc.dataCotacao desc;", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_table);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
            }
            catch
            {
                valor = "deu pau";
            }
        }

        //public void ButtonCadastro_Click(Object sender, EventArgs e)
        //{
        //    MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
        //    String name_table = "criptomoedas";

        //    string sigla = Request.Form["sigla"];
        //    string nome = Request.Form["nome"];
        //    string algoritmo = Request.Form["algoritmo"];
        //    string cotacao = Request.Form["cotacao"];

        //    try
        //    {
        //        #region Insere moeda
        //        SQL_conection.Open();
        //        MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_table} (sigla,nome,algoritmo) VALUES ('{sigla}','{nome}','{algoritmo}');", SQL_conection);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        SQL_conection.Close();
        //        #endregion

        //        #region Pega idCriptomoeda da nova moeda
        //        int idCriptomoeda;
        //        string temp = "";
        //        var dataCotacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //        cmd = new MySqlCommand($"SELECT idCriptomoeda from criptomoedas WHERE nome = '{nome}';", SQL_conection);
        //        SQL_conection.Open();
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            temp = reader.GetString("idCriptomoeda");
        //        }
        //        SQL_conection.Close();
        //        idCriptomoeda = int.Parse(temp);
        //        #endregion

        //        #region Insere cotação
        //        SQL_conection.Open();
        //        cmd = new MySqlCommand($"INSERT INTO historicocotacao (idCriptomoeda,cotacao,dataCotacao) VALUES ({idCriptomoeda}, '{cotacao}', '{dataCotacao}');", SQL_conection);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        #endregion

        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Moeda cadastrada com sucesso');", true);
        //        GeraTabelaMoedas();
        //    }
        //    catch
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Erro ao cadastrar. Por favor, preencha todos os campos.');", true);
        //    }
        //}



        public void ButtonCotacao_Click(Object sender, EventArgs e)
        {

           // try
          //  {
                GetCotacao("BTC", 1);
                GetCotacao("ETH", 2);
                GetCotacao("LTC", 3);
                GetCotacao("XMR", 4);
                GetCotacao("DASH", 5);
                GetCotacao("ZEC", 6);
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Cotações obtidas com sucesso.');", true);
            GeraTabelaMoedas();
         //   }
         //   catch (Exception)
          //  {
          //      Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Não foi possível obter as cotações.');", true);
          //  }
            

        }


        public void GetCotacao(string sigla, int idmoeda)
        {
            Rootobject cotacao = _download_serialized_json_data<Rootobject>($"https://braziliex.com/api/v1/public/ticker");
            var dataCotacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Decimal novo = 0;
            switch (idmoeda)
            {
                case 1:
                    novo = Decimal.Round(cotacao.btc_brl.last, 2);
                    break;
                case 2:
                    novo = Decimal.Round(cotacao.eth_brl.last, 2);
                    break;
                case 3:
                    novo = Decimal.Round(cotacao.ltc_brl.last, 2);
                    break;
                case 4:
                    novo = Decimal.Round(cotacao.xmr_brl.last, 2);
                    break;
                case 5:
                    novo = Decimal.Round(cotacao.dash_brl.last, 2);
                    break;
                case 6:
                    novo = Decimal.Round(cotacao.zec_brl.last, 2);
                    break;
            }

            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_table = "historicocotacao";


            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_table} (idCriptomoeda,cotacao,dataCotacao) VALUES ({idmoeda}, '{novo}', '{dataCotacao}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Não foi possível obter a cotação.');", true);
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

        private string epoch2string(int epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToString("yyyy-MM-dd"); //.ToShortDateString();
        }

    }
}





