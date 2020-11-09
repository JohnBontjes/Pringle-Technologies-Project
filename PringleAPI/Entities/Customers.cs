using PringleAPI.Models;
using System;
using System.Collections.Generic;

namespace PringleAPI.Entities
{
    public partial class Customers
    {
        public Customers(){}
        public Customers(NewCustomer customer, Guid apikey)
        {
            Key = apikey.ToString();
            Name = customer.Name;
            Address = customer.Address;
            City = customer.City;
            State = customer.State;
            Country = customer.Country;
            Zipcode = customer.Zipcode;
            Phone = customer.Phone;
            OpenTime = customer.OpenTime;
            CloseTime = customer.CloseTime;
        }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
