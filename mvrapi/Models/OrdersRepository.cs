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
        public string InsertOrder(villageorders order,string email)
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Insert Into Customer(Orderdate,OrderStatus,Paymentid,CustomerId,ordertime,Discount,Remarks,Deliverycharges,CGST,SGST,Totalamount,Deliveryarea,Transactionid,transactionstatus) values (@Orderdate,@OrderStatus,@Paymentid,@CustomerId,@ordertime,@orderdeliveredtime,@Discount,@Remarks,@Deliverycharges,@CGST,@SGST,@Totalamount,@Deliveryarea,@Transactionid,@transactionstatus)", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Orderdate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            cmd.Parameters.AddWithValue("@Paymentid", order.Transactionid);
            var details = custm.customerdetailsemail(email);
             cmd.Parameters.AddWithValue("@CustomerId", details.CustomerId);
            cmd.Parameters.AddWithValue("@ordertime", DateTime.Now.ToString("HH:mm:ss tt"));
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
                if(i==1)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

        //public IEnumerable<villageorders> GetALLORDERS

        //public string UpdateOrder(villageorders order,long orderid)
        //{
        //    MySqlConnection con = new MySqlConnection(constr);
        //    MySqlCommand cmd = new MySqlCommand("UpdateOrder villageorders set OrderStatus= @OrderStatus", con);
        //    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        //}
    }
}