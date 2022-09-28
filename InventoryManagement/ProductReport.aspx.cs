using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagement
{
    public partial class ProductReport : System.Web.UI.Page
    {
        InventoryManagementDBEntities Db = new InventoryManagementDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> productList = Db.Products.OrderByDescending(x => x.Product_ID).ToList();
            ProReport.DataSource = productList;
            ProReport.DataBind();
            TextBox1.Text = productList.Count.ToString();   
        }

        protected void ProReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProReport.PageIndex = e.NewPageIndex;
            ProReport.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Home/Index");
        }
    }
}