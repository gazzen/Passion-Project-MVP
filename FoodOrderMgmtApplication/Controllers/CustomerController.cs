using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using FoodOrderMgmtApplication.Migrations;
using FoodOrderMgmtApplication.Models;
using FoodOrderMgmtApplication.Models.ViewModels;

namespace FoodOrderMgmtApplication.Controllers
{
    public class CustomerController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static CustomerController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/api/customerdata ");
        }


        // GET: Customer/List
        public ActionResult List()
        {
            string url = "customerdata/listcustomers";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<customerDto> animals = response.Content.ReadAsAsync<IEnumerable<customerDto>>().Result;

            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {

            DetailsCustomers ViewModel = new DetailsCustomers();

            //objective: communicate with our animal data api to retrieve one animal
            //curl https://localhost:44318/api/customerdata/findcustomer/{id}

            string url = "customerdata/findcustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            customerDto SelectedCustomer = response.Content.ReadAsAsync<customerDto>().Result;
            Debug.WriteLine("animal received : ");
            Debug.WriteLine(SelectedCustomer.CustomerFirstName);

            ViewModel.SelectedCustomer = SelectedCustomer;

            


            return View(ViewModel);



            
        }

        // GET: Customer/New
        public ActionResult New()
        {

            //information about all species in the system.
            //GET api/customerdata/listcustomers

            string url = "customerdata/listcustomers";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<customerDto> Customers = response.Content.ReadAsAsync<IEnumerable<customerDto>>().Result;

            return View(Customers);
            
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            Debug.WriteLine("the json payload is :");
            //Debug.WriteLine(customer.CustomerFirtName);
            //objective: add a new customer into  system using the API
            //curl -H "Content-Type:application/json" -d @customer.json https://localhost:44318/api/customerdata/addcustomer 
            string url = "customerdata/addcustomer";


            string jsonpayload = jss.Serialize(customer);
            Debug.WriteLine(jsonpayload);
            
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }

        }


        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            UpdateCustomer ViewModel = new UpdateCustomer();

            //the existing customer information
            string url = "custmerdata/findcustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            customerDto SelectedCustomer = response.Content.ReadAsAsync<customerDto>().Result;
            ViewModel.SelectedCustomer = SelectedCustomer;

            

            return View(ViewModel);
        }

        // POST: Customer/Update/5
        [HttpPost]
        public ActionResult Update(int id, Customer customer)
        {
            string url = "customerdata/updatecustomer/" + id;
            string jsonpayload = jss.Serialize(customer);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            Debug.WriteLine(content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Customer/Delete/5
        public ActionResult DeleteConfirm(int id)
        {

            string url = "customerdata/findacustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            customerDto SelectedCustomer = response.Content.ReadAsAsync<customerDto>().Result;
            return View(SelectedCustomer);
        }


        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "customerdata/deletecustomer/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }

    public class Customer
    {
    }
}
