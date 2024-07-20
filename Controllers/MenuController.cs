using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        public readonly MenuContext _menuContext;

        public MenuController(MenuContext menuContext)
        {
            _menuContext = menuContext;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _menuContext.Dishes
                       select d;
            if(!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details (int? id)
        {
            var dish = await _menuContext.Dishes.Include(di => di.DishIngredients).ThenInclude(i => i.Ingredient ).FirstOrDefaultAsync( x => x.Id == id);

            if(dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

        public IActionResult Index1()
        {
            return View();
        }


        public IActionResult Create()
        {
            ViewBag.Ingredients = _menuContext.Ingredients.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dish dish, List<int> selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                foreach (var ingredientId in selectedIngredients)
                {
                    dish.DishIngredients.Add(new DishIngredient { IngredientId = ingredientId });
                }

                _menuContext.Add(dish);
                await _menuContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Dish added successfully!";
                return RedirectToAction(nameof(Create));
            }
            ViewBag.Ingredients = _menuContext.Ingredients.ToList();
            return View(dish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var dish = await _menuContext.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _menuContext.Dishes.Remove(dish);
            await _menuContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Dish deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

    }
}
    
