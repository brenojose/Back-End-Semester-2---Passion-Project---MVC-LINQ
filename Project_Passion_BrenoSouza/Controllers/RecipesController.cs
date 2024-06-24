using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Passion_BrenoSouza.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Passion_BrenoSouza.Controllers
{
    public class RecipesController : Controller
    {
        //<summary>
        // The database context used to interact with the recipes and categories in the database.
        //</summary>
        private readonly ApplicationDbContext _context;

        //<summary>
        // Constructor for RecipesController that initializes the database context.
        //</summary>
        //<param name="context">The database context.</param>
        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //<summary>
        // Displays a list of all recipes.
        //</summary>
        //<returns>
        // The Index view with a list of recipes.
        //</returns>
        //<example>
        // GET: Recipes
        //</example>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recipes.Include(r => r.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        //<summary>
        // Displays the details of a specific recipe.
        //</summary>
        //<param name="id">The ID of the recipe to display details for.</param>
        //<returns>
        // The Details view with the recipe details, or NotFound if the recipe does not exist.
        //</returns>
        //<example>
        // GET: Recipes/Details/5
        //</example>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        //<summary>
        // Displays the create recipe form.
        //</summary>
        //<returns>
        // The Create view.
        //</returns>
        //<example>
        // GET: Recipes/Create
        //</example>
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        //<summary>
        // Handles the submission of the create recipe form.
        //</summary>
        //<param name="recipe">The recipe object to be created.</param>
        //<returns>
        // Redirects to the Index view upon successful creation, or displays the Create view with validation errors.
        //</returns>
        //<example>
        // POST: Recipes/Create
        //</example>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,Title,Description,CategoryId,ImageUrl,Instructions")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", recipe.CategoryId);
            return View(recipe);
        }

        //<summary>
        // Displays the edit recipe form for a specific recipe.
        //</summary>
        //<param name="id">The ID of the recipe to edit.</param>
        //<returns>
        // The Edit view with the recipe details, or NotFound if the recipe does not exist.
        //</returns>
        //<example>
        // GET: Recipes/Edit/5
        //</example>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", recipe.CategoryId);
            return View(recipe);
        }

        //<summary>
        // Handles the submission of the edit recipe form.
        //</summary>
        //<param name="id">The ID of the recipe to edit.</param>
        //<param name="recipe">The recipe object with updated details.</param>
        //<returns>
        // Redirects to the Index view upon successful edit, or displays the Edit view with validation errors.
        //</returns>
        //<example>
        // POST: Recipes/Edit/5
        //</example>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Title,Description,CategoryId,ImageUrl,Instructions")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", recipe.CategoryId);
            return View(recipe);
        }

        //<summary>
        // Displays the delete confirmation page for a specific recipe.
        //</summary>
        //<param name="id">The ID of the recipe to delete.</param>
        //<returns>
        // The Delete view with the recipe details, or NotFound if the recipe does not exist.
        //</returns>
        //<example>
        // GET: Recipes/Delete/5
        //</example>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        //<summary>
        // Handles the deletion of a specific recipe.
        //</summary>
        //<param name="id">The ID of the recipe to delete.</param>
        //<returns>
        // Redirects to the Index view upon successful deletion.
        //</returns>
        //<example>
        // POST: Recipes/Delete/5
        //</example>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //<summary>
        // Checks if a recipe with the specified ID exists in the database.
        //</summary>
        //<param name="id">The ID of the recipe to check.</param>
        //<returns>True if the recipe exists, otherwise false.</returns>
        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }

        // Action to mark a recipe as favorite
        [HttpPost]
        public async Task<IActionResult> ToggleFavorite(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            recipe.IsFavorite = !recipe.IsFavorite;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Action to view favorite recipes
        public async Task<IActionResult> Favorites()
        {
            var favoriteRecipes = await _context.Recipes.Where(r => r.IsFavorite).ToListAsync();
            return View(favoriteRecipes);
        }

        // Action to handle search
        public async Task<IActionResult> Search(string query)
        {
            var recipes = string.IsNullOrEmpty(query)
                ? await _context.Recipes.Include(r => r.Category).ToListAsync()
                : await _context.Recipes
                    .Include(r => r.Category)
                    .Where(r => r.Title.Contains(query) || r.Description.Contains(query) || r.RecipeIngredients.Any(i => i.Ingredient.Name.Contains(query)))
                    .ToListAsync();

            return View("Index", recipes); // Reuse the Index view to display search results
        }
    }
}
