using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpgaverApi.Sections.Contex;
using OpgaverApi.Sections.Entities;
using OpgaverApi.Sections.Models;
using OpgaverApi.Sections.Processing;

namespace OpgaverApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CocktailsController : ControllerBase
    {
        private CocktailContext _context;

        public CocktailsController(CocktailContext dbContext)
        {
            _context = dbContext;
        }

        [Route("AddIngredient")]
        [HttpGet]
        public IActionResult AddIngredient(string Name, string icon)
        {
            _context.Ingredients.Add(new Sections.Entities.CocktailIngredient()
            {
                Name = Name,
                Icon = icon
            });

            _context.SaveChanges();
            return Ok();
        }

        [Route("MakeCocktail")]
        [HttpGet]
        public IActionResult MakeCocktail(string Name)
        {
            CocktailManager mngr = new CocktailManager(_context);
            Cocktail c = mngr.MakeCocktail(Name);
           
            return Ok(c);
        }

        [Route("AddFullCocktailRecipe")]
        [HttpPost]
        public IActionResult AddFullRecipe([FromBody]Quantity q)
        {

            //CocktailRecipe recipe = new CocktailRecipe()
            //{
            //    Name = name
            //};

            //var ingredients = _context.Ingredients;
            //var quantities = _context.Quantities;

            //List<CocktailIngredient> forRecipe = new List<CocktailIngredient>();

            //CocktailIngredient first = ingredients.First(x => x.Name == ingredient);


            //forRecipe.Add(ingredients.First(x => x.Id == 1));
            //forRecipe.Add(ingredients.First(x => x.Id == 2));

            //recipe.Ingredients.AddRange(forRecipe);


            //_context.Recipes.Add(new CocktailRecipe()
            //{
            //    Name = name
            //})

            //_context.SaveChanges();
            return Ok();
        }

        [Route("AddRecipe")]
        [HttpGet]
        public IActionResult AddRecipe(string Name)
        {
            _context.Recipes.Add(new Sections.Entities.CocktailRecipe()
            {
                Name = Name
            });

            _context.SaveChanges();
            return Ok();
        }

        [Route("GetRecipe")]
        [HttpGet]
        public IActionResult GetRecipe(string Name)
        {
            try
            {
                CocktailRecipe recipe = _context.Recipes.First(x => x.Name.Equals(Name));
                Console.WriteLine();
                recipe.Ingredients = _context.Recipes.Where(x => x.Name.Equals(Name)).SelectMany(i => i.Ingredients).ToList();

                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return Ok("Recipe not found");
            }
          
        }

        [Route("Test")]
        [HttpPost]
        public IActionResult TestEndpoint([FromBody]NewCocktailRecipeModel model)
        {

            var ingredients = _context.Ingredients;
            var quantities = _context.Quantities;

            CocktailRecipe recip = _context.Recipes.First(x => x.Name.ToLower().Equals(model.CocktailName.ToLower()));
            recip.Ingredients = new List<CocktailIngredient>();

            if (recip is null)
            {
                return Ok("Cocktail not found");
            }

            foreach (NewCocktailIngredientModel newIng in model.ingredients)
            {
                CocktailIngredient foundIngredient = ingredients.First(x => x.Name.ToLower().Equals(newIng.IngredientName.ToLower()));

                recip.Ingredients.Add(foundIngredient);

                Quantity q = new Quantity();
                q.CocktailIngredient = foundIngredient;
                q.CocktailRecipe = recip;
                q.Type = newIng.quantityType;
                q.Amount = newIng.QuantityAmount;

                _context.Quantities.Add(q);
            }

            

            foreach(CocktailIngredient i in ingredients)
            {
                recip.Ingredients.Add(i);
            }

            _context.Recipes.Update(recip);

            _context.SaveChanges();
            return Ok();
        }
    }
}
