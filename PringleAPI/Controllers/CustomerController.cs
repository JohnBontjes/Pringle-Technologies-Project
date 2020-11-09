using Microsoft.EntityFrameworkCore;
using PringleAPI.Entities;
using PringleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Web.Http;

namespace PringleAPI.Controllers
{
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Get a list of customers matching search
        /// </summary>
        /// <param name="search">[Optional] String that all customer names in the response list must contain</param>
        /// <returns>A list of objects containing customer details</returns>
        [HttpGet]
        public IHttpActionResult GetAllMatchingCustomers([FromUri] String search = "")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var db = new CustomerInfoContext())
            {
                try
                {
                    var result = db.Customers.Where(i => i.Name.Contains(search)).Select(i => new CustomerModel(i));
                    return Ok(result.ToList());
                }catch(Exception e)
                {
#if DEBUG
                    return InternalServerError(e);
#else
                    return InternalServerError();
#endif
                }
            }
        }
        /// <summary>
        /// Search for a customer based on more specific criteria than a string the name contains
        /// </summary>
        /// <param name="searchParams">The parameters to match when doing the search</param>
        /// <returns>A list of objects containing customer's details</returns>
        [HttpPost]
        public IHttpActionResult SpecificSearch([FromBody] CustomerSearch searchParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            using (var db = new CustomerInfoContext())
            {
                try
                {
                    IQueryable<Customers> filter = db.Customers;
                    if(searchParams.Name != null)
                    {
                        filter = filter.Where(i => i.Name.Contains(searchParams.Name));
                    }
                    if(searchParams.City != null)
                    {
                        filter = filter.Where(i => i.City.Contains(searchParams.City));
                    }
                    if (searchParams.State != null)
                    {
                        filter = filter.Where(i => String.Compare(i.State, searchParams.State) == 0);
                    }
                    if (searchParams.Country != null)
                    {
                        filter = filter.Where(i => String.Compare(i.Country, searchParams.Country) == 0);
                    }
                    if (searchParams.Zipcode != null)
                    {
                        filter = filter.Where(i => i.Zipcode == searchParams.Zipcode);
                    }


                    var mapped = filter.Select(i => new CustomerModel(i)).AsQueryable();
                    return Ok(new
                    {
                        received = searchParams,
                        result = mapped.ToList()
                    });
                } catch(Exception e)
                {
#if DEBUG
                    return InternalServerError(e);
#else
                    return InternalServerError();
#endif
                }
            }
        }

    }
}
