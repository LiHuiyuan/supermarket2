using Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
namespace supermarket2
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String strPath = System.Web.HttpContext.Current.Server.MapPath("BBS.mdb");
        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            if (Name.Text == "" || Password.Text == "")
            {
                Response.Write("<script language=javascript>alert('用户名或密码不能为空！');</script>");
                return;
            }
            
            Log lo = new Log();
            if (lo.CheckUser(Name.Text, Password.Text))
            {
                Session["UserName"] = Name.Text;
                MallUser u = new MallUser();
                u.UserName = Name.Text;
                // u.Password = Password.Text;
                Session["user"] = u;
                // Session["user"] = Name.Text;


                if (Session["user"] != null)
                {
                    MallUser user = (MallUser)Session["user"];
                   // Response.Write(user.UserName);
                  //  Response.Write(user.Password);
                }
                Response.Redirect("MainForm.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('用户名或密码错误！');</script>");
                Name.Text = "";
                Password.Text = "";
                Name.Focus();
            }
            
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
            
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn2.aspx");
        }

      
   
    }
}


