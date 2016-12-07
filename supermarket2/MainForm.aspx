<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="supermarket2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>逛超市</title>
    <link rel="icon" href="~/image/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="~/image/faviicon.ico" type="image/x-icon" /> 
     <link href="Styles/bootstrap.css" rel='stylesheet' type='text/css' />
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<!-- Custom Theme files -->
<link href="Styles/style.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainform">
            <div class="men">
            <asp:ImageButton class="img" ID="IbtnCart" runat="server" ImageUrl="~/image/cart.jpg" PostBackUrl="~/Cart.aspx" Width="40px" OnClick="IbtnCart_Click"  />
            <asp:ImageButton class="img" ID="IbtnMine" runat="server" ImageUrl="~/image/mine.png" Width="40px"  PostBackUrl="~/Mine.aspx" OnClick="IbtnMine_Click" />
           </div>
         
              <div class="menu">																
			  <a href="#" class="right_bt img" id="activator"><img src="image/menu.png" alt=""/></a>
				<div class="box" id="box">
				   <div class="box_content_center" style="padding: 10px">
					   <div class="menu_box_list">
						   <ul>
							   <li><a href="SignIn2.aspx">注册</a></li>
							   <li class="active"><a href="LogIn.aspx">登录</a></li> 
						   </ul>
						</div>
						<a class="boxclose" id="boxclose"><img src="image/close.png" alt=""/></a>
					  </div>                
					</div>
			                 <script type="text/javascript">
			                     var $ = jQuery.noConflict();
			                     $(function () {
			                         $('#activator').click(function () {
			                             $('#box').animate({ 'left': '0px' }, 500);
			                         });
			                         $('#boxclose').click(function () {
			                             $('#box').animate({ 'left': '-2300px' }, 500);
			                         });
			                     });
			                     $(document).ready(function () {

			                         //Hide (Collapse) the toggle containers on load
			                         $(".toggle_container").hide();
			                         //Switch the "Open" and "Close" state per click then slide up/down (depending on open/close state)
			                         $(".trigger").click(function () {
			                             $(this).toggleClass("active").next().slideToggle("slow");
			                             return false; //Prevent the browser jump to the link anchor
			                         });
			                     });
								</script>
		 </div> 	
                 <div class="search img"> <asp:TextBox class="img" ID="Search" height="40px" Width="300px" runat="server"/>
                  <asp:ImageButton class="down" ID="BtnSearch" runat="server" style="" height="30px" ImageUrl="~/image/search.jpg" ValidateRequestMode="Disabled" />
            </div>
   
          <asp:ImageButton ID="imgbtnChips" runat="server" Height="127px" OnClick="imgbtnChips_Click" style="margin-top: 10px; margin-right: 0px; margin-top: 184px; margin-bottom: 4px" Width="69px" ToolTip="薯条" />
          <asp:ImageButton ID="imgbtnTomato" runat="server" Height="81px" OnClick="imgbtnTomato_Click" style="margin-left: 370px; margin-top: 0px; margin-bottom: 126px" Width="43px" ToolTip="番茄" />
          <asp:ImageButton ID="imgbtnCola" runat="server" Height="61px" OnClick="imgbtnCola_Click" style="margin-left: 114px; margin-right: 0px; margin-top: 0px; margin-bottom: 2px" Width="32px" ToolTip="可乐" />
          <asp:ImageButton ID="imgbtnRICE" runat="server" Height="71px" OnClick="imgbtnRICE_Click" style="margin-left: 101px; margin-right: 1px; margin-top: 19px; margin-bottom: 3px" Width="66px" ToolTip="米" />
          <asp:ImageButton ID="imgbtnStar" runat="server" Height="316px" OnClick="imgbtnStar_Click" style="margin-left: 40px; margin-right: 371px; margin-top: 7px; margin-bottom: 4px" Width="109px" ToolTip="蛋奶星" />
    
       
     </div>
    </form>
</body>
</html>
