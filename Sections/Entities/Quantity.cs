using OpgaverApi.Sections.Models;
using System.ComponentModel.DataAnnotations;

namespace OpgaverApi.Sections.Entities
{
    public class Quantity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public QuantityType Type { get; set; }

        [Required]
        public int Amount { get; set; }

        
        public CocktailIngredient CocktailIngredient { get; set; }

      
        public CocktailRecipe CocktailRecipe { get; set; }
    }
}
