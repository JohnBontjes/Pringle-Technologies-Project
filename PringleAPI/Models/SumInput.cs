using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Web;

namespace PringleAPI.Models
{
    /// <summary>
    /// a pair of integers to be summed
    /// </summary>
    public class SumInput
    {
        /// <summary>
        /// integer to be summed
        /// </summary>
        [Required]
        public int x { get; set; }
        /// <summary>
        /// integer 2 to be summed
        /// </summary>
        [Required]
        public int y { get; set; }
    }
}