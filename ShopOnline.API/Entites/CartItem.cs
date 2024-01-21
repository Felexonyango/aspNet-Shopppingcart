using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Entites
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Qty { get; set; }
        
    }
}
