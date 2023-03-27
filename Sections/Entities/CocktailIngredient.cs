using System.ComponentModel.DataAnnotations;

namespace OpgaverApi.Sections.Entities
{
    public class CocktailIngredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Icon { get; set; }

        public List<CocktailRecipe> cocktailRecipes { get; set; }
    }
}
