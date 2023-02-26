using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrderMgmtApplication.Models
{
    public class order
    {
        [Key]
        public int OrderId { get; set; }

        public int OrderQty { get; set; }

        //Importing Foreign key from customer Table
        //Order belongs to customer

        [ForeignKey("Customer")]

        public int CustomerId { get; set; }

        public virtual customer Customer { get; set; }

        public int FoodId { get; set; }



        [ForeignKey("Food")]

        public virtual customer Food { get; set; }

        //a order has  many food orders

        public ICollection<food> Foods { get; set; }



    }

    //DTO
    public class orderDto
    {
        public int OrderId { get; set; }

        public int OrderQty { get; set; }

        public int CustomerId { get; set; }

        public int FoodId { get; set; }

    }
    
}