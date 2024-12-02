using AutoMapper;
using BooksShop.Data;
using Microsoft.AspNetCore.Mvc;
using BooksShop.Extensions;
using Microsoft.EntityFrameworkCore;
using BooksShop.Models;
using BooksShop.Services;

namespace BooksShop.Controllers
{
    public class CartController : Controller
    {
        private BooksShopDbContext context;
        private readonly IMapper mapper;
        private readonly ICartService cartService;

        public CartController(BooksShopDbContext context, IMapper mapper, ICartService cartService)
        {
            this.context = context;
            this.mapper = mapper;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            var items = HttpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);
            
            if (items == null) items = new Dictionary<int, int>();            

            var entities = context.Books                                    
                                    .Where(x => items.Keys.Contains(x.Id))
                                    .ToList();

            var list = mapper.Map<List<BookCartModel>>(entities);

            foreach (var i in list)
            {
                i.CountToBuy = items[i.Id];
            }

            return View(list);
        }
        public IActionResult Append(int id, int count = 1, string? returnUrl = null)
        {
            cartService.Append(id, count);

            if (returnUrl != null)
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }
        public IActionResult Remove(int id)
        {
            // отримуємо дані з корзини
            var items = HttpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);
            if (items == null) return NotFound();

            items.Remove(id);

            // зберігаємо новий список в корзині
            HttpContext.Session.Set(WebConstants.CART_KEY, items);

            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(WebConstants.CART_KEY);

            return RedirectToAction("Index");
        }
    }
}
