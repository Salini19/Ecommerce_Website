using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Website.Models
{
    public class EcommerceModel
    {
        public int productid { get; set; }
        public string productname { get; set; }

        public float price { get; set; }
        public int Quantity { get; set; }
        public float Bill { get; set; }
    }
}