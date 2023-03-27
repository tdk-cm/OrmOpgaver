using System.ComponentModel.DataAnnotations;

namespace OpgaverApi.Sections.Entities
{
    public class CocktailRecipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<CocktailIngredient> Ingredients { get; set; }

    }
}
