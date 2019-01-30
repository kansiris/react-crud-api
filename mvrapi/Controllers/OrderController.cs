using mvrapi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvrapi.Controllers
{
    public class OrderController : ApiController
    {
        OrdersRepository orderrepo = new OrdersRepository();
        VillageProductRepository prdctdetails = new VillageProductRepository();
        CustomerRepository custmrepo = new CustomerRepository();
        [HttpPost]
        [Route("api/Order/placeorder")]
        public IHttpActionResult placeorder([FromBody] villageorders order, [FromUri] string email, [FromUri] string pid)
        {
            var data = orderrepo.InsertOrder(order, email);
            var cartdetails = prdctdetails.getproductbyid(pid).ToArray();
            orderdetails orderdetail = new orderdetails();
            for (var i = 0; i < cartdetails.Length; i++)
            {
                var detail = cartdetails[i];
                orderdetail.ProductId = detail.id.ToString();
                      orderdetail.Quantity = detail.Quantity;
                     orderdetail.orderid = data;
                      var orderdetails = orderrepo.InsertOrderdetails(orderdetail);
            }
            return Json(data);
        }
        [HttpPost]
        [Route("api/Order/updateorder")]
        public IHttpActionResult updateorder([FromBody] villageorders order, [FromUri] string orderid)
        {
            var data = orderrepo.UpdateOrder(order, orderid);
            return Json(data);
        }
        [HttpGet]
        [Route("api/Order/GetAllorders")]
        public IHttpActionResult GetAllorders()
        {
            var orders = orderrepo.Getallorders();
            return Json(orders);
        }

        [HttpGet]
        [Route("api/Order/Getorder")]
        public IHttpActionResult Getorder([FromUri] string orderid)
        {
            var order = orderrepo.getorderbyid(orderid);
            return Json(order);
        }

        [HttpGet]
        [Route("api/Order/Getorderbyemail")]
        public IHttpActionResult Getorderbyemail([FromUri] string email)
        {
            var order = orderrepo.getorderbyemail(email);
            return Json(order);
        }

        [HttpGet]
        [Route("api/Order/Getalldetails")]
        public IHttpActionResult Getalldetails([FromUri] string Oid)
        {

            
            var orders = orderrepo.getorderbyid(Oid);

            var orderdetails = orderrepo.getorderbyorderid(Oid);
            List<orderdetails> od = new List<orderdetails>();
            var od1 = ((IEnumerable)orderdetails).Cast<object>().ToList();
            var custdetails = custmrepo.customerdetailsbyid(Convert.ToInt32(orders.CustomerId));
            AllOrderdetails alldetails = new AllOrderdetails();
            alldetails.CustomerId = custdetails.CustomerId;
            alldetails.Firstname = custdetails.Firstname;
            alldetails.Lastname = custdetails.Lastname;
            alldetails.Billing_Address = custdetails.Billing_Address;
            alldetails.Delivery_Address = custdetails.Delivery_Address;
            alldetails.Land_Mark = custdetails.Land_Mark;
            alldetails.mobile1 = custdetails.mobile1;
            alldetails.mobile2 = custdetails.mobile2;
            alldetails.CustomerType = custdetails.CustomerType;
            alldetails.DeliveryLocationLattitude = custdetails.DeliveryLocationLattitude;
            alldetails.DeliveryLocationLongitude = custdetails.DeliveryLocationLongitude;
            alldetails.CreateDate = custdetails.CreateDate;
            alldetails.modifieddate = custdetails.modifieddate;
            alldetails.Email = custdetails.Email;
            alldetails.OTP = custdetails.OTP;
            alldetails.Status = custdetails.Status;
            alldetails.ProfileImage = custdetails.ProfileImage;
            alldetails.ProfilePic = custdetails.ProfilePic;
            alldetails.City = custdetails.City;
            alldetails.State = custdetails.Status;
            alldetails.Country = custdetails.Country;
            alldetails.Zipecode = custdetails.Zipecode;
            //alldetails.orderdetailid = orderdetails.orderdetailid;
            //alldetails.ProductId = orderdetails.ProductId;
            //alldetails.Quantity = orderdetails.Quantity;
            //alldetails.orderid = orderdetails.orderid;

            //List<orderdetails> odet = new List<orderdetails>();
            //for (int i = 0; i <= od1.Count(); i++)
            //{
            //    orderdetails orderdetail1 = new orderdetails();
            //    orderdetail1.orderdetailid = orderdetails.orderdetailid;
            //    orderdetail1.ProductId = orderdetails.ProductId;
            //    orderdetail1.Quantity = orderdetails.Quantity;
            //    orderdetail1.orderid = orderdetails.orderid;
            //    odet.Add(orderdetail1);
            //}
            alldetails.orderdetaillist = orderdetails;
            alldetails.OrderId = orders.OrderId;
            alldetails.OrderStatus = orders.OrderStatus;
            alldetails.Paymentid = orders.Paymentid;
            alldetails.ordertime = orders.ordertime;
            alldetails.orderdeliveredtime = orders.orderdeliveredtime;
            alldetails.Discount = orders.Discount;
            alldetails.Remarks = orders.Remarks;
            alldetails.Deliverycharges = orders.Deliverycharges;
            alldetails.CGST = orders.CGST;
            alldetails.SGST = orders.SGST;
            alldetails.Totalamount = orders.Totalamount;
            alldetails.Deliveryarea = orders.Deliveryarea;
            alldetails.Transactionid = orders.Transactionid;
            alldetails.transactionstatus = orders.transactionstatus;
            return Json(alldetails); 

    }
        public class AllOrderdetails
        {
            public int CustomerId { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Billing_Address { get; set; }
            public string Delivery_Address { get; set; }
            public string Land_Mark { get; set; }
            public string mobile1 { get; set; }
            public string mobile2 { get; set; }
            public string CustomerType { get; set; }
            public string DeliveryLocationLattitude { get; set; }
            public string DeliveryLocationLongitude { get; set; }
            public string CreateDate { get; set; }
            public string modifieddate { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string OTP { get; set; }
            public string Status { get; set; }
            public string ProfileImage { get; set; }
            public string ProfilePic { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Zipecode { get; set; }
            public long orderdetailid { get; set; }
            public string ProductId { get; set; }
            public string Quantity { get; set; }
            public string orderid { get; set; }
            public long OrderId { get; set; }
            public string Orderdate { get; set; }
            public string OrderStatus { get; set; }
            public string Paymentid { get; set; }   
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
            public List<orderdetails> orderdetaillist { get; set; }
        }
    }
}
