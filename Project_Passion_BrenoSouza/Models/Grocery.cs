namespace Project_Passion_BrenoSouza.Models
{
    public class Grocery
    {
        public int GroceryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
