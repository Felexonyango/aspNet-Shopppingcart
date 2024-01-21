using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Entites;

public class City
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
}
