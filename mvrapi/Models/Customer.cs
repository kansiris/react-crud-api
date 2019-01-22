﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvrapi.Models
{
    public class Customer
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
        public float DeliveryLocationLattitude { get; set; }
        public float DeliveryLocationLongitude { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime modifieddate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
        public string Status { get; set; }
        public string ProfileImage { get; set; }
        public string ProfilePic { get; set; }
    }
}