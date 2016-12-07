using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace supermarket2
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                
                    Model.MallUser userCurrent = (Model.MallUser)Session["user"];
                    string UserName = userCurrent.UserName;
                
             

                string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
                OleDbConnection oleConnection = new OleDbConnection(ConnStr);
                oleConnection.Open();

                OleDbCommand mycommand = new OleDbCommand("select CreateTime from OO where UserName='" + UserName + "'", oleConnection);
                labOrderID.Text = mycommand.ExecuteScalar().ToString();
                OleDbCommand mycommand2 = new OleDbCommand("select RealName from OO where UserName='" + UserName + "'", oleConnection);
                labName.Text = mycommand2.ExecuteScalar().ToString();
                OleDbCommand mycommand3 = new OleDbCommand("select Address from OO where UserName='" + UserName + "'", oleConnection);
                LabAddress.Text = mycommand3.ExecuteScalar().ToString();
                OleDbCommand mycommand4 = new OleDbCommand("select UserTel from OO where UserName='" + UserName + "'", oleConnection);
                labTel.Text = mycommand4.ExecuteScalar().ToString();

                oleConnection.Close();
            }

            //Order order = new Order();
            //Model.Orders u = (Model.Orders)Session["order"];
           //// labOrderID.Text = u.CreateTime;
           // labName.Text = u.UserName;
           // LabAddress.Text = u.Address;
           // labTel.Text = u.UserTel;

        }

        protected void btnSurePay_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>alert('付款成功!');</script>");
            //Response.Write("<a herf='javascript:window.opener=null;window.close()'>关闭窗口</a>");
        }
    }
}