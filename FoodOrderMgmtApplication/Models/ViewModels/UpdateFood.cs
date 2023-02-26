using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrderMgmtApplication.Models.ViewModels
{
    public class UpdateFood
    {
        public foodDto SelectedFood { get; set; }


        public IEnumerable<foodDto> FoodOptions { get; set; }

    }
}