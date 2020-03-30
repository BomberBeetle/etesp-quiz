using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class QuizDBConnect
    {
        static public DataTable Query(string userID, string pass, string dbname, string cmd )
        {
            using (
                SqlConnection connection = new SqlConnection(string.Format("User ID={0}; Password={1}; Initial Catalog={2}; Persist Security Info=True;Data Source=", userID, pass, dbname) + Environment.MachineName)
                )
            using (
                SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection)
                )
            {
            try
            {
                connection.Open();
                DataTable retorno = new DataTable();
                adapter.Fill(retorno);
                return retorno;
            }
            catch
            {
                return null;
            }
               
            }
        }

        static public DataSet QueryMultiple(string userID, string pass, string dbname, string[] cmds)
        {
            using (
                SqlConnection connection = new SqlConnection(string.Format("User ID={0}; Password={1} Initial Catalog={2}; Persist Security Info=True;Data Source=", userID, pass, dbname) + Environment.MachineName)
                )
            using (
                SqlDataAdapter adapter = new SqlDataAdapter("",connection)
                )
            {
                try
                {
                    DataSet retorno = new DataSet();
                    connection.Open();
                    foreach (string cmd in cmds)
                    {
                        adapter.SelectCommand = new SqlCommand(cmd);
                        DataTable queryTable = null;
                        adapter.Fill(queryTable);
                    }
                    return retorno;
                }
                catch
                {
                    return null;
                }
            }
        }
    }

