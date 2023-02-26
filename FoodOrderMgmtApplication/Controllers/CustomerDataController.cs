using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodOrderMgmtApplication.Models;
//using System.Diagnostics;

namespace FoodOrderMgmtApplication.Controllers
{
    public class CustomerDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CustomerData/Listcustomers
        [HttpGet]
        //public IEnumerable<customerDto> Listcustomers()
        public IHttpActionResult Listcustomers()
        {
            List<customer> Customers = db.Customers.ToList();

            List<customerDto> customerDtos = new List<customerDto>();

            Customers.ForEach(a => customerDtos.Add(new customerDto()
            {
                CustomerId = a.CustomerId,
                CustomerFirstName = a.CustomerFirstName,
                CustomerLastName = a.CustomerLastName,
                CustomerEmailId = a.CustomerEmailId,
                CustomerAddress = a.CustomerAddress,
                CustomerPhone = a.CustomerPhone
            }));
            return Ok(customerDtos);
        }

        // GET: api/CustomerData/Findcustomer/5
        [ResponseType(typeof(customer))]
        [HttpGet]
        public IHttpActionResult Findcustomer(int id)
        {
            customer customer = db.Customers.Find(id);
            customerDto customerDto = new customerDto()
            {
                CustomerId = customer.CustomerId,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CustomerEmailId = customer.CustomerEmailId,
                CustomerAddress = customer.CustomerAddress,
                CustomerPhone = customer.CustomerPhone
            };
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customerDto);
        }

        // POST/UPDATE/PUT: api/CustomerData/Update/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Updatecustomer(int id, customer customer)
        {
            Debug.WriteLine("Customer Update is done!");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model state is Invalid!");
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                Debug.WriteLine("Id Mismatched!");
                Debug.WriteLine("GET parameter!"+id);
                Debug.WriteLine("POST parameter!"+ customer.CustomerId);
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerExists(id))
                {
                    Debug.WriteLine("Customer not found!");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Debug.WriteLine("None of condition Triggered!");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerData/Addcustomer
        [ResponseType(typeof(customer))]
        [HttpPost]
        public IHttpActionResult Addcustomer(customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        // POST/DELETE: api/CustomerData/Deletecustomer/5
        [ResponseType(typeof(customer))]
        [HttpPost]
        public IHttpActionResult Deletecustomer(int id)
        {
            customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool customerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerId == id) > 0;
        }
    }
}