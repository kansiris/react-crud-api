using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace mvrapi.Models
{
    public class VillageProductRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["apicontstr"].ConnectionString;

        public string InsertProduct(villageproduct product)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("insert into villageproduct(ProductId,Productname,Price,Quantity,weight,ShortDescription,LongDescription,Remarks,Available,HSNcode,SGST,CGST,Discount,brand,Image,Manfacturedate,Expirydate,createdate,Updateddate) values (@ProductId,@Productname,@Price,@Quantity,@weight,@ShortDescription,@LongDescription,@Remarks,@Available,@HSNcode,@SGST,@CGST,@Discount,@brand,@Image,@Manfacturedate,@Expirydate,@createdate,@Updateddate)", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@Productname", product.Productname);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@weight", product.weight);
            cmd.Parameters.AddWithValue("@ShortDescription", product.ShortDescription);
            cmd.Parameters.AddWithValue("@LongDescription", product.LongDescription);
            cmd.Parameters.AddWithValue("@Remarks", product.Remarks);
            cmd.Parameters.AddWithValue("@Available", product.Available);
            cmd.Parameters.AddWithValue("@HSNcode", product.HSNcode);
            cmd.Parameters.AddWithValue("@SGST", product.SGST);
            cmd.Parameters.AddWithValue("@CGST", product.CGST);
            cmd.Parameters.AddWithValue("@Discount", product.Discount);
            cmd.Parameters.AddWithValue("@brand", product.brand);
            cmd.Parameters.AddWithValue("@Image", product.Image);
            cmd.Parameters.AddWithValue("@Manfacturedate", product.Manfacturedate);
            cmd.Parameters.AddWithValue("@Expirydate", product.Expirydate);
            cmd.Parameters.AddWithValue("@createdate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@Updateddate", DateTime.Now.ToString("dd/MM/yyyy"));
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public string UpdateProduct(villageproduct product, int id)
        {
           
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("update villageproduct set ProductId=@ProductId,Productname=@Productname,Price=@Price,Quantity=@Quantity,weight=@weight,ShortDescription=@ShortDescription,LongDescription=@LongDescription,Remarks=@Remarks,Available=@Available,HSNcode=@HSNcode,SGST=@SGST,CGST=@CGST,Discount=@Discount,brand=@brand,Image=@Image,Manfacturedate=@Manfacturedate,Expirydate=@Expirydate,Updateddate=@Updateddate,createdate=@createdate where id=@id", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@Productname", product.Productname);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@weight", product.weight);
            cmd.Parameters.AddWithValue("@ShortDescription", product.ShortDescription);
            cmd.Parameters.AddWithValue("@LongDescription", product.LongDescription);
            cmd.Parameters.AddWithValue("@Remarks", product.Remarks);
            cmd.Parameters.AddWithValue("@Available", product.Available);
            cmd.Parameters.AddWithValue("@HSNcode", product.HSNcode);
            cmd.Parameters.AddWithValue("@SGST", product.SGST);
            cmd.Parameters.AddWithValue("@CGST", product.CGST);
            cmd.Parameters.AddWithValue("@Discount", product.Discount);
            cmd.Parameters.AddWithValue("@brand", product.brand);
            cmd.Parameters.AddWithValue("@Image", product.Image);
            cmd.Parameters.AddWithValue("@Manfacturedate", product.Manfacturedate);
            cmd.Parameters.AddWithValue("@Expirydate", product.Expirydate);
            var data = getbyid(id);
            cmd.Parameters.AddWithValue("@createdate", data.createdate.ToString());
            cmd.Parameters.AddWithValue("@Updateddate", DateTime.Now.ToString("dd/MM/yyyy"));
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public villageproduct getproductsAvailablity(string Available)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageproduct where Available=@Available", con);
            cmd.Parameters.AddWithValue("@Available", Available);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            villageproduct product = null;
            while (rdr.Read())
            {
                product = new villageproduct();
                product.id = Convert.ToInt32(rdr.GetValue(0));
                product.ProductId = rdr.GetValue(1).ToString();
                product.Productname = rdr.GetValue(2).ToString();
                product.Price = rdr.GetValue(3).ToString();
                product.Quantity = rdr.GetValue(4).ToString();
                product.weight = rdr.GetValue(5).ToString();
                product.ShortDescription = rdr.GetValue(6).ToString();
                product.LongDescription = rdr.GetValue(7).ToString();
                product.Remarks = rdr.GetValue(8).ToString();
                product.Available = rdr.GetValue(8).ToString();
                product.HSNcode = rdr.GetValue(10).ToString();
                product.SGST = rdr.GetValue(11).ToString();
                product.CGST = rdr.GetValue(12).ToString();
                product.Discount = rdr.GetValue(13).ToString();
                product.brand = rdr.GetValue(14).ToString();
                product.Image = rdr.GetValue(15).ToString();
                product.Manfacturedate = rdr.GetValue(16).ToString();
                product.Expirydate = rdr.GetValue(17).ToString();
                product.createdate = rdr.GetValue(18).ToString();
                product.Updateddate = rdr.GetValue(19).ToString();
            }
            con.Close();
            return product;
        }

        public villageproduct getbyid(int id)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageproduct where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            villageproduct product = null;
            while (rdr.Read())
            {
                product = new villageproduct();
                product.id = Convert.ToInt32(rdr.GetValue(0));
                product.ProductId = rdr.GetValue(1).ToString();
                product.Productname = rdr.GetValue(2).ToString();
                product.Price = rdr.GetValue(3).ToString();
                product.Quantity = rdr.GetValue(4).ToString();
                product.weight = rdr.GetValue(5).ToString();
                product.ShortDescription = rdr.GetValue(6).ToString();
                product.LongDescription = rdr.GetValue(7).ToString();
                product.Remarks = rdr.GetValue(8).ToString();
                product.Available = rdr.GetValue(8).ToString();
                product.HSNcode = rdr.GetValue(10).ToString();
                product.SGST = rdr.GetValue(11).ToString();
                product.CGST = rdr.GetValue(12).ToString();
                product.Discount = rdr.GetValue(13).ToString();
                product.brand = rdr.GetValue(14).ToString();
                product.Image = rdr.GetValue(15).ToString();
                product.Manfacturedate = rdr.GetValue(16).ToString();
                product.Expirydate = rdr.GetValue(17).ToString();
                product.createdate = rdr.GetValue(18).ToString();
                product.Updateddate = rdr.GetValue(19).ToString();
            }
            con.Close();
            return product;
        }


        public IEnumerable<villageproduct> getproductbyid(string id)
        {

            List<villageproduct> productdetails = new List<villageproduct>();
            var cartids = id.Trim(',').Split(',');
            villageproduct product = new villageproduct();
           
            for (int i = 0; i < cartids.Length; i++)
            {
                
                var cid = Regex.Replace(cartids[i], @"\s", "");
                if(cid!= "null" && cid!="" && cid!="undefined")
                {
                int Id = Convert.ToInt32(cid);
                MySqlConnection con = new MySqlConnection(constr);
                MySqlCommand cmd = new MySqlCommand("Select * from villageproduct where id=@id", con);
                cmd.Parameters.AddWithValue("@id", Id);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
               
                while (rdr.Read())
                {
                    product = new villageproduct();
                        product.id = Convert.ToInt32(rdr.GetValue(0));
                    product.ProductId = rdr.GetValue(1).ToString();
                    product.Productname = rdr.GetValue(2).ToString();
                    product.Price = rdr.GetValue(3).ToString();
                    product.Quantity = rdr.GetValue(4).ToString();
                    product.weight = rdr.GetValue(5).ToString();
                    product.ShortDescription = rdr.GetValue(6).ToString();
                    product.LongDescription = rdr.GetValue(7).ToString();
                    product.Remarks = rdr.GetValue(8).ToString();
                    product.Available = rdr.GetValue(8).ToString();
                    product.HSNcode = rdr.GetValue(10).ToString();
                    product.SGST = rdr.GetValue(11).ToString();
                    product.CGST = rdr.GetValue(12).ToString();
                    product.Discount = rdr.GetValue(13).ToString();
                    product.brand = rdr.GetValue(14).ToString();
                    product.Image = rdr.GetValue(15).ToString();
                    product.Manfacturedate = rdr.GetValue(16).ToString();
                    product.Expirydate = rdr.GetValue(17).ToString();
                    product.createdate = rdr.GetValue(18).ToString();
                    product.Updateddate = rdr.GetValue(19).ToString();
                }
                con.Close();
                productdetails.Add(product);
                }
            }
           

            return productdetails;  
      }

        public string deleteproduct(int id)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Delete from villageproduct where id=@id",con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public IEnumerable<villageproduct> Getallproducts()
        {
            List<villageproduct> productdetails = new List<villageproduct>();
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageproduct", con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader(); 
            while (rdr.Read())
            {
                villageproduct product = new villageproduct();
                product.id = Convert.ToInt32(rdr.GetValue(0));
                product.ProductId = rdr.GetValue(1).ToString();
                product.Productname = rdr.GetValue(2).ToString();
                product.Price = rdr.GetValue(3).ToString();
                product.Quantity = rdr.GetValue(4).ToString();
                product.weight = rdr.GetValue(5).ToString();
                product.ShortDescription = rdr.GetValue(6).ToString();
                product.LongDescription = rdr.GetValue(7).ToString();
                product.Remarks = rdr.GetValue(8).ToString();
                product.Available = rdr.GetValue(8).ToString();
                product.HSNcode = rdr.GetValue(10).ToString();
                product.SGST = rdr.GetValue(11).ToString();
                product.CGST = rdr.GetValue(12).ToString();
                product.Discount = rdr.GetValue(13).ToString();
                product.brand = rdr.GetValue(14).ToString();
                product.Image = rdr.GetValue(15).ToString();
                product.Manfacturedate = rdr.GetValue(16).ToString();
                product.Expirydate = rdr.GetValue(17).ToString();
                product.createdate = rdr.GetValue(18).ToString();
                product.Updateddate = rdr.GetValue(19).ToString();
                productdetails.Add(product);
            }
            con.Close();
            return productdetails;
        }
        public IEnumerable<villageproduct> Productsavailabe(string Available)
        {

            List<villageproduct> productdetails = new List<villageproduct>();
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageproduct  where Available=@Available", con); cmd.Parameters.AddWithValue("@Available", Available);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                villageproduct product = new villageproduct();
                product.id = Convert.ToInt32(rdr.GetValue(0));
                product.ProductId = rdr.GetValue(1).ToString();
                product.Productname = rdr.GetValue(2).ToString();
                product.Price = rdr.GetValue(3).ToString();
                product.Quantity = rdr.GetValue(4).ToString();
                product.weight = rdr.GetValue(5).ToString();
                product.ShortDescription = rdr.GetValue(6).ToString();
                product.LongDescription = rdr.GetValue(7).ToString();
                product.Remarks = rdr.GetValue(8).ToString();
                product.Available = rdr.GetValue(8).ToString();
                product.HSNcode = rdr.GetValue(10).ToString();
                product.SGST = rdr.GetValue(11).ToString();
                product.CGST = rdr.GetValue(12).ToString();
                product.Discount = rdr.GetValue(13).ToString();
                product.brand = rdr.GetValue(14).ToString();
                product.Image = rdr.GetValue(15).ToString();
                product.Manfacturedate = rdr.GetValue(16).ToString();
                product.Expirydate = rdr.GetValue(17).ToString();
                product.createdate = rdr.GetValue(18).ToString();
                product.Updateddate = rdr.GetValue(19).ToString();
                productdetails.Add(product);
            }
            con.Close();
            return productdetails;
        }

    }
}