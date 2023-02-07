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
//using System.Web.Mvc;
using FoodOrderMgmtApplication.Models;

namespace FoodOrderMgmtApplication.Controllers
{
    public class OrderDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/OrderData/Listorders
        [HttpGet]
        public IEnumerable<orderDto> ListOrders()
        {
            List<order> Orders = db.Orders.ToList();

            List<orderDto> orderDtos = new List<orderDto>();

            Orders.ForEach(a => orderDtos.Add(new orderDto()
            {
                OrderId = a.OrderId,
                OrderQty = a.OrderQty,
                CustomerId = a.Customer.CustomerId
             
            }));
            return orderDtos;
            
        }

        // GET: api/OrderData/Findorder/5
        [ResponseType(typeof(order))]
        [HttpGet]
        public IHttpActionResult Findorder(int id)
        {

            order order = db.Orders.Find(id);
            orderDto orderDto = new orderDto();
            {
                OrderId = order.OrderId,
                OrderQty =order.OrderQty
            }
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        //POST/ PUT: api/OrderData/Updateorder/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Updateorder(int id, order order)
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Order Update is done!");
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                Debug.WriteLine("ID mismatched!");
                Debug.WriteLine("GET parameter!"+id);
                Debug.WriteLine("POST parameter!"+ order.OrderId);
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderExists(id))
                {
                    Debug.WriteLine("Order not found!");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Debug.WriteLine("None of condition triggered!");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderData/AddOrder
        [ResponseType(typeof(order))]
        [HttpPost]
        public IHttpActionResult Addorder(order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.OrderId }, order);
        }

        // DELETE: api/OrderData/Deleteorder/5
        [ResponseType(typeof(order))]
        [HttpPost]
        public IHttpActionResult Deleteorder(int id)
        {
            order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool orderExists(int id)
        {
            return db.Orders.Count(e => e.OrderId == id) > 0;
        }
    }
}