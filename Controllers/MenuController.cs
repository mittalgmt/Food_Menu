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

    }
}
    
