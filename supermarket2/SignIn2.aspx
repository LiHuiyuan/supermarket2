<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn2.aspx.cs" Inherits="supermarket2.SignIn2" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>从今日起成为一只凯源狗</title>
     <link rel="icon" href="~/image/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="~/image/faviicon.ico" type="image/x-icon" /> 
     <link href="Styles/bootstrap.css" rel='stylesheet' type='text/css' />
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
   <div class ="register">
      <div class ="regreg col-md-6" title="用户注册"> 
      <h3> 用户注册</h3>
            
     <div class="reg-left">
           <span>
            <asp:Label  ID="UserName" runat="server" Text="用户名" ></asp:Label>
          </span>
           <asp:TextBox ID="tbxName" runat="server" AutoPostBack="True">请输入用户名</asp:TextBox>
         <span>
            <asp:Label ID="Label2" runat="server" Text="手机号" ></asp:Label>
           </span>
          <asp:TextBox ID="UserTel" runat="server" ></asp:TextBox>
          <span>    
            <asp:Label ID="UserPassword" runat="server" Text="密  码" ></asp:Label>
          </span>  
          <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" ></asp:TextBox>
          <asp:Button class="btn" ID="btnRsgister" runat="server" OnClick="btnRsgister_Click" Text="注册" />
            <asp:Button class="btn" ID="btnExit" runat="server" Text="取消"  OnClick="btnExit_Click" />
         </div>

        <div class="reg-right"> 
               <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
   
     </div>
  </div>
</div>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</body>
</html>
