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
    public partial class Moedas : System.Web.UI.Page {
        public string valor;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GeraTabelaMoedas();
        }

      
        public void GeraTabelaMoedas()
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "criptomoedas";
            MySqlDataAdapter db_select;
            DataSet db_data;

            try
            {
                db_select = new MySqlDataAdapter("SELECT * FROM " + name_tabel, SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
                GridView2.DataSource = db_data;
                GridView2.DataBind();
            }
            catch {
                valor = "deu pau";
            }
        }

        public void ButtonCadastro_Click(Object sender, EventArgs e)
        {
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "criptomoedas";

            string sigla = Request.Form["sigla"];
            string nome = Request.Form["nome"];
            string algoritmo = Request.Form["algoritmo"];

            try
            {
                SQL_conection.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO {name_tabel} (sigla,nome,algoritmo) VALUES ('{sigla}','{nome}','{algoritmo}');", SQL_conection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Moeda cadastrada com sucesso');", true);
                GeraTabelaMoedas();
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('Erro ao cadastrar. Por favor, preencha todos os campos.');", true);
            }
        }
        }
}

