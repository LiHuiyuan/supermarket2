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
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        ArrayList list = new ArrayList();

        private void GetShopBag()
        {

            Session["GoodsID"] = Page.Request.UserHostAddress;

          
        }

     
     public void deliver(int GoodsID)
        {
            string ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Server.MapPath("/App_Data/bbs.mdb");
            OleDbConnection oleConnection = new OleDbConnection(ConnStr);
            DataTable dt1 = new DataTable();

            Carts c = new Carts();
            oleConnection.Open();
            string sql = "select Picture,GoodsID,GoodsName,GoodsFrom,Introduction,NowPrice from goods where GoodsID = " + GoodsID + "";
            OleDbDataAdapter OldDat1 = new OleDbDataAdapter(sql, oleConnection);
            OldDat1.Fill(dt1);
            c.Picture = dt1.Rows[0][0].ToString();
            c.GoodsID = dt1.Rows[0][1].ToString();
            c.GoodsName = dt1.Rows[0][2].ToString();
            c.GoodsFrom = dt1.Rows[0][3].ToString();
            c.Introduction = dt1.Rows[0][4].ToString();
            c.NowPrice = float.Parse(dt1.Rows[0][5].ToString());

            Model.MallUser userCurrent = (Model.MallUser)Session["user"];
            string a = userCurrent.UserName;
            oleConnection.Close();

            //判断当前购物车是否已有该商品，如果有则amount+1，若没有则新添一列
            OleDbCommand comm = oleConnection.CreateCommand();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select count(*) from Cart where GoodsID = " + GoodsID + "";
            OleDbParameter[] param = {
                                   new  OleDbParameter("@GoodsID",c.GoodsID)                                
                                   };
            comm.Parameters.AddRange(param);
            OleDbCommand myCommand = new OleDbCommand(comm.CommandText, oleConnection);
            myCommand.Connection.Open();
            int flag = 1;
            flag = (int)comm.ExecuteScalar();
            myCommand.Connection.Close();
            if (flag == 0)  //若没有则新添一列
            {
                c.Amount = 1;
                c.TotalPrice = c.NowPrice;
                string str = "insert into Cart(UserName,Amount,TotalPrice,Picture,GoodsID,GoodsName,GoodsFrom,Introduction,NowPrice) values ('" + a + "','" + c.Amount + "','" + c.TotalPrice + "','" + c.Picture + "'," + c.GoodsID + ",'" + c.GoodsName + "','" + c.GoodsFrom + "','" + c.Introduction + "'," + c.NowPrice + ")";
                OleDbCommand myIns = new OleDbCommand(str, oleConnection);
                myIns.Connection.Open();
                int ni = myIns.ExecuteNonQuery();
                myIns.Connection.Close();
                oleConnection.Close();

                if (ni > 0)
                {
                    Response.Write("<script language=javascript>alert('已加入购物车!');</script>");
                }

                else
                {
                    Response.Write("<script language=javascript>alert('错误!');</script>");
                }
            }


            else   //若已有此商品，则把此商品对应的amount取出来，+1，再存进此列
            {
                DataTable dt2 = new DataTable();
                oleConnection.Open();
                string sql2 = "select Amount,NowPrice,TotalPrice from Cart where GoodsID = " + GoodsID + "";

                OleDbDataAdapter OldDat2 = new OleDbDataAdapter(sql2, oleConnection);
                OldDat2.Fill(dt2);
                c.Amount = Int32.Parse(dt2.Rows[0][0].ToString());
                c.NowPrice = float.Parse(dt2.Rows[0][1].ToString());
                c.TotalPrice = float.Parse(dt2.Rows[0][2].ToString());
                c.Amount += 1;
                c.TotalPrice = c.Amount * c.NowPrice;

                // c.TotalPrice = c.TotalPrice + c.NowPrice;
                oleConnection.Close();

                string str = "update Cart set Amount = '" + c.Amount + "',TotalPrice='" + c.TotalPrice + " '  where GoodsID = " + GoodsID + "";
                OleDbCommand myIns = new OleDbCommand(str, oleConnection);
                myIns.Connection.Open();
                int ni = myIns.ExecuteNonQuery();
                myIns.Connection.Close();


                if (ni > 0)
                {
                    Response.Write("<script language=javascript>alert('已加入购物车!');</script>");
                }

                else
                {
                    Response.Write("<script language=javascript>alert('错误!');</script>");
                }
            }
     
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnSignin_Click(object sender, EventArgs e)
        {

            Response.Redirect("SignIn2.aspx");
        }


        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            Response.Redirect("LogIn.aspx");
        }

        protected void IbtnMine_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Mine.aspx");
        }

        protected void IbtnCart_Click(object sender, ImageClickEventArgs e)
        {
           // deliver(1); //?????????????????????????????????????????????????????????
            Response.Redirect("Cart.aspx");
        }

        protected void imgbtnChips_Click(object sender, ImageClickEventArgs e)
        {
            if ((Model.MallUser)Session["user"] == null)
            {
                Response.Write("<script language=javascript>alert('请先登录!');</script>");
            }
            else
            {
                deliver(1);  //薯片
            }
        }

        protected void imgbtnStar_Click(object sender, ImageClickEventArgs e)
        {
            if ((Model.MallUser)Session["user"] == null)
            {
                Response.Write("<script language=javascript>alert('请先登录!');</script>");
            }
            else
            {
                deliver(3);  //蛋奶星星
            }
        }

        protected void imgbtnRICE_Click(object sender, ImageClickEventArgs e)
        {
            if ((Model.MallUser)Session["user"] == null)
            {
                Response.Write("<script language=javascript>alert('请先登录!');</script>");
            }
            else
            {
                deliver(5); //蛋炒饭
            }
        }
  
        protected void imgbtnCola_Click(object sender, ImageClickEventArgs e)
        {
            if ((Model.MallUser)Session["user"] == null)
            {
                Response.Write("<script language=javascript>alert('请先登录!');</script>");
            }
            else
            {
                deliver(2); //可口可乐
            }
        }

        protected void imgbtnTomato_Click(object sender, ImageClickEventArgs e)
        {
            if ((Model.MallUser)Session["user"] == null)
            {
                Response.Write("<script language=javascript>alert('请先登录!');</script>");
            }
            else
            {
                deliver(4); //番茄酱
            }
        }

     
       

        
    }
}