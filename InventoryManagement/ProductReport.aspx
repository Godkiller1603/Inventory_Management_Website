<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductReport.aspx.cs" Inherits="InventoryManagement.ProductReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 style="text-align:center">Product Report</h3>
            <asp:GridView ID="ProReport" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="ProReport_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Product_Name" HeaderText="Product Name"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Product_Qnty" HeaderText="Product Quantity"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                </Columns>
            </asp:GridView>
            <h4 style="text-align:center">Totol Records : <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None" ></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Back" />
            </h4>
        </div>
    </form>
</body>
</html>
