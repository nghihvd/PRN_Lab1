using PRN232.Lab1.CoffeeStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Service.RequestModels
{
    public class ProductInMenuRequestModel
    {
        public string? ProductId { get; set; }
        public string? MenuId { get; set; }
        public int Quantity { get; set; }
    }
}
