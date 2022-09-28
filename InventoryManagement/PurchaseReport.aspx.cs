using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class PurchaseReport : System.Web.UI.Page
    {
        InventoryManagementDBEntities Db = new InventoryManagementDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Purchase> productList = Db.Purchases.OrderByDescending(x => x.Product_ID).ToList();
            PurReport.DataSource = productList;
            PurReport.DataBind();
            TextBox1.Text = productList.Count.ToString();
        }

        protected void PurReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PurReport.PageIndex = e.NewPageIndex;
            PurReport.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Purchase/DisplayPurchase");
        }
    }
}