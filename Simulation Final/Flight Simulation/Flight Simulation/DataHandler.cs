﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Flight_Simulation
{
    class DataHandler
    {//Data Source=Localhost\SQLEXPRESS;Initial Catalog=Specifications;Integrated Security=True
        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

        public DataHandler()
        {
            connection.DataSource = @"Localhost\SQLEXPRESS";
            connection.InitialCatalog = "Specifications";
            connection.IntegratedSecurity = true;
        }

        public DataSet ReadData(string tblName)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT * FROM {0}", tblName);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, tblName);
                adapter.Fill(rawData, tblName);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return rawData;
        }
        public DataSet GetData(int ID)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT * FROM Inventory WHERE InventoryID = {0}",ID);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, "Inventory");
                adapter.Fill(rawData, "Inventory");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return rawData;
        }
    }
}