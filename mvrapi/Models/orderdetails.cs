using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvrapi.Models
{
    public class orderdetails
    {
        public long orderid { get; set; }
        public string Productid { get; set; }
        public string Quantity { get; set; }
        public string OrderdetailId { get; set; }

    }
}