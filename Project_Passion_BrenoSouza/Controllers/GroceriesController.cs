using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Project_Passion_BrenoSouza.Models;

/// <summary>
/// Groceries Controller to manage grocery-related actions.
/// </summary>
public class GroceriesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly HttpClient _httpClient;

    public GroceriesController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClient = httpClientFactory.CreateClient();
    }

    /// <summary>
    /// Lists all groceries.
    /// </summary>
    /// <returns>View with list of groceries.</returns>
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Groceries.Include(g => g.Ingredient);
        return View(await applicationDbContext.ToListAsync());
    }

    /// <summary>
    /// Shows details of a specific grocery.
    /// </summary>
    /// <param name="id">Grocery ID.</param>
    /// <returns>View with grocery details.</returns>
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var grocery = await _context.Groceries
            .Include(g => g.Ingredient)
            .FirstOrDefaultAsync(m => m.GroceryId == id);
        if (grocery == null)
        {
            return NotFound();
        }

        return View(grocery);
    }

    /// <summary>
    /// Renders the create grocery view.
    /// </summary>
    /// <returns>Create grocery view.</returns>
    public async Task<IActionResult> Create()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>("https://localhost:5001/api/IngredientApi/GetAll");
        ViewData["IngredientId"] = new SelectList(ingredients, "IngredientId", "Name");
        return View();
    }

    /// <summary>
    /// Creates a new grocery.
    /// </summary>
    /// <param name="grocery">Grocery to create.</param>
    /// <returns>Redirects to index if successful, otherwise returns the create view.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("GroceryId,Name,IngredientId")] Grocery grocery)
    {
        if (ModelState.IsValid)
        {
            _context.Add(grocery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>("https://localhost:5001/api/IngredientApi/GetAll");
        ViewData["IngredientId"] = new SelectList(ingredients, "IngredientId", "Name", grocery.IngredientId);
        return View(grocery);
    }

    /// <summary>
    /// Renders the edit grocery view.
    /// </summary>
    /// <param name="id">Grocery ID.</param>
    /// <returns>Edit grocery view.</returns>
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var grocery = await _context.Groceries.FindAsync(id);
        if (grocery == null)
        {
            return NotFound();
        }
        var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>("https://localhost:5001/api/IngredientApi/GetAll");
        ViewData["IngredientId"] = new SelectList(ingredients, "IngredientId", "Name", grocery.IngredientId);
        return View(grocery);
    }

    /// <summary>
    /// Updates a grocery.
    /// </summary>
    /// <param name="id">Grocery ID.</param>
    /// <param name="grocery">Updated grocery data.</param>
    /// <returns>Redirects to index if successful, otherwise returns the edit view.</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("GroceryId,Name,IngredientId")] Grocery grocery)
    {
        if (id != grocery.GroceryId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(grocery);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(grocery.GroceryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        var ingredients = await _httpClient.GetFromJsonAsync<IEnumerable<Ingredient>>("https://localhost:5001/api/IngredientApi/GetAll");
        ViewData["IngredientId"] = new SelectList(ingredients, "IngredientId", "Name", grocery.IngredientId);
        return View(grocery);
    }

    /// <summary>
    /// Renders the delete grocery view.
    /// </summary>
    /// <param name="id">Grocery ID.</param>
    /// <returns>Delete grocery view.</returns>
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var grocery = await _context.Groceries
            .Include(g => g.Ingredient)
            .FirstOrDefaultAsync(m => m.GroceryId == id);
        if (grocery == null)
        {
            return NotFound();
        }

        return View(grocery);
    }

    /// <summary>
    /// Deletes a grocery.
    /// </summary>
    /// <param name="id">Grocery ID.</param>
    /// <returns>Redirects to index if successful.</returns>
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var grocery = await _context.Groceries.FindAsync(id);
        _context.Groceries.Remove(grocery);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Checks if a grocery exists.
    /// </summary>
    /// <param name="id">Grocery ID.</param>
    /// <returns>True if grocery exists, otherwise false.</returns>
    private bool GroceryExists(int id)
    {
        return _context.Groceries.Any(e => e.GroceryId == id);
    }
}
