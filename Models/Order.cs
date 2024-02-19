using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePharma_asp_mvc.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime TimeOrdered { get; set; }
        public string PrescriptionPhoto { get; set; }
        public string Status { get; set; }

        //User
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //OrderItems
        public List<OrderItem> OrderItems { get; set; }
    }
}
