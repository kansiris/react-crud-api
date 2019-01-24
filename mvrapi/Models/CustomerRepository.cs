using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace mvrapi.Models
{
    public class CustomerRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["apicontstr"].ConnectionString;
        //private static string connectionString = "datasource=192.168.0.62;Database=myvillagerice;user id=xsi;password=newpassword;";


        public string Register(Customer customer)
        {
            
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Insert Into Customer(Firstname,Lastname,Email,Password,Billing_Address,Delivery_Address,Land_Mark,Status,DeliveryLocationLattitude,DeliveryLocationLongitude,CreateDate,modifieddate,OTP,mobile1,mobile2,ProfileImage,ProfilePic,CustomerType,confirmpassword) values (@Firstname,@Lastname,@Email,@Password,@Billing_Address,@Delivery_Address,@Land_Mark,@Status,@DeliveryLocationLattitude,@DeliveryLocationLongitude,@CreateDate,@modifieddate,@OTP,@mobile1,@mobile2,@ProfileImage,@ProfilePic,@CustomerType,@confirmpassword)", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Firstname", customer.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", customer.Lastname);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Password", customer.Password);
            cmd.Parameters.AddWithValue("@confirmpassword", customer.confirmpassword);
            cmd.Parameters.AddWithValue("@Billing_Address", customer.Billing_Address);
            cmd.Parameters.AddWithValue("@Delivery_Address", customer.Delivery_Address);
            cmd.Parameters.AddWithValue("@Land_Mark", customer.Land_Mark);
            cmd.Parameters.AddWithValue("@Status", customer.Status);
            cmd.Parameters.AddWithValue("@DeliveryLocationLattitude", customer.DeliveryLocationLattitude);
            cmd.Parameters.AddWithValue("@DeliveryLocationLongitude", customer.DeliveryLocationLongitude);
            cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@modifieddate", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@OTP", customer.OTP);
            cmd.Parameters.AddWithValue("@mobile1", customer.mobile1);
            cmd.Parameters.AddWithValue("@mobile2", customer.mobile2);
            cmd.Parameters.AddWithValue("@ProfileImage", customer.ProfileImage);
            cmd.Parameters.AddWithValue("@ProfilePic", customer.ProfilePic);
            cmd.Parameters.AddWithValue("@@CustomerType", customer.CustomerType);
            con.Open();
           int i= cmd.ExecuteNonQuery();
            con.Close();
            if (i==1)
            {
                return "Sucess";
            }
            else
            {
                return "Failed";
            }
            
        }
        public string Checkemail(string email)
        {
            string msg = "";
            MySqlConnection con = new MySqlConnection(constr);
            //MySqlCommand cmd = new MySqlCommand("select count(Email) as Email from Customer where Email=@Email",con);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Email from Customer where Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            MySqlDataReader dr = cmd.ExecuteReader();
           
            if(dr.HasRows)
            {
                msg = "0";
            }
            else
            {
                msg = "1";
            }
            con.Close();
            return msg;
        }

        public Customer CustomerLogin(string email,string password)
        {
            //string msg;
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("select * from Customer where Email=@Email && Password=@Password", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Customer customer = null;
            while (dr.Read())
            {
                customer = new Customer();
                customer.Firstname = dr.GetValue(1).ToString();
                customer.Lastname = dr.GetValue(2).ToString();
                customer.Email = dr.GetValue(3).ToString();
            }
          
            con.Close();
            return customer;

        }
    }
}