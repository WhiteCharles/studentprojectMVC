using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Models
{
    public class ShoppingCartItem
    {
        public Guid ShoppingCartItemId { get; set; }
        public Record Record { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
