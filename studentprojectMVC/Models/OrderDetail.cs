using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Guid RecordId { get; set; }  // int
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Record Record { get; set; }
        public Order Order { get; set; }
    }
}
