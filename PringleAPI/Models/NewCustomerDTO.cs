using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PringleAPI.Models
{
    /// <summary>
    /// Information required to add a customer to the system
    /// </summary>
    public class NewCustomerDTO
    {
        /// <summary>
        /// Name of the customer's restaurant
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Street address of the customer's restaurant
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// Street address line 2 of the customer's restaurant
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// City for the Address field
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// State for the Address field
        /// </summary>
        [Required]
        [MinLength(2), MaxLength(2)]
        public string State { get; set; }
        /// <summary>
        /// Country for the Address field
        /// </summary>
        [Required]
        [MinLength(3), MaxLength(3)]
        public string Country { get; set; }
        /// <summary>
        ///  5 digit Zipcode for the Address field
        /// </summary>
        [Required]
        [MinLength(5), MaxLength(5)]
        public string Zipcode { get; set; }
        /// <summary>
        /// Phone number of the customer - Just the digits, no punctuation or parenthesis.
        /// ex: "0123456789"
        /// </summary>
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// Time the customer's restaurant opens
        /// </summary>
        [Required]
        public TimeSpan OpenTime { get; set; }
        /// <summary>
        /// Time the customer's restaurant closes
        /// </summary>
        [Required]
        public TimeSpan CloseTime { get; set; }
    }
}