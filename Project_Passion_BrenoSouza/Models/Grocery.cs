namespace Project_Passion_BrenoSouza.Models
{
    public class Grocery
    {
        //<summary>
        // The unique identifier for the grocery item.
        //</summary>
        public int GroceryId { get; set; }

        //<summary>
        // The name of the grocery item.
        //</summary>
        public string Name { get; set; } = string.Empty;

        //<summary>
        // The ID of the associated ingredient.
        //</summary>
        public int IngredientId { get; set; }

        //<summary>
        // The associated Ingredient entity.
        //</summary>
        public virtual Ingredient Ingredient { get; set; }
    }
}
