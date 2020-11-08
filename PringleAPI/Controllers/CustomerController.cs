using PringleAPI.Exceptions;
using PringleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace PringleAPI.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllData()
        {
            return Ok();
        }

        /// <summary>
        /// add 2 numbers
        /// </summary>
        /// <param name="inputs">Inputs to the addition</param>
        /// <returns>
        /// sum of integers from the request.
        /// </returns>
        [HttpPost]
        public IHttpActionResult Add([FromBody] SumInput inputs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(new IntResult { result = inputs.x + inputs.y }) ;
        }
    }
}
