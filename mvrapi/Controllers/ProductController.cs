using mvrapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace mvrapi.Controllers
{
    public class ProductController : ApiController
    {

        VillageProductRepository prdctdetails = new VillageProductRepository();

        [HttpPost]
        [Route("api/Product/AddProduct")]
        public IHttpActionResult AddProduct([FromBody] villageproduct product)
        {
            string msg;
            var data = prdctdetails.InsertProduct(product);
            if (data == "Success")
            {
                msg = "Product Added Succesfully";
            }
            else
            {
                msg = "Product is not added try again";
            }
            return Json(msg);
        }
        [HttpPost]
        [Route("api/Product/UpdateProduct")]
        public IHttpActionResult UpdateProduct([FromBody] villageproduct product,[FromUri] int id)
        {

            string msg;
            var data = prdctdetails.UpdateProduct(product, id);
            if (data == "Success")
            {
                msg = "Product Updated Succesfully";
            }
            else
            {
                msg = "Product is not Updated try again";
            }
            return Json(msg);
        }
        [HttpDelete]
        [Route("api/Product/DeleteProduct")]
        public IHttpActionResult DeleteProduct(int id)
        {
            string msg;
            var data1 = prdctdetails.deleteproduct(id);
            if (data1 == "Success")
            {
                msg = "Product  Deleted Succesfully";
            }
            else
            {
                msg = "Product is not Deleted try again";
            }
            return Json(msg);
        }

        [HttpGet]
        [Route("api/Product/GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            var data = prdctdetails.Getallproducts();
            return Json(data);
        }
        [HttpGet]
        [Route("api/Product/GetProductbyid")]
        public IHttpActionResult GetProductbyid(string id)
        {
            //villageproduct datalist = new villageproduct();

            //var cartids = id.Trim(',').Split(',');

            //for (int i=0; i< cartids.Length;i++)
            //{
            //    var cid= Regex.Replace(cartids[i], @"\s", "");
            //    if (cid != null)
            //    {

            //        datalist = prdctdetails.getproductbyid(int.Parse(cid));

            //    }
            //    else
            //    {
            //        datalist = null;

            //    }

            //}
           var datalist = prdctdetails.getproductbyid(id);
            return Json(datalist);
        }
       
    }
}
