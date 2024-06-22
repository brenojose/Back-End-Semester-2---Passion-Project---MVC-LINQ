namespace Project_Passion_BrenoSouza.Models
{
    public class RecipeIngredient
    {
        //<summary>
        // The ID of the associated recipe.
        //</summary>
        public int RecipeId { get; set; }

        //<summary>
        // The ID of the associated ingredient.
        //</summary>
        public int IngredientId { get; set; }

        //<summary>
        // The associated Recipe entity.
        //</summary>
        public virtual Recipe Recipe { get; set; }

        //<summary>
        // The associated Ingredient entity.
        //</summary>
        public virtual Ingredient Ingredient { get; set; }
    }
}
