using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PringleAPI.Models
{
    /// <summary>
    /// Body of the request to update open and closing times for customer
    /// </summary>
    public class TimeUpdateDTO
    {
        /// <summary>
        /// Customer's ApiKey
        /// </summary>
        [Required]
        public Guid ApiKey { get; set; }
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