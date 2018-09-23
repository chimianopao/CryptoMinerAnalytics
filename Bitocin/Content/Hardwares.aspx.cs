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
    public partial class Hardwares : System.Web.UI.Page {
        public string valor;
        protected void Page_Load(object sender, EventArgs e)
        {
 //           valor = rodaQuery();
            GeraTabelaHardware("CPU");
        }

        

        public void GeraTabelaHardware(String filtro)
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "hardwares";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT marca, modelo, consumo, preco, ano FROM " + name_tabel + " WHERE tipo='" + filtro + "'", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
            }
            catch {
                valor = "deu pau";
            }


        }

        public void loadTableButton_Click(Object sender, EventArgs e)
        {
            GeraTabelaHardware(Request.Form["selectHardware"]);
        }


        public void ButtonCadastro_Click(Object sender, EventArgs e)
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "hardwares";

            string marca = Request.Form["marca"];
            string modelo = Request.Form["modelo"];
            string tipo = Request.Form["selectTypeCreation"];
            string consumo = Request.Form["consumo"];
            string preco = Request.Form["preco"];
            string ano = Request.Form["ano"];

            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_tabel} (marca,modelo,tipo,consumo,preco,ano,aprovado) VALUES ('{marca}','{modelo}','{tipo}',{consumo},{preco},{ano},0);", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Hardware cadastrado com sucesso');", true);
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Erro ao cadastrar. Por favor, preencha todos os campos.');", true);
            }
        }


        }
}

