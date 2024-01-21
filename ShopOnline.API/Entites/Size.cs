using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Entites;

public class Size
{
    public int Id { get; set; }
    [MaxLength(5)]
    public string Name { get; set; }

    public List<Product> Products { get; set; } = new();
}

