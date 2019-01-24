using mvrapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvrapi.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerRepository custm = new CustomerRepository();

        [HttpPost]
        [Route("api/Customer/UserRegister")]
        public IHttpActionResult UserRegister([FromBody] Customer customer)
        {
            var data1 = custm.Checkemail(customer.Email);string msg;
            if(data1=="1")
            {

                var data = custm.Register(customer);
               msg = "Succesfully Registered";
            }
            else
            {
                msg = "Customer Email is Existed plz registered with another email";
            }

                return Json(msg);
        }
        [HttpPost]
        [Route("api/Customer/UserLogin")]
        public IHttpActionResult UserLogin(string email,string password)
         {
            Customer custdetails = new Customer();
            var data = custm.CustomerLogin(email, password);
         if(data != null)
            {
                custdetails = data;
            }
          
            return Json(custdetails);
        }
    }
}
