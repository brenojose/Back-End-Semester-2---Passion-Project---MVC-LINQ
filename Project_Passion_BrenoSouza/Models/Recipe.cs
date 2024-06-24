namespace Project_Passion_BrenoSouza.Models
{
    public class Recipe
    {
        //<summary>
        // The unique identifier for the recipe.
        //</summary>
        public int RecipeId { get; set; }

        //<summary>
        // The title of the recipe.
        //</summary>
        public string Title { get; set; } = string.Empty;

        //<summary>
        // The description of the recipe.
        //</summary>
        public string Description { get; set; } = string.Empty;

        //<summary>
        // The ID of the category the recipe belongs to.
        //</summary>
        public int CategoryId { get; set; }

        //<summary>
        // The URL of the recipe's image.
        //</summary>
        public string ImageUrl { get; set; } = string.Empty;

        //<summary>
        // The instructions for preparing the recipe.
        //</summary>
        public string Instructions { get; set; } = string.Empty;

        //<summary>
        // The associated Category entity.
        //</summary>
        public virtual Category Category { get; set; }

        //<summary>
        // The collection of recipe ingredients associated with this recipe.
        //</summary>
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

        //<summary>
        // Indicates whether the recipe is a favorite.
        //</summary>
        public bool IsFavorite { get; set; } // New property
    }
}
