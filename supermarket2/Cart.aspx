<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="supermarket2.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>一言不合就开购物车</title>
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
<body >  
    <form id="form1" runat="server">
     <div class="sales "></div>
         <div class="container">
             <div class="about_top img">
       <div class="cart_box">
      <div class ="cart_table"> 
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CartID" DataSourceID="SqlDataSource1"  OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating1" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="Picture" HeaderText="Picture" SortExpression="Picture" Visible="False" />
                                          
           
                <asp:BoundField DataField="GoodsName" HeaderText="商品名称" SortExpression="GoodsName" ReadOnly="True" ValidateRequestMode="Disabled" />
            <asp:ImageField DataImageUrlField="Picture"  ControlStyle-Width="50px" >
<ItemStyle Width="30px"></ItemStyle>
                </asp:ImageField>
                                                    
               
                <asp:BoundField DataField="NowPrice" HeaderText="单价" SortExpression="NowPrice" ReadOnly="True" />
                <asp:BoundField DataField="CartID" HeaderText="CartID" InsertVisible="False" ReadOnly="True" SortExpression="CartID" Visible="False" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" Visible="False" />
                <asp:BoundField DataField="Amount" HeaderText="数量" SortExpression="Amount" />
                <asp:BoundField DataField="TotalPrice" HeaderText="总价" SortExpression="TotalPrice" ReadOnly="True" />
                <asp:BoundField DataField="GoodsID" HeaderText="GoodsID" SortExpression="GoodsID" Visible="False" />
                <asp:BoundField DataField="GoodsFrom" HeaderText="GoodsFrom" SortExpression="GoodsFrom" Visible="False" />
                  
                <asp:TemplateField ShowHeader="False">

                    <ItemTemplate>

     <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" HeaderText="操作" CommandName="Delete" OnClientClick="return confirm('确定要删除吗？')"

                            Text="删除"></asp:LinkButton>
                       
                    </ItemTemplate>

                </asp:TemplateField>                        
           
            </Columns>
        </asp:GridView>
           <table class="">
            <tr>
                <td class="">总价:</td>
                <td>
                    <asp:Label ID="TotalPrice" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
      </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [Cart] WHERE ([UserName] = ?)" DeleteCommand="DELETE FROM [Cart] WHERE [CartID] = ?" InsertCommand="INSERT INTO [Cart] ([CartID], [UserName], [Amount], [TotalPrice], [GoodsID], [GoodsName], [GoodsFrom], [Introduction], [NowPrice], [Picture]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" OnDeleted="SqlDataSource1_Deleted" OnSelecting="SqlDataSource1_Selecting1" UpdateCommand="UPDATE [Cart] SET [Amount] = ?, [Amount] = ?, [TotalPrice] = ?, [GoodsID] = ?, [GoodsName] = ?, [GoodsFrom] = ?, [Introduction] = ?, [NowPrice] = ?, [Picture] = ? WHERE [GoodsID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="original_CartID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CartID" Type="Int32" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="Amount" Type="Int32" />
                <asp:Parameter Name="TotalPrice" Type="String" />
                <asp:Parameter Name="GoodsID" Type="Int32" />
                <asp:Parameter Name="GoodsName" Type="String" />
                <asp:Parameter Name="GoodsFrom" Type="String" />
                <asp:Parameter Name="Introduction" Type="String" />
                <asp:Parameter Name="NowPrice" Type="String" />
                <asp:Parameter Name="Picture" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="UserName2" SessionField="UserName" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="Amount" Type="Int32" />
                <asp:Parameter Name="TotalPrice" Type="String" />
                <asp:ControlParameter ControlID="GridView1" Name="GoodsID" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter Name="GoodsName" Type="String" />
                <asp:Parameter Name="GoodsFrom" Type="String" />
                <asp:Parameter Name="Introduction" Type="String" />
                <asp:Parameter Name="NowPrice" Type="String" />
                <asp:Parameter Name="Picture" Type="String" />
                <asp:Parameter Name="original_CartID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>

       
       <div class="cart_btn">    
             <asp:Button class="btn" ID="btnPay" runat="server"  OnClick="btnPay_Click"  Text="结账" />
           <asp:Button class="btn" ID="btnBack" runat="server" OnClick="btnBack_Click" Text="返回"/>
            </div >    
    </div></div>
  </div>

    </form>
</body>
</html>
