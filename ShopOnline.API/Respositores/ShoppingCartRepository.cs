using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ShopOnline.API.Respositores
{
	public class ShoppingCartRepository : IShoppingCartRepository
	{
		private readonly AppDbContext context;

		public ShoppingCartRepository(AppDbContext context)
        {
			this.context = context;
		}

		private async Task<bool> CartItemExists (int cartId, int productId)
		{
			return await context.CartItems
				.AsNoTracking()
				.AnyAsync(x => x.ProductId == productId && x.CartId == cartId);
		}

        public async Task<CartItem> AddItem(CartItemToAddDto itemToAdd)
		{
			if (await CartItemExists(itemToAdd.CartId, itemToAdd.ProductId) == false)
			{
				var item = await
					(from product in context.Products
					 where product.Id == itemToAdd.ProductId
					 select new CartItem
					 {
						 CartId = itemToAdd.CartId,
						 ProductId = product.Id,
						 Qty = itemToAdd.Qty,
						 Product = product
					 })
					 .FirstOrDefaultAsync();


				if (item != null)
				{
					var result = await context.AddAsync(item);
					await context.SaveChangesAsync();
					return result.Entity;
				}
			}
			return null;
		}

		public async Task<IEnumerable<CartItem>> GetAll(int userId)
		{
			return await context.CartItems
				.AsNoTracking()
				.Include(c => c.Cart)
				.Include(c => c.Product)
				.Where(c => c.Cart.UserId == userId)
				.ToListAsync();

		}

		public async Task<CartItem> GetItem(int id)
		{
			return await context.CartItems
				.AsNoTracking()
				.AsSplitQuery()
				.Include(x => x.Cart)
				.Include(x => x.Product)
				.Where(x => x.Id == id)
				.SingleOrDefaultAsync();
		}

		public async Task<CartItem> RemoveItem(int id)
		{
			var cartItem = await context.CartItems
				.Include(x => x.Product)
				.FirstOrDefaultAsync(x => x.Id == id);

			if (cartItem != null)
			{
				context.CartItems.Remove(cartItem);
				await context.SaveChangesAsync();
			}
			return cartItem;

		}

		public async Task<CartItem> UpdateItem(int cartItemId, CartItemToUpdateDto itemToUpdate)
		{
			var cartItem = await context.CartItems
				.Include(x => x.Product)
				.SingleOrDefaultAsync(x => x.Id == cartItemId);

			if (cartItem is not null)
			{
				cartItem.Qty = itemToUpdate.Qty;
				await context.SaveChangesAsync();
			}
			return cartItem;
		}
	}
}
