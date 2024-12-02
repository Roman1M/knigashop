using AutoMapper;
using BooksShop.Data;
using BooksShop.Data.Entities;
using BooksShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BooksShop.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class BooksController : Controller
    {
        private BooksShopDbContext context;
        private readonly IMapper mapper;

        public BooksController(BooksShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var books = context.Books.Include(x => x.Category).Include(x => x.Author).ToList();
            LoadCategories();
            LoadAuthors();       
            
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Creation = true;
            LoadCategories();
            LoadAuthors();

            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(BookFormModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadAuthors();
                ViewBag.Creation = true;
                return View("Upsert", model);
            }
            
            var entity = mapper.Map<Book>(model);
            context.Books.Add(entity);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var item = context.Books.Find(id);
            if (item == null) return NotFound();

            ViewBag.Creation = false;
            LoadCategories();
            LoadAuthors();

            //var model = new EditBookModel()
            //{
            //    Name = item.Name,
            //    Price = item.Price,
            //    Discount = item.Discount,
            //    InStock = item.InStock,
            //    ImageUrl = item.ImageUrl,
            //    Year = item.Year,
            //    CategoryId = item.CategoryId,
            //    AuthorId = item.AuthorId
            //};
            var model = mapper.Map<BookFormModel>(item);

            return View("Upsert", model);
        }
        [HttpPost]
        public IActionResult Edit(BookFormModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadAuthors();
                ViewBag.Creation = false;
                return View("Upsert", model);
            }

            //var entity = new Book()
            //{
            //    Id = model.Id,
            //    Name = model.Name,
            //    Price = model.Price,
            //    Discount = model.Discount,
            //    InStock = model.InStock,
            //    ImageUrl = model.ImageUrl,
            //    //Quantity = model.Quantity,
            //    Year = model.Year,
            //    CategoryId = model.CategoryId,
            //    AuthorId = model.AuthorId
            //};
            var entity = mapper.Map<Book>(model);

            context.Books.Update(entity);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var item = context.Books.Find(id);
            if (item == null) return NotFound();

            context.Books.Remove(item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Filter(int? categoryId)
        {
            if (categoryId == null)
                return RedirectToAction("Index");

            var books = context.Books
                            .Include(x => x.Category)
                            .Where(x => x.CategoryId == categoryId)
                            .ToList();
            LoadAuthors();
            LoadCategories();
            return View("Index", books);
        }
        private void LoadCategories()
        {
            var categories = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
            ViewBag.Categories = categories;
        }
        private void LoadAuthors()
        {
            var authors = new SelectList(context.Authors.ToList(), nameof(Author.Id), nameof(Author.Name));
            ViewBag.Authors = authors;
        }
    }
}
