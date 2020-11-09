using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PringleAPI.Models
{
    /// <summary>
    /// Object containing information required to delete a customer record
    /// </summary>
    public class DeleteInfoDTO
    {
        /// <summary>
        /// Api-Key corresponding to the recored to be removed
        /// Customer should have this and be keeping it secret
        /// </summary>
        [Required]
        public Guid ApiKey { get; set; }
    }
}