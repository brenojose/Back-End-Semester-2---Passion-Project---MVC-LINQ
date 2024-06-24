using Microsoft.AspNetCore.Mvc;
using Project_Passion_BrenoSouza.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Passion_BrenoSouza.Controllers
{
    public class GroceriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GroceriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

            // Deserialize the response into a list of groceries
            var groceries = JsonSerializer.Deserialize<List<Grocery>>(response);

            // Convert the data to match your model (this step may vary based on your actual API response and model)
            var groceryList = new List<Grocery>();
            foreach (var item in groceries)
            {
                groceryList.Add(new Grocery
                {
                    GroceryId = item.Id,
                    Name = item.Title,
                    Ingredient = new Ingredient { Name = "Sample Ingredient" } // Replace with actual data if available
                });
            }

            return View(groceryList);
        }

        // Other action methods for Create, Edit, Details, Delete would go here
    }

    // Assuming you have these classes defined in your Models folder
    public class Grocery
    {
        public int GroceryId { get; set; }
        public string Name { get; set; }
        public Ingredient Ingredient { get; set; }
    }

    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
    }
}
