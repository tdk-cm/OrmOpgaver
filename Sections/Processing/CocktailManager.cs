using Microsoft.EntityFrameworkCore;
using OpgaverApi.Sections.Contex;
using OpgaverApi.Sections.Entities;
using OpgaverApi.Sections.Models;

namespace OpgaverApi.Sections.Processing
{
    public class CocktailManager
    {
        CocktailContext _context;

        public CocktailManager(CocktailContext dbContext)
        {
            _context = dbContext;
        }

        public Cocktail MakeCocktail(string requestedName)
        {
            Cocktail cocktail = new Cocktail();
            cocktail.CocktailName = requestedName;

            CocktailRecipe recipe = _context.Recipes.FirstOrDefault(x => x.Name.Equals(cocktail.CocktailName));
            recipe.Ingredients = _context.Recipes.Where(x => x.Name.Equals(cocktail.CocktailName)).SelectMany(i => i.Ingredients).ToList();
            var quantities = _context.Quantities.Where(x => x.CocktailRecipe.Id == recipe.Id);

            foreach(CocktailIngredient ing in recipe.Ingredients)
            {
                var quantity = quantities.FirstOrDefault(x => x.CocktailIngredient.Id == ing.Id);

                cocktail.Ingredients.Add(BuildIngredientLine(ing, quantity));
            }

            return cocktail;
        }

        private string BuildIngredientLine(CocktailIngredient ing, Quantity q)
        {
            string returnString = "";

            switch (q.Type)
            {
                case QuantityType.NotSpecified:
                    return ing.Name;

                case QuantityType.Segment:
                    return returnString;

                case QuantityType.Rim:
                    return returnString;

                case QuantityType.Milliliters:
                    return $"{ing.Name}, {q.Amount}ml";

                case QuantityType.Whole: 
                    return returnString;

                default:
                    return returnString;
            }
        }
    }
}
