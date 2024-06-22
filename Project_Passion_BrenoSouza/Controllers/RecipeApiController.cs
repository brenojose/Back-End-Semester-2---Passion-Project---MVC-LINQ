using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Passion_BrenoSouza.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Passion_BrenoSouza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeApiController : ControllerBase
    {
        //<summary>
        // The database context used to interact with the recipes and ingredients in the database.
        //</summary>
        private readonly ApplicationDbContext _context;

        //<summary>
        // Constructor for RecipeApiController that initializes the database context.
        //</summary>
        //<param name="context">The database context.</param>
        public RecipeApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //<summary>
        // Retrieves a list of recipes for a specific category.
        //</summary>
        //<param name="categoryId">The ID of the category to filter recipes.</param>
        //<returns>
        // An asynchronous task result containing a list of recipes for the specified category.
        //</returns>
        //<example>
        // GET: api/RecipeApi/ListRecipesForCategory/{categoryId}
        //</example>
        [HttpGet("ListRecipesForCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> ListRecipesForCategory(int categoryId)
        {
            return await _context.Recipes.Where(r => r.CategoryId == categoryId).ToListAsync();
        }

        //<summary>
        // Retrieves a list of ingredients for a specific recipe.
        //</summary>
        //<param name="recipeId">The ID of the recipe to filter ingredients.</param>
        //<returns>
        // An asynchronous task result containing a list of ingredients for the specified recipe.
        //</returns>
        //<example>
        // GET: api/RecipeApi/ListIngredientsForRecipe/{recipeId}
        //</example>
        [HttpGet("ListIngredientsForRecipe/{recipeId}")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> ListIngredientsForRecipe(int recipeId)
        {
            var ingredients = await _context.RecipeIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .Select(ri => ri.Ingredient)
                .ToListAsync();

            return ingredients;
        }

        //<summary>
        // Adds an ingredient to a specific recipe.
        //</summary>
        //<param name="recipeId">The ID of the recipe to add the ingredient.</param>
        //<param name="ingredientId">The ID of the ingredient to be added.</param>
        //<returns>
        // A success response upon successful addition of the ingredient to the recipe.
        //</returns>
        //<example>
        // POST: api/RecipeApi/AddIngredientToRecipe
        //</example>
        [HttpPost("AddIngredientToRecipe")]
        public async Task<IActionResult> AddIngredientToRecipe(int recipeId, int ingredientId)
        {
            var recipeIngredient = new RecipeIngredient { RecipeId = recipeId, IngredientId = ingredientId };
            _context.RecipeIngredients.Add(recipeIngredient);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //<summary>
        // Removes an ingredient from a specific recipe.
        //</summary>
        //<param name="recipeId">The ID of the recipe to remove the ingredient from.</param>
        //<param name="ingredientId">The ID of the ingredient to be removed.</param>
        //<returns>
        // A success response upon successful removal of the ingredient from the recipe.
        //</returns>
        //<example>
        // DELETE: api/RecipeApi/RemoveIngredientFromRecipe
        //</example>
        [HttpDelete("RemoveIngredientFromRecipe")]
        public async Task<IActionResult> RemoveIngredientFromRecipe(int recipeId, int ingredientId)
        {
            var recipeIngredient = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            _context.RecipeIngredients.Remove(recipeIngredient);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
