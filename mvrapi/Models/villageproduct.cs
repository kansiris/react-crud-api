using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvrapi.Models
{
    public class villageproduct
    {
        public int id { get; set; }
        public string ProductId { get; set; }
        public string Productname { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string weight { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Remarks { get; set; }
        public string Available { get; set; }
        public string HSNcode { get; set; }
        public string SGST { get; set; }
        public string CGST { get; set; }
        public string Discount { get; set; }
        public string brand { get; set; }
        public string Image { get; set; }
        public string Manfacturedate { get; set; }
        public string Expirydate { get; set; }
        public string createdate { get; set; }
        public string Updateddate { get; set; }
    }
}