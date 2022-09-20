using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Product_ID { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        [StringLength(3,ErrorMessage ="Quantity must be less than 3 digit.")]
        public string Product_Qnty { get; set; }
    }
}