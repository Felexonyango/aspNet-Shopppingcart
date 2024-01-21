using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Enums;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
    public class ProductDetailsBase: ComponentBase
	{
        [Inject]
        public IProductService ProductService { get; set; }

		[Inject]
		public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

		public int Qty { get; set; } = 1;

		public void UpdateQuantity(int counter)
		{
			Qty = counter;
		}

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
		{
			try
			{
				Product = await ProductService.GetProductById(ProductId);
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}

		public async Task AddToCart_Click (CartItemToAddDto cartItemToAdd)
		{
			try
			{
				var cartItem = await ShoppingCartService.AddItem(cartItemToAdd);
				NavigationManager.NavigateTo("/ShoppingCart");
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
