using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.OleDb;
using Model;

namespace DAL
{
    public class Sign
    {
        public bool Reg(MallUser u)
        {
            // string db = Server.MapPath("/App_Data/bbs.mdb");
            //string strConn = "Data Source=" + db + ";Provider=Microsoft.Jet.OLEDB.4.0";
            OleDbConnection oleConnection = new OleDbConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            OleDbCommand comm = oleConnection.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from MallUser where UserName like @username";
            OleDbParameter[] param = {
                                   new  OleDbParameter("@username",u.UserName)                                
                                   };
            comm.Parameters.AddRange(param);
            // string strCmd = "select count(*) from MallUser where UserName like @username";

            //oleConnection.ConnectionString = strConn;
            OleDbCommand myCommand = new OleDbCommand(comm.CommandText, oleConnection);
            myCommand.Connection.Open();
            int flag = 1;
        
            flag = (int)comm.ExecuteScalar();
            myCommand.Connection.Close();
            if (flag == 0)
            {
                //string str = "insert into MallUser ([UserID],[UserName],[PassWord],[UserTel]) values ('" + u.UserID + "','" + u.UserName + "','" + u.Password + "','" + u.UserTel + "')";
                string str = "insert into MallUser ([UserName],[PassWord],[UserTel]) values ('" + u.UserName + "','" + u.Password + "','" + u.UserTel + "')";

                //  Label3.Text = str;
                OleDbCommand myIns = new OleDbCommand(str, oleConnection);
                myIns.Connection.Open();
                myIns.ExecuteNonQuery();
                myIns.Connection.Close();
                oleConnection.Close();
                return true;
                //  Session["username"] = tbxName.Text;
                //Session["UserTel"] = UserTel.Text;
                //  Response.Redirect("MainForm.aspx");

            }
            else
                return false;
        }
    }
}