using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient httpClient;

        public ShoppingCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


		public async Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAdd)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<CartItemToAddDto>
                    ($"api/ShoppingCart/AddItem", cartItemToAdd);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CartItemDto>> GetAll(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCart/GetAll/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<CartItemDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync ();
                    throw new Exception($"Http Status: {response.StatusCode} Message: {message}");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<CartItemDto> GetItem(int itemId)
        {
            throw new NotImplementedException();
        }

		public async Task<CartItemDto> RemoveItem(int itemId)
		{
            try
            {
                var response = await httpClient.DeleteAsync($"api/ShoppingCart/RemoveItem/{itemId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return default(CartItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var messsage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Status Code: {response.StatusCode} Message: {messsage}");
                }
                
            }
            catch (Exception)
            { 
                throw;
            }
		}

		public async Task<CartItemDto> UpdateItem(CartItemToUpdateDto cartItemToUpdate)
		{
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(cartItemToUpdate);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"api/ShoppingCart/UpdateItem/{cartItemToUpdate.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return default(CartItemDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

            }
            catch (Exception)
            {

                throw;
            }
		}
	}
}
