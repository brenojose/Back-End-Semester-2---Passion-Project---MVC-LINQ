using Microsoft.EntityFrameworkCore;

namespace Project_Passion_BrenoSouza.Models
{
    public class ApplicationDbContext : DbContext
    {
        //<summary>
        // DbSet for Recipe entities.
        //</summary>
        public DbSet<Recipe> Recipes { get; set; }

        //<summary>
        // DbSet for Category entities.
        //</summary>
        public DbSet<Category> Categories { get; set; }

        //<summary>
        // DbSet for Ingredient entities.
        //</summary>
        public DbSet<Ingredient> Ingredients { get; set; }

        //<summary>
        // DbSet for RecipeIngredient entities.
        //</summary>
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        //<summary>
        // DbSet for Grocery entities.
        //</summary>
        public DbSet<Grocery> Groceries { get; set; }

        //<summary>
        // Constructor for ApplicationDbContext that initializes the DbContext with options.
        //</summary>
        //<param name="options">The options for configuring the DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //<summary>
        // Configures the entity relationships and keys using the ModelBuilder.
        //</summary>
        //<param name="modelBuilder">The ModelBuilder instance used to configure the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configures the relationship between Recipe and Category entities.
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId);

            // Configures the composite primary key for RecipeIngredient entities.
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            // Configures the relationship between RecipeIngredient and Recipe entities.
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            // Configures the relationship between RecipeIngredient and Ingredient entities.
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            // Configures the relationship between Grocery and Ingredient entities.
            modelBuilder.Entity<Grocery>()
                .HasOne(g => g.Ingredient)
                .WithMany(i => i.Groceries)
                .HasForeignKey(g => g.IngredientId);
        }
    }
}
