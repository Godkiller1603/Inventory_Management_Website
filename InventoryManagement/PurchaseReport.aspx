<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseReport.aspx.cs" Inherits="InventoryManagement.PurchaseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 style="text-align:center">Purchase Report</h3>
            <asp:GridView ID="PurReport" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="PurReport_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="Purchase_Product" HeaderText="Purchased Product"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Purchase_Qnty" HeaderText="Purchased Quantity"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Purchase_Date" HeaderText="Purchased Date"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                </Columns>
            </asp:GridView>
            <h4 style="text-align:center">Totol Records : <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></h4>
        </div>
    </form>
</body>
</html>
