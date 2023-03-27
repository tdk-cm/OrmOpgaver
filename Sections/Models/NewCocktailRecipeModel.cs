using OpgaverApi.Sections.Entities;

namespace OpgaverApi.Sections.Models
{
    public class NewCocktailRecipeModel
    {
        public string CocktailName { get; set; }
        public List<NewCocktailIngredientModel> ingredients { get; set; }
    }
}
