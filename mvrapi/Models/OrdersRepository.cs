using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace mvrapi.Models
{
    public class OrdersRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["apicontstr"].ConnectionString;
        CustomerRepository custm = new CustomerRepository();
       public string InsertOrder(villageorders order, string email)
        //public string InsertOrder(villageorders order)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Insert Into villageorders(Orderdate,OrderStatus,Paymentid,CustomerId,ordertime,Discount,Remarks,Deliverycharges,CGST,SGST,Totalamount,Deliveryarea,Transactionid,transactionstatus) values (@Orderdate,@OrderStatus,@Paymentid,@CustomerId,@ordertime,@Discount,@Remarks,@Deliverycharges,@CGST,@SGST,@Totalamount,@Deliveryarea,@Transactionid,@transactionstatus)", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Orderdate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            cmd.Parameters.AddWithValue("@Paymentid", order.Transactionid);
            var details = custm.customerdetailsemail(email);
            cmd.Parameters.AddWithValue("@CustomerId", details.CustomerId);
            //cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@ordertime", DateTime.Now.ToString("HH:mm:ss"));
            cmd.Parameters.AddWithValue("@Discount", order.Discount);
            cmd.Parameters.AddWithValue("@Remarks", order.Remarks);
            cmd.Parameters.AddWithValue("@Deliverycharges", order.Deliverycharges);
            cmd.Parameters.AddWithValue("@CGST", order.CGST);
            cmd.Parameters.AddWithValue("@SGST", order.SGST);
            cmd.Parameters.AddWithValue("@Totalamount", order.Totalamount);
            cmd.Parameters.AddWithValue("@Deliveryarea", order.Deliveryarea);
            cmd.Parameters.AddWithValue("@Transactionid", order.Transactionid);
            cmd.Parameters.AddWithValue("@transactionstatus", order.transactionstatus);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                long order1 = retriveorderid();
                if (order1 != 0)
                    return order1.ToString();
            }
            return "failed";
        }

        public string UpdateOrder(villageorders order, string orderid)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("update villageorders set Orderdate=@Orderdate,OrderStatus=@OrderStatus,Paymentid=@Paymentid,CustomerId=@CustomerId,ordertime=@ordertime,orderdeliveredtime=@orderdeliveredtime,Discount=@Discount,Remarks=@Remarks,Deliverycharges=@Deliverycharges,CGST=@CGST,SGST=@SGST,Totalamount=@Totalamount,Deliveryarea=@Deliveryarea,Transactionid=@Transactionid,transactionstatus=@transactionstatus where OrderId=@OrderId", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            var data = getorderbyid(orderid);
            cmd.Parameters.AddWithValue("@OrderId", Convert.ToInt64(orderid));
            cmd.Parameters.AddWithValue("@Orderdate", data.Orderdate);
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            cmd.Parameters.AddWithValue("@Paymentid", data.Paymentid);
            cmd.Parameters.AddWithValue("@CustomerId", data.CustomerId);
            cmd.Parameters.AddWithValue("@ordertime", data.ordertime);
            cmd.Parameters.AddWithValue("@orderdeliveredtime", DateTime.Now.ToString("HH:mm:ss tt"));
            cmd.Parameters.AddWithValue("@Discount", data.Discount);
            cmd.Parameters.AddWithValue("@Remarks", data.Remarks);
            cmd.Parameters.AddWithValue("@Deliverycharges", data.Deliverycharges);
            cmd.Parameters.AddWithValue("@CGST", data.CGST);
            cmd.Parameters.AddWithValue("@SGST", data.SGST);
            cmd.Parameters.AddWithValue("@Totalamount", data.Totalamount);
            cmd.Parameters.AddWithValue("@Deliveryarea", data.Deliveryarea);
            cmd.Parameters.AddWithValue("@Transactionid", data.Transactionid);
            cmd.Parameters.AddWithValue("@transactionstatus", data.transactionstatus);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                long order1 = retriveorderid();
                if (order1 != 0)
                    return order1.ToString();
            }
            return "failed";
        }

        public IEnumerable<villageorders> Getallorders()
        {
            List<villageorders> orders = new List<villageorders>();
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageorders", con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                villageorders order = new villageorders();
                order.OrderId = Convert.ToInt64(rdr.GetValue(0));
                order.Orderdate = rdr.GetValue(1).ToString();
                order.OrderStatus = rdr.GetValue(2).ToString();
                order.Paymentid = rdr.GetValue(3).ToString();
                order.CustomerId = rdr.GetValue(4).ToString();
                order.ordertime = rdr.GetValue(5).ToString();
                order.orderdeliveredtime = rdr.GetValue(6).ToString();
                order.Discount = rdr.GetValue(7).ToString();
                order.Remarks = rdr.GetValue(8).ToString();
                order.Deliverycharges = rdr.GetValue(9).ToString();
                order.CGST = rdr.GetValue(10).ToString();
                order.SGST = rdr.GetValue(11).ToString();
                order.Totalamount = rdr.GetValue(12).ToString();
                order.Deliveryarea = rdr.GetValue(13).ToString();
                order.Transactionid = rdr.GetValue(14).ToString();
                order.transactionstatus = rdr.GetValue(15).ToString();
                orders.Add(order);

            }
            con.Close();
            return orders;
        }
        public villageorders getorderbyid(string orderid)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageorders where OrderId=@OrderId", con);
            cmd.Parameters.AddWithValue("@OrderId", Convert.ToInt64(orderid));
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            villageorders order = null;
            while (rdr.Read())
            {
                order = new villageorders();
                order.OrderId = Convert.ToInt64(rdr.GetValue(0));
                order.Orderdate = rdr.GetValue(1).ToString();
                order.OrderStatus = rdr.GetValue(2).ToString();
                order.Paymentid = rdr.GetValue(3).ToString();
                order.CustomerId = rdr.GetValue(4).ToString();
                order.ordertime = rdr.GetValue(5).ToString();
                order.orderdeliveredtime = rdr.GetValue(6).ToString();
                order.Discount = rdr.GetValue(7).ToString();
                order.Remarks = rdr.GetValue(8).ToString();
                order.Deliverycharges = rdr.GetValue(9).ToString();
                order.CGST = rdr.GetValue(10).ToString();
                order.SGST = rdr.GetValue(11).ToString();
                order.Totalamount = rdr.GetValue(12).ToString();
                order.Deliveryarea = rdr.GetValue(13).ToString();
                order.Transactionid = rdr.GetValue(14).ToString();
                order.transactionstatus = rdr.GetValue(15).ToString();
            }
            con.Close();
            return order;
        }
        public villageorders getorderbyemail(string email)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from villageorders where CustomerId=@CustomerId", con);
            var details = custm.customerdetailsemail(email);
            cmd.Parameters.AddWithValue("@CustomerId", details.CustomerId);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            villageorders order = null;
            while (rdr.Read())
            {
                order = new villageorders();
                order.OrderId = Convert.ToInt64(rdr.GetValue(0));
                order.Orderdate = rdr.GetValue(1).ToString();
                order.OrderStatus = rdr.GetValue(2).ToString();
                order.Paymentid = rdr.GetValue(3).ToString();
                order.CustomerId = rdr.GetValue(4).ToString();
                order.ordertime = rdr.GetValue(5).ToString();
                order.orderdeliveredtime = rdr.GetValue(6).ToString();
                order.Discount = rdr.GetValue(7).ToString();
                order.Remarks = rdr.GetValue(8).ToString();
                order.Deliverycharges = rdr.GetValue(9).ToString();
                order.CGST = rdr.GetValue(10).ToString();
                order.SGST = rdr.GetValue(11).ToString();
                order.Totalamount = rdr.GetValue(12).ToString();
                order.Deliveryarea = rdr.GetValue(13).ToString();
                order.Transactionid = rdr.GetValue(14).ToString();
                order.transactionstatus = rdr.GetValue(15).ToString();
            }
            con.Close();
            return order;
        }

        public long retriveorderid()
        {
            MySqlConnection con = new MySqlConnection(constr);
            //MySqlCommand cmd = new MySqlCommand("select top 1 OrderId from villageorders orderby OrderId desc", con);
            MySqlCommand cmd = new MySqlCommand("select OrderId from villageorders ORDER BY OrderId desc LIMIT 1", con);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                return (long)dr.GetValue(0);
            con.Close();
            return 0;
        }
        public string InsertOrderdetails(orderdetails order)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Insert Into orderdetails(ProductId,Quantity,orderid) values (@ProductId,@Quantity,@orderid)", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ProductId", order.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", "1");
            cmd.Parameters.AddWithValue("@orderid", order.orderid);          
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "success";
            }
            return "failed";
        }

        public List<orderdetails> getorderbyorderid(string oid)
        {
            List<orderdetails> detaillst = new List<orderdetails>();
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Select * from orderdetails where orderid=@orderid", con);
            cmd.Parameters.AddWithValue("@orderid", oid);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            
           while (dr.Read())
            {
                orderdetails details = new orderdetails();
                //details.orderdetailid = Convert.ToInt64(dr.GetValue(0));
                details.ProductId = dr.GetValue(1).ToString();
                details.Quantity = dr.GetValue(2).ToString();
                details.orderid = dr.GetValue(3).ToString();
                detaillst.Add(details);
            }
            con.Close();
            return detaillst;
        }
    }
}