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
    public partial class Emissao : System.Web.UI.Page {
        string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
        public string valor;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CarregaMenuHardwares();
          
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
            

            string QueryString = "select hw.modelo from hardwares hw ORDER BY hw.modelo;";
             

            MySqlConnection myConnection = new MySqlConnection(ConnectString);
            MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
            myConnection.Open();
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "modelo");

            selectHardware.DataSource = ds;
            selectHardware.DataTextField = "modelo";
            selectHardware.DataValueField = "modelo";
            selectHardware.DataBind();//adicionei

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

            
            labelHardware.InnerText = hardware;

            using (MySqlConnection cn = new MySqlConnection(ConnectString))

            #region busca emissao
            
            using (MySqlCommand cmd = new MySqlCommand($"SELECT hw.consumo FROM hardwares hw " +

                $"WHERE hw.modelo = '{hardware}';", cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        double.TryParse(sdr["consumo"].ToString(), out double c);
   //                     c = (c * quantidade * 0.000051);//quilos por hora
                        c = (c * quantidade * 0.000051);//quilos por hora
                        labelTotalEmissao.InnerText = c.ToString("0.00");
                        c = c * 24;
                        labelEmissaoDia.InnerText = c.ToString("0.00");
                        c = c * 30;
                        labelEmissaoMes.InnerText = c.ToString("0.00");
                            CalculaEmissao(c, quantidade, 0);
                    }
                }
                cn.Close();

                #endregion

                #region busca consumo
                using (MySqlCommand cmdd = new MySqlCommand($"SELECT hw.consumo FROM hardwares hw " +

                    $"WHERE hw.modelo = '{hardware}';", cn))
                {
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {


                            double.TryParse(sdr["consumo"].ToString(), out double c);
                            c = (c * quantidade);
                            labelTotalConsumo.InnerText = c.ToString();
                            
                            CalculaConsumo(c, quantidade);
                            CalculaEmissao(c, quantidade, 0);
                        }
                    }
                    cn.Close();
                }
                #endregion

            }
        }


        

        public void CalculaConsumo(double consumoTotal, int quantidade)
        {
            consumoTotal = (consumoTotal * quantidade);

            consumoTotal = consumoTotal / 1000;  
            decimal resultado = 0;
            

        }

        public void CalculaEmissao(double consumoTotal, int quantidade, double emissao)
        {
            emissao = consumoTotal * quantidade * 0.000051;
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
                
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

       

}
}