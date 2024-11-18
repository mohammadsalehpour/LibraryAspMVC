using Library.Data;
using Library.Models.Entities;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookController
        public async Task<ActionResult> Index()
        {
            List<Book> getAllBook = await _context.Books.ToListAsync();

            List<IndexBookViewModel> books = new List<IndexBookViewModel>();

            foreach (var item in getAllBook)
            {
                var book = new IndexBookViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Inventory=item.Inventory,
                    PagesCount=item.PagesCount,
                    PublishedYear = item.PublishedYear,
                    CategoryId=item.CategoryId,
                    CreatedDate = DateTime.Now
                };
                var category = _context.Categories.FirstOrDefault(c => c.Id == item.CategoryId);
                if (category is not null)
                {
                    book.CategoryName = category.Name;
                }
                books.Add(book);
            }
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public async Task<IActionResult> Create()
        {
            CreateBookViewModel book = new CreateBookViewModel();
            List<Category> categories = await _context.Categories.ToListAsync();
            foreach (var item in categories)
            {
                //books.Categories?.Add(new SelectListItem { 
                //Text=item.Name,
                //Value=item.Id.ToString()
                //});

                SelectListItem category = new SelectListItem();
                category.Text = item.Name;
                category.Value = item.Id.ToString();
                book.Categories?.Add(category);
            }
           
            return View(book);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = new Book {
                        
                        Name = model.Name,
                        Price = model.Price,
                        Inventory = model.Inventory,
                        PagesCount = model.PagesCount,
                        PublishedYear = model.PublishedYear,
                        CategoryId = model.CategoryId,
                        CreatedDate = DateTime.Now
                    };
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
