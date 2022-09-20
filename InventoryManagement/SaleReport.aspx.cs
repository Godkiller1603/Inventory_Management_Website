using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class SaleReport : System.Web.UI.Page
    {
        InventoryManagementDBEntities Db = new InventoryManagementDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Sale> productList = Db.Sales.OrderByDescending(x => x.Product_ID).ToList();
            SReport.DataSource = productList;
            SReport.DataBind();
            TextBox1.Text = productList.Count.ToString();
        }
        protected void SReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SReport.PageIndex = e.NewPageIndex;
            SReport.DataBind();
        }
    }
}