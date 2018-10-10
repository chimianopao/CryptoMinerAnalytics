﻿using System;
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
        private string m_strSortExp = "Estado";
        private SortDirection m_SortDirection;

        protected void Page_Load(object sender, EventArgs e)
        {
            GeraTabelaCidades();
           // Geragrafico();
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


        //public void Geragrafico()
        //{
        //    DataTable dt = new DataTable();
        //    using (MySqlConnection cn = new MySqlConnection("host=localhost;user=root;password='';database=cripto;SslMode=none"))
        //    {
        //        string sql = "select * from custoenergia";
        //        using (MySqlCommand cmd = new MySqlCommand(sql, cn))
        //        {
        //            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
        //            {
        //                da.Fill(dt);
        //            }

        //        }
        //    }
        //    Chart1.DataSource = dt;
        //    Chart1.DataBind();
        //}


    }
}

