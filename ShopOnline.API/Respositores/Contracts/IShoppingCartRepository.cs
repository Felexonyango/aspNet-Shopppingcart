namespace ShopOnline.API.Respositores.Contracts
{
	public interface IShoppingCartRepository
	{
		Task<CartItem> AddItem(CartItemToAddDto itemToAdd);
		Task<CartItem> RemoveItem(int id);
		Task<CartItem> GetItem(int id);
		Task<CartItem> UpdateItem(int cartItemId, CartItemToUpdateDto itemToUpdate);
		Task<IEnumerable<CartItem>> GetAll(int userId);
	}
}
