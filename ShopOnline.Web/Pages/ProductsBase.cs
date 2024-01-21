using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductsBase: ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProducts();
        }

        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetProductsGroupedByCategory()
        {
            return Products
                    .GroupBy(p => p.CategoryId)
                    .OrderBy(k => k.Key);
        }

        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductsDto)
        {
            return groupedProductsDto.FirstOrDefault(x => x.CategoryId == groupedProductsDto.Key).CategoryName;
        }
        
    }
}
