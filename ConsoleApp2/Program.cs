using MiniExcelLibs;
using System.Data;
using System.Data.SqlClient;

string table = "PlcDetailInfo";
string connectionstring = "Data Source=10.10.131.1,1433;Initial Catalog=ZJNWMS;Persist Security Info=True;User ID=sa;Password=Aa123456;";
string sql = $"SELECT * from {table}";

DataTable dt = OutTable(sql, connectionstring);
string path = string.Format(@"F:\{0}.xlsx", table);
MiniExcel.SaveAs(path, dt, overwriteFile: true);
Console.WriteLine("备份完成");


  DataTable OutTable(string sqlString, string connectionstring)
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
        if (ds != null)
        {

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        return null;
    }
}
