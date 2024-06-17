namespace Project_Passion_BrenoSouza.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = string.Empty; // Default value
        public string Unit { get; set; } = string.Empty; // Default value

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>(); // Default value
        public virtual ICollection<Grocery> Groceries { get; set; } = new List<Grocery>(); // Default value
    }
}
