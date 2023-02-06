using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodOrderMgmtApplication.Models;

namespace FoodOrderMgmtApplication.Controllers
{
    public class FoodDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FoodData/Listfoods
        [HttpGet]
        public IEnumerable<food> ListFoods()
        {
            List<food> Foods = db.Foods.ToList();
            List<foodDto> foodDtos = new List<foodDto>();

            Foods.ForEach(b => foodDtos.Add(new foodDto()
            {
                FoodId = b.FoodId,
                Foodame = b.FoodName,
                FoodCategory = b.FoodCategory,
                FoodPrice = b.FoodPrice,
                FoodQty = b.FoodQty,
                OrderId = b.OrderId

            }));
            return foodDtos;
        }

        // GET: api/FoodData/Findfood/5
        [ResponseType(typeof(food))]
        [HttpGet]
        public IHttpActionResult Findfood(int id)
        {
            food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // PUT: api/FoodData/Update/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Updatefood(int id, food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food.FoodId)
            {
                return BadRequest();
            }

            db.Entry(food).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!foodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FoodData/Addfood
        [ResponseType(typeof(food))]
        [HttpPost]
        public IHttpActionResult Postfood(food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Foods.Add(food);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = food.FoodId }, food);
        }

        // DELETE: api/FoodData/Deletefood/5
        [ResponseType(typeof(food))]
        [HttpPost]
        public IHttpActionResult Deletefood(int id)
        {
            food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            db.Foods.Remove(food);
            db.SaveChanges();

            return Ok(food);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool foodExists(int id)
        {
            return db.Foods.Count(e => e.FoodId == id) > 0;
        }
    }
}