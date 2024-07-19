namespace Menu.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public List<DishIngredient>? DishIngredients { get; set; }
    }
}
