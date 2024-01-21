using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
	public class CheckoutBase: ComponentBase
	{
        [Inject]
        public IJSRuntime JSRuntime{ get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public IEnumerable<CartItemDto> CartItems{ get; set; }

        public decimal PaymentAmount { get; set; }
        public string PaymentDescription { get; set; }
		public decimal ShippingCost { get; set; } = 50;
        public decimal SubTotal { get; set; }
        public int TotalQty { get; set; }

        protected override async Task OnInitializedAsync()
		{
			try
			{
				CartItems = await ShoppingCartService.GetAll(1);

				if (CartItems != null)
				{
					Guid orderId = Guid.NewGuid();
                    SubTotal = CartItems.Sum(x => x.TotalPrice);
					TotalQty = CartItems.Sum(x => x.Qty);
					PaymentDescription = $"O_{orderId}_{1}";
					PaymentAmount = SubTotal + ShippingCost;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (firstRender)
			{
				await JSRuntime.InvokeVoidAsync("initPayPalButton");
			}
		}
	}
}
