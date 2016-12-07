using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using DAL;
using Model;

namespace supermarket2
{
    public partial class SignIn2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRsgister_Click(object sender, EventArgs e)
        {
            Sign si = new Sign();
            MallUser u = new MallUser();
            //u.UserID自增长?????????????????????????????????????????????
        //    u.UserID = "2";
            u.UserName = tbxName.Text;
            u.Password = tbxPassword.Text;
            u.UserTel = UserTel.Text;
          

            if (si.Reg(u))
            {
                //put in session,MainForm.aspx;
                Session["User"] = u;
                Response.Redirect("MainForm.aspx");
            }
            else {
                Label3.Text = "对不起！用户名已占用，请选择其他用户名！";
                tbxName.Text = "";
                UserTel.Text = "";
                tbxPassword.Text = "";
             
              
            }
          
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }
        
    }
}