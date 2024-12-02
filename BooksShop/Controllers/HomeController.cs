using BooksShop.Data;
using BooksShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BooksShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksShopDbContext context;        

        public HomeController(BooksShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var items = context.Books.Include(x => x.Category).Include(x => x.Author).ToList();
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}