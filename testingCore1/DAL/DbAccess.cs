using testingCore1.Models;
using testingCore1.Repositoris;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace testingCore1.DAL
{
    public class DbAccess
    {
        private readonly string _connectionString;
        public DbAccess(IConfiguration configuration)
        {
           
            _connectionString = configuration.GetConnectionString("Connection");
           
        }
        
        public int int_Process(string query, string[] parametername, string[] parametervalue)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parametername.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                    }

                    con.Open();
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    int id = (int)returnParameter.Value;
                    return id;
                }
            }
        }
        public DataSet Ds_Process(string Storp, string[] parametername, string[] parametervalue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Storp, con))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < parametername.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                        }

                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        da.Dispose();
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable Dt_Process(string Storp, string[] parametername, string[] parametervalue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Storp, con))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < parametername.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                        }

                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        da.Dispose();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        

    }
}
