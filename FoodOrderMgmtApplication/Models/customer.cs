using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderMgmtApplication.Models
{
    public class customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPhone { get; set; }
     
        public string CustomerAddress { get; set; }

      

        //a customer has may has many orders

        public ICollection<order> Orders { get; set; }
        //public ICollection<food> Foods { get; set; }


    }

    //DTO:data transfer object

    public class customerDto
    {
        public int CustomerId { get; set; }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPhone { get; set; }

        public string CustomerAddress { get; set; }
    }
}