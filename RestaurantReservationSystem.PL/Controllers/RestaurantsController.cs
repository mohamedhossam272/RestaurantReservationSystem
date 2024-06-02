using Microsoft.AspNetCore.Mvc;
using RestaurantReservationSystem.BLL.Services;
using RestaurantReservationSystem.DAL.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantReservationSystem.PL.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            return View(restaurants);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id.Value);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(Restaurant restaurant)
        {
            ModelState["Tables"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                await _restaurantService.AddRestaurantAsync(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id.Value);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Restaurant restaurant)
        {
            ModelState["Tables"].ValidationState = ModelValidationState.Valid;
            if (id != restaurant.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _restaurantService.UpdateRestaurantAsync(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id.Value);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _restaurantService.DeleteRestaurantAsync(id);
            return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View("AccessDenied");
		}
	}
}
