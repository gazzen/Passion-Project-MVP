using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrderMgmtApplication.Models.ViewModels
{
    public class DetailsCustomers
    {

        public customerDto SelectedCustomer { get; set; }
        public IEnumerable<orderDto> ResponsiblOrders { get; set; }

       


    }
}