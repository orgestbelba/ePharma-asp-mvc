using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Models
{
    public class ShoppingCartItem
    { 
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        //Product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //ShoppingCart
        public int ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }

    }
}
