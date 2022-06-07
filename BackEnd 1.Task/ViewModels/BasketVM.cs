using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_1.Task.ViewModels
{
    public class BasketVM
    {
        public List<BasketItemVM> BasketItems { get; set; }

        [Column(TypeName = "decimal(6,2")]
        public decimal TotalPrice { get; set; }

        public int Count { get; set; }

        public BasketVM()
        {
            BasketItems = new List<BasketItemVM>();
        }


    }
}
