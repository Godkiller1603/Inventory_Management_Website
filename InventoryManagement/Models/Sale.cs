using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Sale
    {
        public int Product_ID { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public string Sale_Product { get; set; }
        [Required(ErrorMessage = "Product quantity is required.")]
        public string Sale_Qnty { get; set; }
        public DateTime Sale_Date { get; set; }
    }
}