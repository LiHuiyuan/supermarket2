<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="supermarket2.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
    <title>尊敬的凯源汪，请登录</title>
 <link href="Styles/bootstrap.css" rel='stylesheet' type='text/css' />
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<!-- Custom Theme files -->
<link href="Styles/style.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<!--webfont-->
<%--<link href='http://fonts.useso.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>--%>
<script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
     <link rel="icon" href="~/image/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="~/image/faviicon.ico" type="image/x-icon" /> 
</head>
<body>  <div class="sales"></div>
    <div class="container">
  <div class="about_top img">
    
     <div class="col-md-9 content_right">
 
  <div class ="register">
     <form runat="server"> 
      <div class ="left col-md-6 login-right" title="用户登录">          
          
               <h3>已有账号，请登录KY</h3>
          <span>
               <asp:Label  ID="UserName" runat="server" Text="用户名" ></asp:Label>
           </span>           
            <div class ="inputtxt"> <asp:TextBox ID="Name" runat="server" ></asp:TextBox>     </div>          
       
            <span>
            <asp:Label ID="UserPassword" runat="server" Text="密&nbsp;码"></asp:Label>
             </span>                      
          <asp:TextBox ID="Password" runat="server" TextMode="Password" ></asp:TextBox>               
          
          <div>  
          <asp:Button  class="btn" ID="Btnlogin" runat="server" OnClick="Btnlogin_Click" Text="登录" />
               &nbsp;
            <asp:Button class="btn" ID="Back" runat="server" OnClick="Back_Click" Text="返回"  />
        </div>
         </div> 
       
      <div class="col-md-6 login-left">           
              <div class="reg h3"><p></p>还没有账号？ </div>
             <div class="reg"><asp:Button class="btn" ID="btnSignIn" runat="server" OnClick="SignIn_Click" Text="点击注册>" /></div>
          
      </div>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>   
     </form> 
   </div>
   </div>
   </div>
</div>

</body>
</html>
