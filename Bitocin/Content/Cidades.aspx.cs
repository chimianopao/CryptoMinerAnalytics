using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Bitocin.Content.API;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Bitocin.Content {
    public partial class Cidades : System.Web.UI.Page {
        public string valor = "Bitcoin";
  
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizaCotacaoDolar();
            GeraTabelaCidades();
            GeraGraficoCidades();
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

        public static void ChamaAtualizadorCotacao()
        {
           Cidades cidades = new Cidades();
            cidades.AtualizaCotacaoDolar();
        }

        public void AtualizaCotacaoDolar()
        {
            CurrencyConverterAPI.Rootobject cotacao = _download_serialized_json_data<CurrencyConverterAPI.Rootobject>("https://free.currencyconverterapi.com/api/v6/convert?q=USD_BRL&compact=ultra");

            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");

            string valorCotacao = cotacao.USD_BRL.ToString().Replace(",", ".");

            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE custoenergia SET custoKWh = (custoEmDolar*{valorCotacao}) " +
                    "WHERE pais = 'EUA';", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQL_conection.Close();
            }
            catch (Exception e2)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", $"alert('Erro ao tentar atualizar a cotação do dolar. Tente novamente mais tarde.\nErro: {e2.Message}');", true);
            }
        }

       
        public void GeraTabelaCidades()
        {
            string moeda = "";

            if (Request.Form["selectMoeda"] == null)
                moeda = "Bitcoin";
            else
                moeda = Request.Form["selectMoeda"];

            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "hardwares";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT * FROM custoenergia ORDER BY cidade;", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();

            SQL_conection.Close();

                valor = moeda;
            }
            catch (Exception e){
                valor = "Erro ao gerar tabela:" + e.Message;
            }
        }

        public void loadTableButton_Click(Object sender, EventArgs e)
        {
            GeraTabelaCidades();
        }


        public void ButtonCadastro_Click(Object sender, EventArgs e)
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "custoenergia";

            string cidade = Request.Form["cidade"];
            string estado = Request.Form["estado"];
            string concessionaria = Request.Form["concessionaria"];
            string custo = Request.Form["custo"];
            string co2 = Request.Form["co2"];

            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_tabel} (cidade,estado,pais,concessionaria,custoKWh,emissaoCO2porWh) VALUES ('{cidade}','{estado}','Brasil','{concessionaria}','{custo}','{co2}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQL_conection.Close();

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Cidade cadastrada com sucesso');", true);
                GeraTabelaCidades();
            }
            catch (Exception e2)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", $"alert('Erro ao cadastrar. Por favor, preencha todos os campos.\nErro: {e2.Message}');", true);
            }


        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            Response.Write(GridView2.DataSource.GetType());

            DataTable m_DataTable = GridView2.DataSource as DataTable;

            if (m_DataTable != null)
            {
                DataView m_DataView = new DataView(m_DataTable);
                m_DataView.Sort = e.SortExpression + " " + e.SortDirection;

                GridView2.DataSource = m_DataView;
                GridView2.DataBind();
            }
        }


        public void GeraGraficoCidades()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none"))
            {
                string sql = "select * from custoenergia ORDER BY custoKWh;";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("custoKWh"), new DataColumn("cidade") });
                        while (sdr.Read())
                        {
                            dt.Rows.Add(sdr["custoKWh"], sdr["cidade"]);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            Chart2.Series.Add(dt.Rows[i]["cidade"].ToString());
                            Chart2.Series[dt.Rows[i]["cidade"].ToString()].Points.AddY(Convert.ToDouble(dt.Rows[i]["custoKWh"].ToString()));
                            Chart2.Series[i].ChartType = SeriesChartType.Bar;
                            Chart2.Series[i].Label = dt.Rows[i]["cidade"].ToString() + " R$ " + dt.Rows[i]["custoKWh"].ToString();
                        }
                    }
                }
            }
        }
    }
}

