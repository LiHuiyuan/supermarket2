<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="supermarket2.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>您有一个单要订</title>
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
<body>
    <form id="form1" runat="server">
   <div class="sales "></div>
         <div class="container1">
             <div class="about_top img">
       <div class="order">
      <div class ="cart_table"> 
    
        <table aria-atomic="False" border="0" class="auto-style1" >
            <tr>
                <td >订单编号</td>
                <td >
                    <asp:Label ID="labOrderID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td >商品信息</td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td  colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:BoundField DataField="GoodsName" HeaderText="GoodsName" SortExpression="GoodsName" />
                            <asp:BoundField DataField="NowPrice" HeaderText="NowPrice" SortExpression="NowPrice" />
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" Visible="False" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="SELECT [GoodsName], [NowPrice], [UserName], [ID] FROM [OO] WHERE ([UserName] = ?)">
                        <SelectParameters>
                            <asp:SessionParameter Name="UserName2" SessionField="UserName" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td >收货人姓名</td>
                <td >
                    <asp:Label ID="labName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>收货地址</td>
                <td>
                    <asp:Label ID="LabAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>联系电话</td>
                <td>
                    <asp:Label ID="labTel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td ><asp:HyperLink ID="hylBack" runat="server" NavigateUrl="~/MainForm.aspx">返回首页</asp:HyperLink></td>
                <td >
                    <asp:Button CssClass="btn" ID="btnSurePay" runat="server" OnClick="btnSurePay_Click"  Text="确认付款" />
                </td>
                
            </tr>
        </table>
     
    </div>
           </div>
                 </div>
             </div>
        
    </form>
</body>
</html>
