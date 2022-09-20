<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleReport.aspx.cs" Inherits="InventoryManagement.SaleReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 style="text-align:center">Sale Report</h3>
            <asp:GridView ID="SReport" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="SReport_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Sale_Product" HeaderText="Sold Product"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Sale_Qnty" HeaderText="Sold Quantity"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Sale_Date" HeaderText="Sold Date"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                </Columns>
            </asp:GridView>
            <h4 style="text-align:center">Totol Records : <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></h4>
        </div>
    </form>
</body>
</html>
