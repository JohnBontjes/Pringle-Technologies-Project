using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PringleAPI.Models
{
    /// <summary>
    /// Request Body for designating search parameters
    /// </summary>
    public class CustomerSearchDTO
    {
        /// <summary>
        /// Name of the restaurant, normal search string
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// City the restaurant is in, normal search string
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 2 letter abbreviation of the state the restaurant is in, exact matching
        /// </summary>
        [MinLength(2), MaxLength(2)]
        public string State { get; set; }
        /// <summary>
        /// 3 letter country code of the country the restaurant is in, exact matching
        /// </summary>
        [MinLength(3), MaxLength(3)]
        public string Country { get; set; }
        /// <summary>
        /// 5 digit zipcode the restaurant is in, exact matching
        /// </summary>
        [MinLength(5), MaxLength(5)]
        public string Zipcode { get; set; }
        
    }
}