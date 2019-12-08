﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace siddhartha_24_11_19.DAL
{ 
   
    public class DataAdapter
    {
        ConnectionString connectionString = new ConnectionString();
        public DataAdapter() { 
        }
        public bool Insert(SqlParameter[] param, string command)
        {
            bool f = false;
            using (SqlConnection con = new SqlConnection(connectionString.connect()))
            {
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Connection = con;
                    con.Open();
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        f = true;
                    }
                }
            }
            return f;
        }
        public int InsertSP(SqlParameter[] param, string command)
        {
            int f = 0;
            using (SqlConnection con = new SqlConnection(connectionString.connect()))
            {
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        f = a;
                    }
                }
            }
            return f;
        }
        public DataTable FetchAll(string command)
        {
            using (SqlConnection con = new SqlConnection(connectionString.connect()))
            {
                using (SqlCommand cmd = new SqlCommand(command))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {

                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        using (DataTable dt = new System.Data.DataTable())
                        {
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public DataTable FetchAllSP(String command)
        {
            using (SqlConnection con = new SqlConnection(connectionString.connect()))
            {
                using (SqlCommand cmd = new SqlCommand(command))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        using (DataTable dt = new System.Data.DataTable())
                        {
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public DataTable FetchByParameter(SqlParameter[] param, string command)
        {
            using (SqlConnection con = new SqlConnection(connectionString.connect()))
            {

                using (SqlCommand cmd = new SqlCommand(command))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        DataTable dt = new System.Data.DataTable();
                        for (int i = 0; i < param.Length; i++)
                        {
                            cmd.Parameters.Add(param[i]);
                        }
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public int getLastID(String columnName, String tableName)
        {

            DataTable dt = new DataTable();
            int value = 0;
            string command = "SELECT MAX(" + columnName + ") AS LastID FROM " + tableName;
            dt = this.FetchAll(command);
            string gValue = dt.Rows[0]["LastID"].ToString();
            switch (gValue)
            {
                case (""):
                    value = 0;
                    break;
                default:
                    value = Int32.Parse(gValue);
                    break;
            }
            return value;
        }
    }
}