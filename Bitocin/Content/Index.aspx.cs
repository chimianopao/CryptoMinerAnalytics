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
            if (Request.Form["selectMoeda"]!=null)
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

            labelMoeda.InnerText = moeda;
            labelHardware.InnerText = hardware;
            labelCidade.InnerText = cidade;
            labelQuantidade.InnerText = " x "+quantidade.ToString();

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
                        }
                    }
                    cn.Close();
                }
                #endregion

                #region busca processamento, unidade e consumo
                using (MySqlCommand cmd = new MySqlCommand($"SELECT pro.processamentoPorSegundo, pro.unidade, hw.consumo FROM hardwares hw " +
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
                            c = c * quantidade;
                            labelTotalConsumo.InnerText = c.ToString();

                            labelUnidade.InnerText = sdr["unidade"].ToString();
                            
                        }
                    }
                    cn.Close();
                }
                #endregion
            }
        }



        //        protected void Button1_Click(object sender, EventArgs e)
        //        {
        //            //Get the data from database, and fill it to the datatable
        //            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Server=localhost;Port=3306;Database=cripto;Uid=root;Pwd=''"].ConnectionString);
        //        string sql = "SELECT * FROM hardwares";
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        //        sda.Fill(dt);

        //            //show the data to the GridView
        //            GridView2.DataSource = dt;
        //            GridView2.DataBind();
        //}


    }
}