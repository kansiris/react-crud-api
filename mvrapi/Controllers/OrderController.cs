using mvrapi.Models;
using System;
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
        [HttpPost]
        [Route("api/Order/placeorder")]
        public IHttpActionResult placeorder([FromBody] villageorders order, [FromUri] string email)
        {
            var data = orderrepo.InsertOrder(order, email); 
          
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
        public IHttpActionResult Getorder(string orderid)
        {
            var order = orderrepo.getorderbyid(orderid);
            return Json(order);
        }

        [HttpGet]
        [Route("api/Order/Getorderbyemail")]
        public IHttpActionResult Getorderbyemail(string email)
        {
            var order = orderrepo.getorderbyemail(email);
            return Json(order);
        }

    }
}
