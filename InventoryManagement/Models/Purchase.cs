using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Purchase
    {
        public int Product_ID { get; set; }
        [Required(ErrorMessage ="Product name is required.")]
        public string Purchase_Product { get; set; }
        [Required(ErrorMessage ="Product quantity is required.")]
        public string Purchase_Qnty { get; set; }
        public DateTime Purchase_Date { get; set; }
    }
}