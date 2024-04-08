using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class OutExecle
    {
        public static DataTable OutTable(string sqlString, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlString, connectionstring);
                    sqlDataAdapter.Fill(ds);
                }
                catch (SqlException e)
                {
                    Console.WriteLine("提示:" + e.ToString());
                }
                finally
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (ds!=null)
                {

                    if (ds.Tables.Count > 0)
                        return ds.Tables[0];
                    else
                        return null;
                }
                return null;
            }
        }

    }
}
