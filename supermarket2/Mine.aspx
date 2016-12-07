<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mine.aspx.cs" Inherits="supermarket2.Mine" %>  
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title>个人中心</title>  
   <link href="Styles/bootstrap.css" rel='stylesheet' type='text/css' />
     <link rel="icon" href="~/image/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="~/image/faviicon.ico" type="image/x-icon" /> 
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<!-- Custom Theme files -->
<link href="Styles/style.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<!--webfont-->
<%--<link href='http://fonts.useso.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>--%>
<script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
</head>  
<body  class="logsign" >  
    <form id="form1" runat="server">  
  <div class="sales"></div>
  <div class="about_top img">
      <div class="mine_box">
        <asp:Button ID="btnIntroduction" runat="server" BorderWidth="0" Text="个人信息" OnClick="btnIntroduction_Click" />  
        <asp:Button ID="btnWelcome" runat="server" BorderWidth="0" Text="我的订单" OnClick="btnMyOrder_Click" />  
        <table >  
            <tr valign="top">  
                <td >  
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">  
                        <asp:View ID="View1" runat="server">  
                            <table align="center">
                                <tr>
                                    <td class="auto-style5">用户ID</td>
                                    <td>
                                        <asp:TextBox ID="UserID" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>用户名</td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"  OnTextChanged="UserName_TextChanged">123</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >绑定手机</td>
                                    <td>
                                        <asp:TextBox ID="UserTel" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >收货人姓名</td>
                                    <td>
                                        <asp:TextBox ID="RealName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>收货地址</td>
                                    <td>
                                        <asp:TextBox ID="Address" runat="server" ></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                       <div style="float:right"> <asp:Button CssClass ="btn" ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                                   </div> </td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td >
                                        <asp:HyperLink ID="hylBack" runat="server" NavigateUrl="~/MainForm.aspx">返回首页</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>  
                        <asp:View ID="View2" runat="server">  
                            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [OO]"></asp:SqlDataSource>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MainForm.aspx">返回首页</asp:HyperLink>

                        </asp:View>  
                    </asp:MultiView>  
                   
                </td>  
            </tr>  
        </table>  
          </div>
    </div>  
    </form>  
</body>  
</html>  