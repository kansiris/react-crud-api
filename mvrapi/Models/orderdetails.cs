using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvrapi.Models
{
    public class orderdetails
    {
        public long orderdetailid { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public string orderid { get; set; }

    }
}