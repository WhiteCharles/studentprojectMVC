using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Guid RecordId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Record Record { get; set; }
        public Order Order { get; set; }
    }
}
