using mvrapi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web;
using mvrapi.Emailsending;

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
        [HttpGet]
        [Route("api/Customer/UserLogin")]
        public IHttpActionResult UserLogin([FromUri] string email, [FromUri] string password)
         {

            Customer custdetails = new Customer();
            if(email !=null && password !=null)
            { 
            var data = custm.CustomerLogin(email, password);
             if(data != null)
            {
                custdetails = data;
            }

            }

            return Json(custdetails);
        }

        [HttpPost]
       [Route("api/Customer/SendPasswordmail")]
        public IHttpActionResult SendPasswordmail([FromUri]string email)
        {
          
            Customer custdetails = new Customer();
            var details = custm.Sendpassword(email);
            if (details != null)
            {
                custdetails = details;
                string txtto = custdetails.Email;
                string name = custdetails.Firstname + " " + custdetails.Lastname;
                string password = custdetails.Password;
                string url = Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/Login";
                FileInfo File = new FileInfo(HttpContext.Current.Server.MapPath("/MailTemplate/psendingmail.html"));
                string readFile = File.OpenText().ReadToEnd();
                readFile = readFile.Replace("[ActivationLink]", url);
                readFile = readFile.Replace("[vname]", name);
                readFile = readFile.Replace("[password]", password);
                string txtmessage = readFile;//readFile + body;
                string subj = "Forgot Password Of My Villlage";
                emailsending emailSendingUtility = new emailsending();
                emailSendingUtility.Email_myvillage(txtto, txtmessage, subj, null);
                string targetmails = "lakshmi.p@xsilica.com,seema.g@xsilica.com,sireesh.k@xsilica.com";
                emailSendingUtility.Email_myvillage(targetmails, txtmessage, subj, null);
                return Json("Success");

            }
            else
            {
                return Json("failed");
            }
           
        }

        [HttpPost]
        [Route("api/Customer/getcustmerlst")]
        public IHttpActionResult getcustmerlst([FromUri] string email)
        {
            var datalist = custm.customerbyemail(email);
            if(datalist!=null)
            {
                return Json(datalist);
            }
            else
            {
                return Json("null");
            }

        }

        [HttpGet]
        [Route("api/Customer/getcustmer")]
        public IHttpActionResult getcustmer([FromUri] string email)
        {
            var datalist = custm.customerdetailsemail(email);
            if (datalist != null)
            {
                return Json(datalist);
            }
            else
            {
                return Json("null");
            }

        }


        //[HttpPost]
        //[Route("api/Customer/GetCustomerbyemail")]
        //public IHttpActionResult GetCustomerbyemail(string email)
        //{
        //    var details = custm.Sendpassword(email);
        //    if(details!=null)
        //    {
        //        return Json(details);
        //    }
        //    else
        //    {
        //        return Json("null");
        //    }
        //}
    }
}
