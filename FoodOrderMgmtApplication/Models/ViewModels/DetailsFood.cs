using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrderMgmtApplication.Models.ViewModels
{
    public class DetailsFood
    {

        public foodDto SelectedFoods { get; set; }


        public IEnumerable<orderDto> Relateorder { get; set; }
    }
}