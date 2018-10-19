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
    public partial class Index : System.Web.UI.Page {
        string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
        public string valor;
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaMenuMoedas();
            CarregaMenuHardwares();
            CarregaMenuCidades();
            GetCotacao();
            //   Button1.Click(sender, e);
        }

        //   MySqlConnection SQL_koneksi = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PWD=;");
        //   String nama_tabel = "twitter_clone.usuarios";
        //   MySqlDataAdapter db_select;
        //  DataSet db_data;
        //   MySqlCommand SQL_cmd;
        //   string Query;

        public void CarregaMenuMoedas()
        {
            string QueryString = "select nome from criptomoedas";

            MySqlConnection myConnection = new MySqlConnection(ConnectString);
            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
            myConnection.Open();
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "nome");

            selectMoeda.DataSource = ds;
            selectMoeda.DataTextField = "nome";
            selectMoeda.DataValueField = "nome";
            selectMoeda.DataBind();

            myConnection.Close();
        }

        public void selectMoeda_onchange(Object sender, EventArgs e)
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
            //    string moeda = Request.Form["selectMoeda"];

            string QueryString = "select hw.modelo from hardwares hw " +
                    "JOIN processamento pr ON hw.idHardware = pr.idHardware " +
                    "JOIN criptomoedas cm ON cm.idCriptomoeda = pr.idCriptomoeda " +
                    $"WHERE cm.nome = '{moeda}';";

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

        public void CarregaMenuCidades()
        {
            string QueryString = "select cidade from custoenergia ORDER BY cidade;";

            MySqlConnection myConnection = new MySqlConnection(ConnectString);
            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
            myConnection.Open();
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "cidade");

            selectCidade.DataSource = ds;
            selectCidade.DataTextField = "cidade";
            selectCidade.DataValueField = "cidade";
            selectCidade.DataBind();

            myConnection.Close();
        }

        public void ButtonCalcular_Click(Object sender, EventArgs e)
        {
            string moeda = Request.Form["selectMoeda"];
            string hardware = Request.Form["selectHardware"];
            string cidade = Request.Form["selectCidade"];
            string algoritmo = "";
            string cotacao = "";
            int quantidade = int.Parse(Request.Form["quantidadeHw"]);
            double custoKWh = 0;

            labelMoeda.InnerText = moeda;
            labelHardware.InnerText = hardware;
            labelCidade.InnerText = cidade;
            labelQuantidade.InnerText = " x " + quantidade.ToString();

            using (MySqlConnection cn = new MySqlConnection(ConnectString))
            {
                #region busca algoritmo
                using (MySqlCommand cmd = new MySqlCommand($"select algoritmo from criptomoedas WHERE nome = '{moeda}';", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            algoritmo = sdr["algoritmo"].ToString();
                        }
                    }
                    cn.Close();
                }
                labelAlgoritmo.InnerText = algoritmo;
                #endregion

                #region busca cotação do dia
                using (MySqlCommand cmd = new MySqlCommand($"SELECT hc.cotacao from criptomoedas cm JOIN historicocotacao hc on cm.idCriptomoeda = hc.idCriptomoeda where cm.nome = '{moeda}';", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            cotacao = sdr["cotacao"].ToString();
                        }
                    }
                    cn.Close();
                }
                labelCotacao.InnerText = cotacao;
                #endregion

                #region busca custo energia
                using (MySqlCommand cmd = new MySqlCommand($"SELECT custoKWh FROM custoenergia WHERE cidade = '{cidade}';", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            labelCusto.InnerText = sdr["custoKWh"].ToString();
                            custoKWh = double.Parse(sdr["custoKWh"].ToString());
                        }
                    }
                    cn.Close();
                }
                #endregion

                #region busca processamento, unidade e consumo
                using (MySqlCommand cmd = new MySqlCommand($"SELECT pro.processamentoPorSegundo, pro.unidade, hw.consumo, hw.preco FROM hardwares hw " +
                    $"JOIN processamento pro ON hw.idHardware = pro.idHardware WHERE hw.modelo = '{hardware}';", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            double.TryParse(sdr["processamentoPorSegundo"].ToString(), out double p);
                            p = p * quantidade;
                            labelTotalProcessamento.InnerText = p.ToString();

                            double.TryParse(sdr["consumo"].ToString(), out double c);
                            c = (c * quantidade) + double.Parse(ConsumoOutros.Value);

                            labelCustoAquisitivo.InnerText = (sdr["preco"].ToString());


                            labelTotalConsumo.InnerText = c.ToString();

                            labelUnidade.InnerText = sdr["unidade"].ToString();

                            CalculaConsumo(c, quantidade, custoKWh);
                        }
                    }
                    cn.Close();
                }
                #endregion
            }
        }


        public void CalculaConsumo(double consumoTotal, int quantidade, double custoKWh)
        {
            double consumoOutros = double.Parse(ConsumoOutros.Value);
            consumoTotal = (consumoTotal * quantidade) + consumoOutros;

            consumoTotal = consumoTotal / 1000;  //kWh
            consumoTotal = consumoTotal * 24; //final kWh

            labelCustoDia.InnerText = (consumoTotal * custoKWh).ToString();
            labelGanhoDia.InnerText = "sei la";
            labelLucroDia.InnerText = "asdasdasd";

        }


 
        
    
        public void GetCotacao()
        {
            Rootobject cotacao = _download_serialized_json_data<Rootobject>("https://www.coinwarz.com/v1/api/profitability/?apikey=a8bb5bb5ebb44218b75b8130410d77ca&algo=all");

            float dificuldade = cotacao.Data[0].Difficulty;
            float blockReward = cotacao.Data[0].BlockReward;
            Bitcoin bit = new Bitcoin();


            foreach (var item in cotacao.Data)
            {
                if (item.CoinName.Equals("Bitcoin")) {
                bit.BlockReward = item.BlockReward;
                bit.Difficulty = item.Difficulty;
            }
            }
            
         

            //switch (idmoeda)
            //{
            //    case 1:
            //        novo = Decimal.Round(cotacao.btc_brl.last, 2);
            //        break;
            //    case 2:
            //        novo = Decimal.Round(cotacao.eth_brl.last, 2);
            //        break;
            //    case 3:
            //        novo = Decimal.Round(cotacao.ltc_brl.last, 2);
            //        break;
            //    case 4:
            //        novo = Decimal.Round(cotacao.xmr_brl.last, 2);
            //        break;
            //    case 5:
            //        novo = Decimal.Round(cotacao.dash_brl.last, 2);
            //        break;
            //    case 6:
            //        novo = Decimal.Round(cotacao.zec_brl.last, 2);
            //        break;
            //}

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

        private class Bitcoin{
            public string Name;
        public float Difficulty { get; set; }
        public float BlockReward { get; set; }
            public Bitcoin()
            {

            }
    }

}
}