namespace Project_Passion_BrenoSouza.Models
{
    public class Ingredient
    {
        //<summary>
        // The unique identifier for the ingredient.
        //</summary>
        public int IngredientId { get; set; }

        //<summary>
        // The name of the ingredient.
        //</summary>
        public string Name { get; set; } = string.Empty; // Default value

        //<summary>
        // The unit of measurement for the ingredient.
        //</summary>
        public string Unit { get; set; } = string.Empty; // Default value

        //<summary>
        // The collection of recipe ingredients associated with this ingredient.
        //</summary>
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>(); // Default value

        //<summary>
        // The collection of groceries associated with this ingredient.
        //</summary>
        public virtual ICollection<Grocery> Groceries { get; set; } = new List<Grocery>(); // Default value
    }
}
