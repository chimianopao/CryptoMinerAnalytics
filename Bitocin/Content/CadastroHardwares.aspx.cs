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
    public partial class CadastroHardwares : System.Web.UI.Page {
        string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaMenuMoedas();
            GeraTabelaHardware();
        }

        public void CarregaMenuMoedas()
        {
            //if (!IsPostBack)
            //{
                string QueryString = "select nome from criptomoedas";

                MySqlConnection myConnection = new MySqlConnection(ConnectString);
                MySqlDataAdapter myCommand = new MySqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "nome");

            selectMoedaCadastro.DataSource = ds;
            selectMoedaCadastro.DataTextField = "nome";
            selectMoedaCadastro.DataValueField = "nome";
            selectMoedaCadastro.DataBind();
            ////labelUnidade.InnerText = "asd"; //select e jogar aqui
            myConnection.Close();
           // }
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
                db_select = new MySqlDataAdapter("SELECT hw.tipo, hw.marca, hw.modelo, cm.nome, pr.processamentoPorSegundo, hw.consumo, hw.preco, hw.ano, pr.unidade FROM hardwares hw " +
                    "JOIN processamento pr ON hw.idHardware = pr.idHardware " +
                    "JOIN criptomoedas cm ON cm.idCriptomoeda = pr.idCriptomoeda ORDER BY hw.modelo", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
                //   string unidade = db_data.Tables[0].Rows[0]["unidade"].ToString(); botava a unidade no nome da coluna
                //   GridView2.Columns[3].HeaderText = unidade;
                SQL_conection.Close();
            }
            catch (Exception e)
            {
                
            }
        }


    }
}

