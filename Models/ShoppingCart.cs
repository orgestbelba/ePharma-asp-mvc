using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        //User
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        //ShoppingCartItems
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
