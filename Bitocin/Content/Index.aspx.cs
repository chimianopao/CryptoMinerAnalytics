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
            string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
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

            string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
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

            string ConnectString = "host=localhost;user=root;password='';database=cripto;SslMode=none";
            string QueryString = "select cidade from custoenergia;";

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