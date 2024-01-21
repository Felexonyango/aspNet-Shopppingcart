using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Entites
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        public int Qty { get; set; }

        [Precision(8, 2)]
        public decimal Price { get; set; }

        public List<Category> Categories { get; set; } = new();
        public List<ProductImage> Images { get; set; } = new();
        public List<Size> Sizes{ get; set; } = new();
        public List<FitType> FitTypes { get; set; } = new();
    }
}
