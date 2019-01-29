using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace mvrapi.Models
{
    public class villageorders
    {
        public long OrderId { get; set; }
        public string Orderdate { get; set; }
        public string OrderStatus { get; set; }
        public string Paymentid { get; set; }
        public string CustomerId { get; set; }
        public string ordertime { get; set; }
        public string orderdeliveredtime { get; set; }
        public string Discount { get; set; }
        public string Remarks { get; set; }
        public string Deliverycharges { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string Totalamount { get; set; }
        public string Deliveryarea { get; set; }
        public string Transactionid { get; set; }
        public string transactionstatus { get; set; }
    }
}