using PringleAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PringleAPI.Models
{
    // class to map to when preparing to send data to user
    // it's essentially the Customers entity without the Key field
    public class CustomerModel
    {
        public CustomerModel(Customers customer)
        {
            Name = customer.Name;
            Address = customer.Address;
            Address2 = customer.Address2;
            City = customer.City;
            State = customer.State;
            Country = customer.Country;
            Zipcode = customer.Zipcode;
            Phone = customer.Phone;
            OpenTime = customer.OpenTime;
            CloseTime = customer.CloseTime;
        }
        public CustomerModel()
        {

        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}