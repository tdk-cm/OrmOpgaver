namespace OpgaverApi.Sections.Models
{
    public class NewCocktailIngredientModel
    {
        public string IngredientName { get; set; }
        public QuantityType quantityType { get; set; }
        public int QuantityAmount { get; set; }
    }
}
