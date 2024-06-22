namespace Project_Passion_BrenoSouza.Models
{
    public class Category
    {
        //<summary>
        // The unique identifier for the category.
        //</summary>
        public int CategoryId { get; set; }

        //<summary>
        // The name of the category.
        //</summary>
        public string Name { get; set; } = string.Empty;

        //<summary>
        // The collection of recipes associated with this category.
        //</summary>
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
