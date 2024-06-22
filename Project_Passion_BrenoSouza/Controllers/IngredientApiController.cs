using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Passion_BrenoSouza.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Passion_BrenoSouza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientApiController : ControllerBase
    {
        //<summary>
        // The database context used to interact with the ingredients in the database.
        //</summary>
        private readonly ApplicationDbContext _context;

        //<summary>
        // Constructor for IngredientApiController that initializes the database context.
        //</summary>
        //<param name="context">The database context.</param>
        public IngredientApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //<summary>
        // Retrieves all ingredients from the database.
        //</summary>
        //<returns>
        // An asynchronous task result containing a list of all ingredients.
        //</returns>
        //<example>
        // GET: api/IngredientApi/GetAll
        //</example>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetAllIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }
    }
}
