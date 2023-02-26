using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

//using FoodOrderMgmtApplication.Models.ViewModels;
using System.Web.Script.Serialization;

using FoodOrderMgmtApplication.Models;

namespace FoodOrderMgmtApplication.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food/List
        public ActionResult List()
        {
            HttpClient client= new HttpClient();
            string url = "https://localhost:44318/api/fooddata/listfoods";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is:");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<foodDto> animals = response.Content.ReadAsAsync<IEnumerable<foodDto>>().Result;

            return View();
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
