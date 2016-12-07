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
using DAL;
using Model;
using System.Data.SqlClient;

namespace supermarket2
{
    
 
    public partial class Cart : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
               // try
               // {
                    this.GridView1.DataBind();
                    Model.MallUser userCurrent = (Model.MallUser)Session["user"];
                    string UserName = userCurrent.UserName;
                    string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
                    OleDbConnection oleConnection = new OleDbConnection(ConnStr);
                    DataTable dt1 = new DataTable();
                    oleConnection.Open();
                    string sql = "select TotalPrice,UserName from Cart where UserName ='" + UserName + "'";
                    OleDbDataAdapter OldDat1 = new OleDbDataAdapter(sql, oleConnection);
                    OldDat1.Fill(dt1);
                    oleConnection.Close();
                    DataRow[] dr = dt1.Select("UserName =UserName");
                    float TotalPricezong = 0;
                    for (int i = 0; i < dr.Length; i++)
                    {

                        //TotalPricezong += Convert.ToInt32(dr[i]["TotalPrice"]);
                        TotalPricezong += Convert.ToSingle(dr[i]["TotalPrice"]);
                        TotalPrice.Text = Convert.ToString(TotalPricezong);
                    }
               //      }
              //  catch (Exception ee)
              //  {
              //      string ex = ee.Message;
              //  }
            }
        
       //     string GoodsID=Session["GoodsID"].ToString();
        }
     
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

       
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {

            Model.MallUser userCurrent = (Model.MallUser)Session["user"];
            string UserName = userCurrent.UserName;
            deliver(UserName);
           // Response .Redirect ("Order.aspx");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //GridViewBind();

            //GView();
        }

      

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
            OleDbConnection db = new OleDbConnection(ConnStr);
            string str = "delete from Cart where GoodsID=" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "";
            OleDbCommand myIns = new OleDbCommand(str, db);
            myIns.Connection.Open();
            int ni = myIns.ExecuteNonQuery();
            myIns.Connection.Close();
            db.Close();
        }

        protected void SqlDataSource1_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource1_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {

        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
        
         }

        public void deliver(string UserName)
        {
            string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
            OleDbConnection oleConnection = new OleDbConnection(ConnStr);
            Orders o = new Orders();

            DataTable dt1 = new DataTable();
            oleConnection.Open();
            string sql = "select GoodsName,NowPrice from Cart where UserName ='" + UserName + "'";
            OleDbDataAdapter OldDat1 = new OleDbDataAdapter(sql, oleConnection);
            OldDat1.Fill(dt1);
            o.GoodsName = dt1.Rows[0][0].ToString();
            //    o.NowPrice = Int32.Parse(dt1.Rows[0][1].ToString());
            o.NowPrice = float.Parse(dt1.Rows[0][1].ToString());
            oleConnection.Close();

            DataTable dt2 = new DataTable();
            oleConnection.Open();
            string sql2 = "select UserName,UserTel,RealName,Address from MallUser where UserName = '" + UserName + "'";
            OleDbDataAdapter OldDat2 = new OleDbDataAdapter(sql2, oleConnection);
            OldDat2.Fill(dt2);
            o.UserName = dt2.Rows[0][0].ToString();
            o.UserTel = dt2.Rows[0][1].ToString();
            o.RealName = dt2.Rows[0][2].ToString();
            o.Address = dt2.Rows[0][3].ToString();

            oleConnection.Close();

            string str = "insert into OO(GoodsName,CreateTime,UserName,RealName,Address,UserTel,NowPrice) values ('" + o.GoodsName + "','" + DateTime.Now.ToString() + "','" + o.UserName + "','" + o.RealName + "','" + o.Address + "','" + o.UserTel + "'," + o.NowPrice + ")";
            OleDbCommand myIns = new OleDbCommand(str, oleConnection);
            myIns.Connection.Open();
            int ni = myIns.ExecuteNonQuery();
            myIns.Connection.Close();
            oleConnection.Close();


            if (ni > 0)
            {
                Response.Write("<script language=javascript>alert('订单提交成功!');</script>");

            }

            else
            {
                Response.Write("<script language=javascript>alert('错误!');</script>");
            }


            string str2 = "delete from Cart where UserName = '" + UserName + "'";
            OleDbCommand myDel = new OleDbCommand(str2, oleConnection);
            myDel.Connection.Open();
            myDel.ExecuteNonQuery();
            myDel.Connection.Close();
            oleConnection.Close();

            Response.Redirect("Order.aspx");  //加上这句就不能显示response.write??????????????????

        }

      }

    }

