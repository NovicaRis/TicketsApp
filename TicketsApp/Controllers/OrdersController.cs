using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketsApp.Data.Cart;
using TicketsApp.Data.Services;
using TicketsApp.Data.Static;
using TicketsApp.Data.ViewModels;

namespace TicketsApp.Controllers
{
   [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMoviesService _service;
        private readonly IOrdersService _ordersService;
        private readonly ShoppingCart _cart;

        public OrdersController(IMoviesService service, ShoppingCart cart, IOrdersService ordersService)
        {
            _service = service;
            _cart = cart;
            _ordersService = ordersService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
           var items= _cart.GetShoppingCartItems();
            _cart.ShoppingCartItems=items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _cart,
                ShoppingCartTotal=_cart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _service.GetMovieByIdAsync(id);
            if(item != null)
            {
                _cart.AddItemToCart(item);
            }
            return RedirectToAction("ShoppingCart");

        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _service.GetMovieByIdAsync(id);
            if (item != null)
            {
                _cart.RemoveItemFromCart(item);
            }
            return RedirectToAction("ShoppingCart");

        }

        public async Task< IActionResult> CompleteOrder()
        {
            var items = _cart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _cart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
