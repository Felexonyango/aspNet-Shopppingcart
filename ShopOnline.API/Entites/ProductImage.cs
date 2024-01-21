using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.API.Entites;

public class ProductImage
{
    public int Id { get; set; }
    public int ProductId { get; set; }

    [MaxLength(1000)]
    public string ImageUrl { get; set; }

    public Product Product { get; set; }
}
