using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Bitocin.Content {
    public partial class Energia : System.Web.UI.Page {
        public string valor = "Bitcoin";
        private string m_strSortExp = "Estado";
        private SortDirection m_SortDirection;

        protected void Page_Load(object sender, EventArgs e)
        {
            GeraTabelaCidades();
            GeraGrafico();

            CleanChart(this.ColumnChart);

            var data = CreateSampleData();

            BindColumnChart(this.ColumnChart, SeriesChartType.Column, data);
        }

        
        //public string rodaQuery()
        //{
        //    string sql = " SELECT senha FROM usuarios  ";
        //    MySqlConnection con = new MySqlConnection("host=localhost;user=root;password='';database=twitter_clone;SslMode=none");
        //    MySqlCommand cmd = new MySqlCommand(sql, con);
        //    string temp = "";
        //    con.Open();

        //    MySqlDataReader reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        temp = reader.GetString("senha");

        //    }
        //    con.Close();
        //    return temp;
        //}

       
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

         //   Chart1.DataSource = db_data;
         //   Chart1.DataBind();


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
            Response.Write(GridView2.DataSource.GetType()); //Add this line

            DataTable m_DataTable = GridView2.DataSource as DataTable;

            if (m_DataTable != null)
            {
                DataView m_DataView = new DataView(m_DataTable);
                m_DataView.Sort = e.SortExpression + " " + e.SortDirection;

                GridView2.DataSource = m_DataView;
                GridView2.DataBind();
            }
        }


        public void GeraGrafico()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none"))
            {
                string sql = "select * from custoenergia;";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    //cmd.CommandType = CommandType.Text;
                    //cmd.Connection = cn;
                    //cn.Open();
                    //int i = 0;
                    //using (MySqlDataReader sdr = cmd.ExecuteReader())
                    //{
                    //    while (sdr.Read())
                    //    {
                    //        Chart1.Series[i].XValueType = ChartValueType.Double;
                    //        Chart1.Series[i].YValueType = ChartValueType.String;
                    //       // Chart1.Series[i].Legend = sdr["cidade"].ToString();

                    //        Chart1.Series[i].Points.AddXY(sdr["custoKWh"], sdr["cidade"]);
                    //        i++;
                    //    }
                    //}
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                }
            }
            //foreach (var item in dt.Rows)
            //{
            //    item.
            //}
            Chart1.DataSource = dt;
            Chart1.Series["Default"].IsValueShownAsLabel = true;
            Chart1.Series["Default"].XValueType = ChartValueType.String;
            Chart1.Series["Default"].YValueType = ChartValueType.Double;
            Chart1.Series["Default"].IsVisibleInLegend = true;
            //int i = Chart1.Series.Count - 1;
            //while (i!=0)
            //{
            //    Chart1.Series[i].Label = Chart1.Series[i].Name;
            //    i--;
            //}

            Chart1.DataBind();
        }


        public void GeraGrafico2()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //Create a connection to SQL DataBase
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            con.Open();

            //Select all the records in database
            string command = "select * from custoenergia";
            MySqlCommand cmd = new MySqlCommand(command, con);
            adapter.SelectCommand = cmd;

            //Retrieve the records from database
            adapter.Fill(table);

            //Set DataTable as data source to Chart
            this.Chart1.DataSource = table;

            //Mapping a field with x-value of chart
            this.Chart1.Series[0].XValueMember = "custoKWh";

            //Mapping a field with y-value of Chart
            this.Chart1.Series[0].YValueMembers = "idCustoEnergia";

            //Bind the DataTable with Chart
            this.Chart1.DataBind();
        }




        private static ChartData[] CreateSampleData()
        {
            ChartData[] data = new ChartData[8];

            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < data.Length; i++)
            {
                int index = i + 1;

                ChartData currentChartData = data[i] = new ChartData();
                currentChartData.X = index;
                currentChartData.Y = rnd.Next(25) + rnd.NextDouble();
                currentChartData.Legend = string.Format("Legend {0}", index);
            }

            return data;
        }

        public class ChartData {
            public double X { get; set; }

            public double Y { get; set; }

            public string Legend { get; set; }
        }

        private static void CleanChart(Chart currentChart)
        {
            foreach (var itemSerie in currentChart.Series)
            {
                if (itemSerie.Points != null)
                    itemSerie.Points.Clear();
            }
        }

        private static void BindColumnChart(Chart currentChart, SeriesChartType chartType, params ChartData[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (currentChart.Series.Count <= i)
                    break;

                ChartData currentChartData = data[i];

                // Largura da barra
                currentChart.Series[i]["PointWidth"] = "1.5";

                currentChart.Series[i].XValueType = ChartValueType.Double;
                currentChart.Series[i].YValueType = ChartValueType.Double;

                currentChart.Series[i].Points.AddXY(currentChartData.X, currentChartData.Y);
                currentChart.Series[i].Label = currentChartData.Y.ToString("F");
                currentChart.Series[i].ChartType = chartType;
                currentChart.Series[i].LegendText = currentChartData.Legend;
            }

            currentChart.DataBind();
        }













    }
}

