using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrderMgmtApplication.Models.ViewModels
{
    public class UpdateCustomer
    {
        public customerDto SelectedCustomer { get; set; }


        public IEnumerable<foodDto> FoodOptions { get; set; }

    }
}