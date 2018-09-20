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
            valor = rodaQuery();
            GeraTabelaHardware("CPU");
         //   Button1.Click(sender, e);
        }

        //   MySqlConnection SQL_koneksi = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PWD=;");
        //   String nama_tabel = "twitter_clone.usuarios";
        //   MySqlDataAdapter db_select;
        //  DataSet db_data;
        //   MySqlCommand SQL_cmd;
        //   string Query;


        public string rodaQuery()
        {
            string sql = " SELECT senha FROM usuarios  ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password='';database=twitter_clone;SslMode=none");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            string temp = "";
            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temp = reader.GetString("senha");

            }
            con.Close();
            return temp;

            
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


        public void GeraTabelaHardware(String filtro)
        {//"SERVER=localhost;PORT=3306;UID=root;PWD=;"
            MySqlConnection SQL_conection = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none");
            String name_tabel = "hardwares";
            MySqlDataAdapter db_select;
            DataSet db_data;

          //  filtro = Request.Form["selectHardware"];
          //  MySqlCommand SQL_cmd;
          //  string Query;

            try
            {
                db_select = new MySqlDataAdapter("SELECT marca, modelo, consumo, preco, ano FROM " + name_tabel + " WHERE tipo='" + filtro + "'", SQL_conection);
                db_data = new System.Data.DataSet();
                db_select.Fill(db_data, name_tabel);
               // db_select.Fill(db_data);
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







    }
}