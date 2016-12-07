using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;

namespace supermarket2
{
    public partial class Mine : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    Model.MallUser userCurrent = (Model.MallUser)Session["user"];
                    UserName.Text = userCurrent.UserName;
                }
                catch (Exception ee)
                {
                    UserName.Text = ee.Message;
                }

                string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
                OleDbConnection oleConnection = new OleDbConnection(ConnStr);
                oleConnection.Open();
                
                OleDbCommand mycommand = new OleDbCommand("select UserTel from MallUser where UserName='" + UserName.Text + "'", oleConnection);
                UserTel.Text = mycommand.ExecuteScalar().ToString();
                OleDbCommand mycommand2 = new OleDbCommand("select UserID from MallUser where UserName='" + UserName.Text + "'", oleConnection);
                UserID.Text = mycommand2.ExecuteScalar().ToString();
                OleDbCommand mycommand3 = new OleDbCommand("select RealName from MallUser where UserName='" + UserName.Text + "'", oleConnection);
                RealName.Text = mycommand3.ExecuteScalar().ToString();
                OleDbCommand mycommand4 = new OleDbCommand("select Address from MallUser where UserName='" + UserName.Text + "'", oleConnection);
                Address.Text = mycommand4.ExecuteScalar().ToString();

                oleConnection.Close();
            }
            
            
        }

        protected void btnIntroduction_Click(object sender, EventArgs e)
        {
            //获取被触发的Button对象  
            Button b = (Button)sender;
           
                //激活View1  
                MultiView1.SetActiveView(View1);
           
        }
        protected void btnMyOrder_Click(object sender, EventArgs e)
        {
            //获取被触发的Button对象  

            MultiView1.SetActiveView(View2);
        }

       // protected void btnBack_Click(object sender, EventArgs e)
       // {
       //     Response.Redirect("MainForm.aspx");
      //  }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
            OleDbConnection oleConnection = new OleDbConnection(ConnStr);
            Model.MallUser userCurrent = (Model.MallUser)Session["user"];
            string UserName = userCurrent.UserName;
             string Str = "update MallUser set RealName = '"+ RealName.Text +"',Address='"+ Address.Text +" ' where UserName ='" + UserName + "'";
　　        
                OleDbCommand myIns = new OleDbCommand(Str, oleConnection);
                myIns.Connection.Open();
                int ni = myIns.ExecuteNonQuery();
                myIns.Connection.Close();
                if (ni > 0)
                {
                    Response.Write("<script language=javascript>alert('恭喜您，信息保存成功!');</script>");
                }
          
               
               
        }
    }
}