using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace DAL
{
    /// <summary>
    /// 判断用户是否可以登录
    /// </summary>
    public class Log
    {

        public bool CheckUser(string username, string password)
        {
            OleDbConnection oleConnection = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            oleConnection.Open();
            OleDbCommand comm = oleConnection.CreateCommand();
            comm.CommandType = CommandType.Text;
           // OleDbCommand mycommand = new OleDbCommand("select * from MallUser where UserName=@username and Password=@password",oleConnection);
            comm.CommandText = "select UserName from MallUser where UserName=@username and Password=@password"; 
            OleDbParameter[] param = {
                                   new  OleDbParameter("@username",username),
                                   new  OleDbParameter("@password",password)
                                   };
            comm.Parameters.AddRange(param); 
            int count = Convert.ToInt32(comm.ExecuteScalar());
            oleConnection.Close();
            if (count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}