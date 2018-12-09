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
using System.Web.UI.DataVisualization.Charting;
using Bitocin.Content.API;

namespace Bitocin.Content {
    public partial class Moedas : System.Web.UI.Page {
        public string valor;
        protected void Page_Load(object sender, EventArgs e)
        {
            GeraTabelaMoedas();
            GetHistorico(20);
        }


        public void GeraTabelaMoedas()
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_table = "criptomoedas";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT distinct cm.sigla as sigla, cm.nome, cm.algoritmo, hc.cotacao, hc.dataCotacao from criptomoedas cm JOIN historicocotacao hc on cm.idCriptomoeda = hc.idCriptomoeda order BY hc.dataCotacao desc LIMIT 5;", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_table);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
            }
            catch
            {
                valor = "Erro";
            }

            GeraGraficoConsumo();
        }


        public void ButtonCotacao_Click(Object sender, EventArgs e)
        {
            GetCotacaoCrypto();
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Cotações obtidas com sucesso.');", true);
            GeraTabelaMoedas();
        }

        public static void AtualizaCotacaoMoedas()
        {
            Moedas moedas = new Moedas();
            moedas.GetCotacao2();
        }


        public void GetCotacao2()
        {
            BraziliexAPI.Rootobject cotacao = _download_serialized_json_data<Rootobject>($"https://braziliex.com/api/v1/public/ticker");
            var dataCotacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    var btc = Decimal.Round(cotacao.btc_brl.last, 2);
                    var eth = Decimal.Round(cotacao.eth_brl.last, 2);
                    var bch = Decimal.Round(cotacao.bch_brl.last, 2);
                    var xmr = Decimal.Round(cotacao.xmr_brl.last, 2);
                    var zec = Decimal.Round(cotacao.zec_brl.last, 2);

            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_table = "historicocotacao";


            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_table} (idCriptomoeda,cotacao,dataCotacao) VALUES (1, '{btc}', '{dataCotacao}')," +
                    $"(2, '{eth}', '{dataCotacao}')," +
                    $"(3, '{bch}', '{dataCotacao}')," +
                    $"(4, '{xmr}', '{dataCotacao}')," +
                    $"(6, '{zec}', '{dataCotacao}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Não foi possível obter a cotação.');", true);
            }
        }


        public void GetCotacaoCrypto()
        {
            CryptoCompareAtualAPI.Rootobject cotacao = _download_serialized_json_data<CryptoCompareAtualAPI.Rootobject>($"https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,XMR,BCH,ZEC&tsyms=BRL");
            var dataCotacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var btc = Decimal.Round(cotacao.BTC.BRL, 2);
            var eth = Decimal.Round(cotacao.ETH.BRL, 2);
            var bch = Decimal.Round(cotacao.BCH.BRL, 2);
            var xmr = Decimal.Round(cotacao.XMR.BRL, 2);
            var zec = Decimal.Round(cotacao.ZEC.BRL, 2);

            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_table = "historicocotacao";


            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_table} (idCriptomoeda,cotacao,dataCotacao) VALUES (1, '{btc}', '{dataCotacao}')," +
                    $"(2, '{eth}', '{dataCotacao}')," +
                    $"(3, '{bch}', '{dataCotacao}')," +
                    $"(4, '{xmr}', '{dataCotacao}')," +
                    $"(6, '{zec}', '{dataCotacao}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Não foi possível obter a cotação.');", true);
            }
        }



        public void GetHistorico(int quantidade)
        {
            CryptoCompareAPI.Rootobject historicoBitcoin = _download_serialized_json_data<CryptoCompareAPI.Rootobject>($"https://min-api.cryptocompare.com/data/histoday?fsym=BTC&tsym=BRL&limit={quantidade}&aggregate=1&e=CCCAGG");
            DataTable dtBitcoin = new DataTable();
            dtBitcoin.Columns.AddRange(new DataColumn[2] { new DataColumn("close"), new DataColumn("time") });

            foreach (var item in historicoBitcoin.Data)
            {
                dtBitcoin.Rows.Add(item.close.ToString(), epoch2string(item.time).ToString());
            }

            CryptoCompareAPI.Rootobject historicoEthereum = _download_serialized_json_data<CryptoCompareAPI.Rootobject>($"https://min-api.cryptocompare.com/data/histoday?fsym=ETH&tsym=BRL&limit={quantidade}&aggregate=1&e=CCCAGG");
            DataTable dtEthereum = new DataTable();
            dtEthereum.Columns.AddRange(new DataColumn[2] { new DataColumn("close"), new DataColumn("time") });

            foreach (var item in historicoEthereum.Data)
            {
                dtEthereum.Rows.Add(item.close.ToString(), epoch2string(item.time).ToString());
            }

            CryptoCompareAPI.Rootobject historicoMonero = _download_serialized_json_data<CryptoCompareAPI.Rootobject>($"https://min-api.cryptocompare.com/data/histoday?fsym=XMR&tsym=BRL&limit={quantidade}&aggregate=1&e=CCCAGG");
            DataTable dtMonero = new DataTable();
            dtMonero.Columns.AddRange(new DataColumn[2] { new DataColumn("close"), new DataColumn("time") });

            foreach (var item in historicoMonero.Data)
            {
                dtMonero.Rows.Add(item.close.ToString(), epoch2string(item.time).ToString());
            }

            CryptoCompareAPI.Rootobject historicoBitcoinCash = _download_serialized_json_data<CryptoCompareAPI.Rootobject>($"https://min-api.cryptocompare.com/data/histoday?fsym=BCH&tsym=BRL&limit={quantidade}&aggregate=1&e=CCCAGG");
            DataTable dtCash = new DataTable();
            dtCash.Columns.AddRange(new DataColumn[2] { new DataColumn("close"), new DataColumn("time") });

            foreach (var item in historicoBitcoinCash.Data)
            {
                dtCash.Rows.Add(item.close.ToString(), epoch2string(item.time).ToString());
            }

            CryptoCompareAPI.Rootobject historicoZcash = _download_serialized_json_data<CryptoCompareAPI.Rootobject>($"https://min-api.cryptocompare.com/data/histoday?fsym=ZEC&tsym=BRL&limit={quantidade}&aggregate=1&e=CCCAGG");
            DataTable dtZcash = new DataTable();
            dtZcash.Columns.AddRange(new DataColumn[2] { new DataColumn("close"), new DataColumn("time") });

            foreach (var item in historicoZcash.Data)
            {
                dtZcash.Rows.Add(item.close.ToString(), epoch2string(item.time).ToString());
            }

            ChartHistoricoBitcoin.Series.Add("Bitcoin");
            ChartHistoricoBitcoin.Series[0].ChartType = SeriesChartType.Line;
            ChartHistoricoBitcoin.Series[0].IsValueShownAsLabel = true;
            ChartHistoricoBitcoin.Series[0].MarkerStep = 1;

            ChartHistorico.Series.Add("Ethereum");
            ChartHistorico.Series[0].ChartType = SeriesChartType.Line;
            ChartHistorico.Series[0].IsValueShownAsLabel = true;
            ChartHistorico.Series[0].MarkerStep = 1;

            ChartHistorico.Series.Add("Monero");
            ChartHistorico.Series[1].ChartType = SeriesChartType.Line;
            ChartHistorico.Series[1].IsValueShownAsLabel = true;
            ChartHistorico.Series[1].MarkerStep = 1;

            ChartHistorico.Series.Add("Bitcoin Cash");
            ChartHistorico.Series[2].ChartType = SeriesChartType.Line;
            ChartHistorico.Series[2].IsValueShownAsLabel = true;
            ChartHistorico.Series[2].MarkerStep = 1;

            ChartHistorico.Series.Add("Zcash");
            ChartHistorico.Series[3].ChartType = SeriesChartType.Line;
            ChartHistorico.Series[3].IsValueShownAsLabel = true;
            ChartHistorico.Series[3].MarkerStep = 1;

            for (int i = 0; i < dtBitcoin.Rows.Count; i++)
            {
                ChartHistoricoBitcoin.Series[0].Points.AddXY(dtBitcoin.Rows[i]["time"].ToString(), Convert.ToDouble(dtBitcoin.Rows[i]["close"].ToString()));
                ChartHistorico.Series[0].Points.AddXY(dtEthereum.Rows[i]["time"].ToString(), Convert.ToDouble(dtEthereum.Rows[i]["close"].ToString()));
                ChartHistorico.Series[1].Points.AddXY(dtMonero.Rows[i]["time"].ToString(), Convert.ToDouble(dtMonero.Rows[i]["close"].ToString()));
                ChartHistorico.Series[2].Points.AddXY(dtCash.Rows[i]["time"].ToString(), Convert.ToDouble(dtCash.Rows[i]["close"].ToString()));
                ChartHistorico.Series[3].Points.AddXY(dtZcash.Rows[i]["time"].ToString(), Convert.ToDouble(dtZcash.Rows[i]["close"].ToString()));
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
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch).ToString("yyyy-MM-dd");
        }

        public void GeraGraficoConsumo()
        {
            if (ChartCotacao.Series.Count != 0)
                ChartCotacao.Series.Clear();

            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none"))
            {
                string sql = "SELECT distinct cm.sigla as sigla, cm.nome, cm.algoritmo, hc.cotacao, hc.dataCotacao from criptomoedas cm " +
                    "JOIN historicocotacao hc on cm.idCriptomoeda = hc.idCriptomoeda order BY hc.dataCotacao desc LIMIT 5;"
        ;
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("nome"), new DataColumn("cotacao") });
                        while (sdr.Read())
                        {
                            dt.Rows.Add(sdr["nome"], sdr["cotacao"]);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            ChartCotacao.Series.Add(dt.Rows[i]["nome"].ToString());
                            ChartCotacao.Series[dt.Rows[i]["nome"].ToString()].Points.AddY(Convert.ToDouble(dt.Rows[i]["cotacao"].ToString()));
                            ChartCotacao.Series[i].ChartType = SeriesChartType.Bar;
                            ChartCotacao.Series[i].Label = dt.Rows[i]["nome"].ToString() + " R$ " + dt.Rows[i]["cotacao"].ToString();
                        }
                    }
                }
            }
        }
    }
}





