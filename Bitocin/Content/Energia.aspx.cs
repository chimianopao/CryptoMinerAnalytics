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
    public partial class Energia : System.Web.UI.Page {
        public string valor = "Bitcoin";
        protected void Page_Load(object sender, EventArgs e)
        {
            GeraTabelaCidades();
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
                db_select = new MySqlDataAdapter("SELECT * FROM custoenergia;", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
              //  string unidade = db_data.Tables[0].Rows[0]["unidade"].ToString();
             //   GridView2.Columns[3].HeaderText = unidade;
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

    }
}

