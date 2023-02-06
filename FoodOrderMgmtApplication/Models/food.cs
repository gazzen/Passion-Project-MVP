using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodOrderMgmtApplication.Models
{
    public class food

    {
        [Key]
        public int FoodId { get; set; }

        public int FoodCategory { get; set; }

        public string FoodName { get; set; }

        public double FoodPrice { get; set; }
      
        public int FoodQty { get; set; }

        //Food belongs to order

        [ForeignKey("Order")]

        public int OrderId { get; set; }

        public virtual order Order { get; set; }


        //DTO

        public class foodDto
        {
            public int FoodId { get; set; }

            public int FoodCategory { get; set; }

            public string FoodName { get; set; }

            public double FoodPrice { get; set; }

            public int FoodQty { get; set; }

            public int OrderId { get; set; }

        }



    }
}