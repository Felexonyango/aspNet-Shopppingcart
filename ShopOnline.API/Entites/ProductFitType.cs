using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ShopOnline.API.Entites;


public class ProductFitType
{
    public int ProductId { get; set; }
    public int FitTypeId { get; set; }

}
