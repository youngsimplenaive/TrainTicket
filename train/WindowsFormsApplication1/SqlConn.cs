using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class SqlConn
    {
        private const string ConnString = "Data Source=CZL;integrated security=true;database=train;";
        private SqlConnection sqlconn = new SqlConnection(ConnString);
        public SqlDataReader GetDataReader(string StrSql)//数据查询    
        {
            //当连接处于打开状态时关闭,然后再打开,避免有时候数据不能及时更新    
            if (sqlconn.State == ConnectionState.Open)
            {
                sqlconn.Close();
            }
            try
            {
                sqlconn.Open();
                SqlCommand SqlCmd = new SqlCommand(StrSql, sqlconn);
                SqlDataReader SqlDr = SqlCmd.ExecuteReader();
                return SqlDr;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                //sqlconn.Close();
            }
        }



        //执行非查询命令sql命令
        public int ExecuteSQL(string sqlstring)
        {
            if (sqlconn.State == ConnectionState.Open)
            {
                sqlconn.Close();
            }
            int count = -1;
            sqlconn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlstring, sqlconn);
                count = cmd.ExecuteNonQuery();
            }
            catch
            {
                count = -1;
            }
            finally
            {
                sqlconn.Close();
            }
            return count;
        }

        //关闭数据库
        public void close()
        {
            sqlconn.Close();
        }
    }
}
