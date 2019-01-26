using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;

namespace mvrapi.Models
{
    public class CustomerRepository
    {
        string constr = ConfigurationManager.ConnectionStrings["apicontstr"].ConnectionString;
        //private static string connectionString = "datasource=192.168.0.62;Database=myvillagerice;user id=xsi;password=newpassword;";


        public string Register(Customer customer)
        {
            
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("Insert Into Customer(Firstname,Lastname,Email,Password,Billing_Address,Delivery_Address,Land_Mark,Status,DeliveryLocationLattitude,DeliveryLocationLongitude,CreateDate,modifieddate,OTP,mobile1,mobile2,ProfileImage,ProfilePic,CustomerType) values (@Firstname,@Lastname,@Email,@Password,@Billing_Address,@Delivery_Address,@Land_Mark,@Status,@DeliveryLocationLattitude,@DeliveryLocationLongitude,@CreateDate,@modifieddate,@OTP,@mobile1,@mobile2,@ProfileImage,@ProfilePic,@CustomerType)", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Firstname", customer.Firstname);
            cmd.Parameters.AddWithValue("@Lastname", customer.Lastname);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Password", customer.Password);
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

        public Customer Sendpassword(string email)
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Email from Customer where Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            MySqlDataReader dr = cmd.ExecuteReader();
            Customer customer = null;
            while (dr.Read())
            {
                customer = new Customer();
                customer.Firstname = dr.GetValue(1).ToString();
                customer.Lastname = dr.GetValue(2).ToString();
                customer.Email = dr.GetValue(3).ToString();
                customer.Password = dr.GetValue(4).ToString();
                customer.Billing_Address = dr.GetValue(5).ToString();
                customer.Delivery_Address = dr.GetValue(6).ToString();
                customer.Land_Mark = dr.GetValue(7).ToString();
                customer.mobile1 = dr.GetValue(8).ToString();
                customer.mobile2 = dr.GetValue(9).ToString();
                customer.CustomerType = dr.GetValue(10).ToString();
                customer.DeliveryLocationLattitude = dr.GetValue(11).ToString();
                customer.DeliveryLocationLongitude = dr.GetValue(12).ToString();
                customer.CreateDate = dr.GetValue(13).ToString();
                customer.modifieddate = dr.GetValue(14).ToString();
                customer.Status = dr.GetValue(15).ToString();
                customer.ProfileImage = dr.GetValue(16).ToString();
                customer.ProfilePic = dr.GetValue(17).ToString();
                customer.OTP = dr.GetValue(18).ToString();
            }
            
            con.Close();
            return customer;
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
                customer.Password = dr.GetValue(4).ToString();
                customer.Billing_Address = dr.GetValue(5).ToString();
                customer.Delivery_Address = dr.GetValue(6).ToString();
                customer.Land_Mark = dr.GetValue(7).ToString();
                customer.mobile1 = dr.GetValue(8).ToString();
                customer.mobile2 = dr.GetValue(9).ToString();
                customer.CustomerType = dr.GetValue(10).ToString();
                customer.DeliveryLocationLattitude = dr.GetValue(11).ToString();
                customer.DeliveryLocationLongitude = dr.GetValue(12).ToString();
                customer.CreateDate = dr.GetValue(13).ToString();
                customer.modifieddate = dr.GetValue(14).ToString();
                customer.Status = dr.GetValue(15).ToString();
                customer.ProfileImage = dr.GetValue(16).ToString();
                customer.ProfilePic = dr.GetValue(17).ToString();
                customer.OTP = dr.GetValue(18).ToString();

            }
          
            con.Close();
            return customer;

        }
    }
}