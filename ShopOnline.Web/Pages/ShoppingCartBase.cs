using System.CodeDom.Compiler;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Serialization;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
	public class ShoppingCartBase: ComponentBase
	{
        [Inject]
        public IShoppingCartService CartService { get; set; }

        public List<CartItemDto> CartItems{ get; set; }

		public decimal TotalPrice { get; set; } = 0;
		public int TotalQuantity { get; set; } = 0;

        public string? ErrorMessage { get; set; }

		protected override async Task OnInitializedAsync()
		{
			try
			{
				CartItems = await CartService.GetAll(1);
				setCartSummary();
            }

			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}

		private void setCartSummary()
		{
			setTotalPrice();
			setTotalQty();
        }

		private void setTotalPrice()
		{
            TotalPrice = CartItems.Sum(x => x.TotalPrice);
        }
        private void setTotalQty()
        {
            TotalQuantity = CartItems.Sum(x => x.Qty);
        }

        private void RemoveItem_UIReflection(int cartItemId)
		{
			var cartItem = CartItems
				.FirstOrDefault(x => x.Id == cartItemId);

			CartItems.Remove(cartItem);
			setCartSummary();
        }
        public async Task RemoveItem_Click(int cartItemId)
		{
			var cartItem = await CartService.RemoveItem(cartItemId);
			RemoveItem_UIReflection(cartItemId);
		}

		public async Task UpdateItem_Click(int cartItemId, int qty)
		{
			if (qty == 0)
			{
				await RemoveItem_Click(cartItemId);
			}
			else
			{
				var cartItem = await CartService
					.UpdateItem(new CartItemToUpdateDto { Id = cartItemId, Qty = qty });
				UpdateItem_UIReflection(cartItemId, qty);

            }

        }
		private void UpdateItem_UIReflection(int cartItemId, int qty)
		{
			var cartItem = CartItems.Find(x => x.Id == cartItemId);
			cartItem.Qty = qty;
			cartItem.TotalPrice = cartItem.Price * cartItem.Qty;
			setCartSummary();
        }




    }
}
