namespace OpgaverApi.Sections.Models
{
    public class Cocktail
    {
        public string CocktailName { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
    }
}
