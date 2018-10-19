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
    public partial class Hardwares : System.Web.UI.Page {
        string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
        public string valor = "Bitcoin";
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaMenuMoedas();
            GeraTabelaHardware();
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

        public void CarregaMenuMoedas()
        {
                
                string QueryString = "select nome from criptomoedas";

                MySqlConnection myConnection = new MySqlConnection(ConnectString);
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "nome");

                selectMoeda.DataSource = ds;
                selectMoeda.DataTextField = "nome";
                selectMoeda.DataValueField = "nome";
                selectMoeda.DataBind();

            selectMoedaCadastro.DataSource = ds;
            selectMoedaCadastro.DataTextField = "nome";
            selectMoedaCadastro.DataValueField = "nome";
            selectMoedaCadastro.DataBind();
            //labelUnidade.InnerText = "asd"; //select e jogar aqui
            myConnection.Close();
        }

        public void GeraTabelaHardware()
        {
            string moeda = "";

            if (Request.Form["selectMoeda"] == null)
                moeda = "Bitcoin";
            else
                moeda = Request.Form["selectMoeda"];

            MySqlConnection SQL_conection = new MySqlConnection(ConnectString);
            String name_tabel = "hardwares";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT hw.tipo, hw.marca, hw.modelo, pr.processamentoPorSegundo, hw.consumo, hw.preco, hw.ano, pr.unidade FROM hardwares hw " +
                    "JOIN processamento pr ON hw.idHardware = pr.idHardware " +
                    "JOIN criptomoedas cm ON cm.idCriptomoeda = pr.idCriptomoeda " +
                    $"WHERE cm.nome = '{moeda}';", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
             //   string unidade = db_data.Tables[0].Rows[0]["unidade"].ToString(); botava a unidade no nome da coluna
             //   GridView2.Columns[3].HeaderText = unidade;
                SQL_conection.Close();

                valor = moeda;

                GeraGraficoProcessamento(moeda);
                GeraGraficoConsumo(moeda);
            }
            catch (Exception e){
                valor = "Erro ao gerar tabela:" + e.Message;
            }
        }

        public void loadTableButton_Click(Object sender, EventArgs e)
        {
            GeraTabelaHardware();
        }


        public void ButtonCadastro_Click(Object sender, EventArgs e)
        {
            MySqlConnection SQL_conection = new MySqlConnection(ConnectString);
            String name_tabel = "hardwares";

            string marca = Request.Form["marca"];
            string modelo = Request.Form["modelo"];
            string tipo = Request.Form["selectTypeCreation"];
            string consumo = Request.Form["consumo"];
            string preco = Request.Form["preco"];
            string ano = Request.Form["ano"];
            string processamento = Request.Form["processamento"];

            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_tabel} (marca,modelo,tipo,consumo,preco,ano,aprovado) VALUES ('{marca}','{modelo}','{tipo}',{consumo},'{preco}',{ano},0);", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQL_conection.Close();

              
                #region Pega idHardware do hw novo
                int idHardware;
                string temp = "";

                cmd = new MySqlCommand($"SELECT idHardware from hardwares WHERE marca = '{marca}' AND modelo = '{modelo}';", SQL_conection);
                SQL_conection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    temp = reader.GetString("idHardware");
                }
                SQL_conection.Close();
                idHardware = int.Parse(temp);
                #endregion

                #region Pega idCriptomoeda do hw novo
                int idCriptomoeda = 0;
                string unidade = "";
                temp = "";
                cmd = new MySqlCommand($"SELECT cm.idCriptomoeda, pro.unidade from criptomoedas cm " +
                    $"JOIN processamento pro on cm.idCriptomoeda = pro.idCriptomoeda " +
                    $"WHERE cm.nome = '{Request.Form["selectMoedaCadastro"]}';", SQL_conection);
                SQL_conection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idCriptomoeda = int.Parse(reader.GetString("idCriptomoeda"));
                    unidade = reader.GetString("unidade");
                }
                SQL_conection.Close();
                #endregion

                #region Insere processamento
                SQL_conection.Open();
                cmd = new MySqlCommand($"INSERT INTO processamento (idHardware,idCriptomoeda,processamentoPorSegundo,unidade) VALUES ({idHardware}, {idCriptomoeda}, '{processamento}', '{labelUnidade.InnerText}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                SQL_conection.Close();
                #endregion

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Hardware cadastrado com sucesso');", true);

            }
            catch (Exception e2)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", $"alert('Erro ao cadastrar. Por favor, preencha todos os campos.\nErro: {e2.Message}');", true);
            }


        }

        public void MoedaCadastroChange(Object sender, EventArgs e)
        {
            labelUnidade.InnerText = selectMoedaCadastro.Value;
        }

        public void GeraGraficoProcessamento(string moeda)
        {
            if(ChartProcessamento.Series.Count != 0)
                ChartProcessamento.Series.Clear();

            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none"))
            {
                string sql = "SELECT hw.tipo, hw.marca, hw.modelo, pr.processamentoPorSegundo, hw.consumo, hw.preco, hw.ano, pr.unidade FROM hardwares hw " +
                    "JOIN processamento pr ON hw.idHardware = pr.idHardware " +
                    "JOIN criptomoedas cm ON cm.idCriptomoeda = pr.idCriptomoeda " +
                    $"WHERE cm.nome = '{moeda}' ORDER BY pr.processamentoPorSegundo;";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("modelo"), new DataColumn("processamentoPorSegundo"), new DataColumn("unidade") });
                        while (sdr.Read())
                        {
                            dt.Rows.Add(sdr["modelo"], sdr["processamentoPorSegundo"], sdr["unidade"]);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            ChartProcessamento.Series.Add(dt.Rows[i]["modelo"].ToString());
                            ChartProcessamento.Series[dt.Rows[i]["modelo"].ToString()].Points.AddY(Convert.ToDouble(dt.Rows[i]["processamentoPorSegundo"].ToString()));
                            //  Chart2.Series[i].IsValueShownAsLabel = true;
                            ChartProcessamento.Series[i].ChartType = SeriesChartType.Bar;
                            ChartProcessamento.Series[i].Label = dt.Rows[i]["modelo"].ToString() + " " + dt.Rows[i]["processamentoPorSegundo"].ToString() + " " + dt.Rows[i]["unidade"].ToString();
                            
                        }
                    }


                }
            }
           

        }

        public void GeraGraficoConsumo(string moeda)
        {
            if (ChartConsumo.Series.Count != 0)
                ChartConsumo.Series.Clear();

            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none"))
            {
                string sql = "SELECT hw.tipo, hw.marca, hw.modelo, pr.processamentoPorSegundo, hw.consumo, hw.preco, hw.ano, pr.unidade FROM hardwares hw " +
                    "JOIN processamento pr ON hw.idHardware = pr.idHardware " +
                    "JOIN criptomoedas cm ON cm.idCriptomoeda = pr.idCriptomoeda " +
                    $"WHERE cm.nome = '{moeda}' ORDER BY hw.consumo;";
                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;
                    cn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("modelo"), new DataColumn("consumo") });
                        while (sdr.Read())
                        {
                            dt.Rows.Add(sdr["modelo"], sdr["consumo"]);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            ChartConsumo.Series.Add(dt.Rows[i]["modelo"].ToString());
                            ChartConsumo.Series[dt.Rows[i]["modelo"].ToString()].Points.AddY(Convert.ToDouble(dt.Rows[i]["consumo"].ToString()));
                            //  Chart2.Series[i].IsValueShownAsLabel = true;
                            ChartConsumo.Series[i].ChartType = SeriesChartType.Bar;
                            ChartConsumo.Series[i].Label = dt.Rows[i]["modelo"].ToString() + " " + dt.Rows[i]["consumo"].ToString() + " Watts";

                        }
                    }


                }
            }


        }


    }
}

