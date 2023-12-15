using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        //Product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
