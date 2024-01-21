using Microsoft.AspNetCore.Identity;

namespace ShopOnline.API.Entites
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
