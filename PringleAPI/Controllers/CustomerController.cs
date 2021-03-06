﻿using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// Interact with the customer data in the system
    /// </summary>
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
            
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            if(search == null)
            {
                search = "";
            }
            using (var db = new CustomerInfoContext())
            {
                try
                {
                    // get all customers with name containing provided search term
                    var result = db.Customers.Where(i => i.Name.Contains(search)).Select(i => new CustomerModel(i)).AsQueryable();
                    return Ok(result.ToList());
                }
                catch(Exception e)
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
        public IHttpActionResult SpecificSearch([FromBody] CustomerSearchDTO searchParams)
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
                    // go through all possible params the user may have included as a search term
                    // if the param was provided, use it to filter out the possible results
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
                        filter = filter.Where(i => String.Compare(i.Zipcode, searchParams.Zipcode) == 0);
                    }

                    // map filtered results to CustomerModel objects to hide the api key from the output
                    var mapped = filter.Select(i => new CustomerModel(i)).AsQueryable();
                    return Ok(mapped.ToList());
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
        /// <summary>
        /// Add a new customer to the system
        /// </summary>
        /// <param name="customerInfo">Request body containing all necessary information to add the customer to the system</param>
        /// <returns>Object containing api-key</returns>
        [HttpPut]
        public IHttpActionResult CreateCustomer([FromBody] NewCustomerDTO customerInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changes = 0;
            // api key is a guid to make sure that they are unique and not easy to brute force
            var apikey = Guid.NewGuid();
            using (var db = new CustomerInfoContext())
            {
                try
                {
                    db.Customers.Add(new Customers(customerInfo, apikey));
                    changes = db.SaveChanges();
                }
                catch(Exception e)
                {
#if DEBUG
                    return InternalServerError(e);
#else
                    return InternalServerError();
#endif
                }
            }
            if (changes > 0)
            {
                return Ok(new { api_key = apikey });
            }
            else
            {
                return BadRequest("Oops! Something went wrong!");
            }
        }
        /// <summary>
        /// Update opening and closing times of your restaurant
        /// </summary>
        /// <param name="updates"> Request body containing api key and updated times </param>
        /// <returns>Entire customer record including updated times</returns>
        [HttpPatch]
        public IHttpActionResult UpdateTimes([FromBody] TimeUpdateDTO updates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changes = 0;
            using (var db = new CustomerInfoContext())
            {
                try
                {
                    // get customer matching apikey provided
                    var customer = db.Customers.First(i => i.Key == updates.ApiKey.ToString());
                    // update times
                    customer.OpenTime = updates.OpenTime;
                    customer.CloseTime = updates.CloseTime;
                    // save updates to db
                    changes = db.SaveChanges();
                    if (changes > 0)
                    {
                        return Ok(new CustomerModel(customer));
                    }
                    else
                    {
                        return BadRequest("Oops! Nothing got changed!");
                    }
                }
                catch (Exception e)
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
        /// Delete the customer information corresponding to the api key given
        /// </summary>
        /// <param name="toBeDeleted">Object containing the api-key for the customer record to be deleted</param>
        /// <returns>Response Code 200 </returns>
        [HttpDelete]
        public IHttpActionResult DeleteCustomer([FromBody] DeleteInfoDTO toBeDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changes = 0;
            using (var db = new CustomerInfoContext())
            {
                try
                {
                    // find the entry with the specified key
                    var toDelete = db.Customers.Where(i => i.Key == toBeDeleted.ApiKey.ToString()).First();
                    // delete entry
                    db.Customers.Remove(toDelete);
                    // save
                    changes = db.SaveChanges();
                }
                catch (Exception e)
                {
#if DEBUG
                    return InternalServerError(e);
#else
                    return InternalServerError();
#endif
                }
            }
            // database change failed
            if(changes == 0)
            {
                return BadRequest();
            }
            return Ok(new { Message = "Success" });
        }

    }
}
