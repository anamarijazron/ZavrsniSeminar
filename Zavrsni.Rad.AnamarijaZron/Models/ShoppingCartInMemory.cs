using System.Diagnostics.Contracts;
using System.Net.Http.Json;

namespace Zavrsni.Rad.AnamarijaZron.Models
{
    public class ShoppingCartInMemory
    {
        private readonly HttpClient _httpClient;
        public List<ShoppingCart> selectedItems { get; set; } = new();

        public ShoppingCartInMemory(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddToShoppingCart(int productId)
        {
            if (selectedItems
                .FirstOrDefault(x => x.ProductId == productId) == null)
            {
                var result = await _httpClient
                    .GetAsync($"https://expertshopapi.azurewebsites.net/api/Products/{productId}");

                if (result.IsSuccessStatusCode)
                {
                    var addProduct = await result.Content.ReadFromJsonAsync<Product>();
                    ShoppingCart addToList = new ShoppingCart();
                    addToList.Product = addProduct; ;
                    addToList.ProductId = addProduct.Id;
                    addToList.NumberOfItems = 1;
                    selectedItems.Add(addToList);
                }
            }
        }
    }
}