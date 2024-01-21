using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Entites;

public class FitType
{
    public int Id { get; set; }
    [MaxLength(15)]
    public string Name { get; set; }

    public List<Product> Products { get; set; } = new();

}
