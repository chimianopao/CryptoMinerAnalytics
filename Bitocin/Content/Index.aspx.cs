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
            if (!IsPostBack)
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
        }

        public void moedaDropDown_Change(Object sender, EventArgs e)
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
                var nomeMoeda = Request.Form["selectMoeda"];
                using (MySqlCommand cmd = new MySqlCommand($"SELECT pro.processamentoPorSegundo, pro.unidade, hw.consumo, hw.preco FROM hardwares hw " +
                    $"JOIN processamento pro ON hw.idHardware = pro.idHardware " +
                    $"JOIN criptomoedas c on c.idCriptomoeda = pro.idCriptomoeda " +
                    $"WHERE hw.modelo = '{hardware}' AND c.nome = '{nomeMoeda}';", cn))
                {//where moeda = selecionada
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

                            labelCustoAquisitivo.InnerText = ((double.Parse(sdr["preco"].ToString())*quantidade).ToString());


                            labelTotalConsumo.InnerText = c.ToString();
                            labelEmissaoHora.InnerText = (c * 0.000051).ToString("0.00");
                            labelEmissaoDia.InnerText = (c * 0.000051 * 24).ToString("0.00");
                            labelEmissaoMes.InnerText = (c * 0.000051 * 24 * 30).ToString("0.00");

                            labelUnidade.InnerText = sdr["unidade"].ToString();

                            CalculaConsumo(c, quantidade, custoKWh, p);
                        }
                    }
                    cn.Close();
                }
                #endregion
            }
        }


        public void CalculaConsumo(double consumoTotal, int quantidade, double custoKWh, double poderProcessamento)
        {
            double consumoOutros = double.Parse(ConsumoOutros.Value);
            consumoTotal = (consumoTotal * quantidade) + consumoOutros;

            consumoTotal = consumoTotal / 1000;  //kWh
          //  consumoTotal = consumoTotal * 24; //final kWh

            var moeda = GetCotacao();

            //  decimal resultado = ( ((decimal)poderProcessamento/51041010300000) * moeda.BlockReward * moeda.BlockTimeInSeconds * moeda.ExchangeRate) - ((decimal)custoKWh * (decimal)consumoTotal);
            // decimal resultado = (((decimal)poderProcessamento * moeda.BlockReward) / moeda.Difficulty) * 3600;

            //decimal resultado = (decimal)(poderProcessamento * 3600) / ((decimal)Math.Pow(2,32) * moeda.Difficulty);
            //resultado = resultado * moeda.BlockReward;
            //resultado = resultado * 24449;

            //decimal resultado = (((decimal)poderProcessamento*1000000) * (decimal)moeda.BlockReward * 3600) / ((decimal)Math.Pow(2, 32) * moeda.Difficulty);
            //resultado = resultado * 24449;
            decimal resultado = 0;
            if (Request.Form["selectMoeda"].Equals("Zcash") || Request.Form["selectMoeda"].Equals("Ethereum"))
            {
                resultado = ((decimal)poderProcessamento * 1000000) / 19006000000000 * (3600 / moeda.BlockTimeInSeconds * moeda.BlockReward) * moeda.ExchangeRate;
                resultado = resultado * 573;
            }
            else
            {
                resultado = (((decimal)poderProcessamento * 1000000) * (decimal)moeda.BlockReward * 3600) / ((decimal)Math.Pow(2, 32) * moeda.Difficulty);
                resultado = resultado * 24449;
            }

            labelCustoHora.InnerText = (consumoTotal * custoKWh).ToString("0.00");
            labelGanhoHora.InnerText = resultado.ToString("0.00");
            labelLucroHora.InnerText = (resultado-(decimal)(custoKWh*consumoTotal)).ToString("0.00");

            labelCustoDia.InnerText = ((consumoTotal * custoKWh)*24).ToString("0.00");
            labelGanhoDia.InnerText = (resultado*24).ToString("0.00");
            labelLucroDia.InnerText = ((resultado - (decimal)(custoKWh * consumoTotal))*24).ToString("0.00");

            labelCustoMes.InnerText = ((consumoTotal * custoKWh) * 24*30).ToString("0.00");
            labelGanhoMes.InnerText = (resultado * 24*30).ToString("0.00");
            labelLucroMes.InnerText = ((resultado - (decimal)(custoKWh * consumoTotal)) * 24*30).ToString("0.00");

        }


 
        
    
        public Datum GetCotacao()
        {
            //a8bb5bb5ebb44218b75b8130410d77ca
            //dcd1f4eac4584a9eb7f6e8009a4af9b7
            //16d28c2ba974467494b30c53dec66b21
            string KEY1 = "a8bb5bb5ebb44218b75b8130410d77ca";
            string KEY2 = "dcd1f4eac4584a9eb7f6e8009a4af9b7";
            string KEY3 = "16d28c2ba974467494b30c53dec66b21";
            string KEY4 = "2223d1f34d9a4788b74c6baeea2b7181";


            Rootobject cotacao = _download_serialized_json_data<Rootobject>($"https://www.coinwarz.com/v1/api/profitability/?apikey={KEY1}&algo=all");

            if (cotacao.Success == false)
            {
                cotacao = _download_serialized_json_data<Rootobject>($"https://www.coinwarz.com/v1/api/profitability/?apikey={KEY2}&algo=all");
                if (cotacao.Success == false)
                {
                    cotacao = _download_serialized_json_data<Rootobject>($"https://www.coinwarz.com/v1/api/profitability/?apikey={KEY3}&algo=all");
                    if (cotacao.Success == false)
                        cotacao = _download_serialized_json_data<Rootobject>($"https://www.coinwarz.com/v1/api/profitability/?apikey={KEY4}&algo=all");
                }
            }
            foreach (var item in cotacao.Data)
            {
                if (item.CoinName.Equals(Request.Form["selectMoeda"])) {
                    return item;
            }
            }
            return null;
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

       

}
}