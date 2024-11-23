using Library.Data;
using Library.Models.Entities;
using Library.Models.ViewModels.Book;
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
                    Inventory = item.Inventory,
                    PagesCount = item.PagesCount,
                    PublishedYear = item.PublishedYear,
                    CategoryId = item.CategoryId,
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
            CreateBookViewModel createBookViewModel = new CreateBookViewModel();
            List<Category> categories = await _context.Categories.ToListAsync();
            foreach (var item in categories)
            {
                SelectListItem categorySelectListItem = new SelectListItem();
                categorySelectListItem.Text = item.Name;
                categorySelectListItem.Value = item.Id.ToString();
                createBookViewModel.Categories?.Add(categorySelectListItem);
            }

            List<Author> authors = await _context.Authors.ToListAsync();
            foreach (var author in authors)
            {
                SelectListItem authorSelectListItem = new SelectListItem();
                authorSelectListItem.Text = author.Name;
                authorSelectListItem.Value = author.Id.ToString();
                createBookViewModel.Authors?.Add(authorSelectListItem);
            }

            return View(createBookViewModel);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel createBookViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = new Book
                    {
                        Name = createBookViewModel.Name,
                        Price = createBookViewModel.Price,
                        Inventory = createBookViewModel.Inventory,
                        PagesCount = createBookViewModel.PagesCount,
                        PublishedYear = createBookViewModel.PublishedYear,
                        CategoryId = createBookViewModel.CategoryId,
                        CreatedDate = DateTime.Now
                    };
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    if (createBookViewModel.Authors is not null)
                    {
                        foreach (int authorId in createBookViewModel.AuthorIds)
                        {
                            AuthorBook authorBook = new AuthorBook();
                            authorBook.BookId = book.Id;
                            authorBook.AuthorId = authorId;
                            _context.AuthorBooks.Add(authorBook);
                        }
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                List<Category> categories = await _context.Categories.ToListAsync();
                foreach (var item in categories)
                {
                    SelectListItem categorySelectListItem = new SelectListItem();
                    categorySelectListItem.Text = item.Name;
                    categorySelectListItem.Value = item.Id.ToString();
                    createBookViewModel.Categories?.Add(categorySelectListItem);
                }

                List<Author> authors = await _context.Authors.ToListAsync();
                foreach (var author in authors)
                {
                    SelectListItem authorSelectListItem = new SelectListItem();
                    authorSelectListItem.Text = author.Name;
                    authorSelectListItem.Value = author.Id.ToString();
                    createBookViewModel.Authors?.Add(authorSelectListItem);
                }

                return View(createBookViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            UpdateBookViewModel updateBookViewModel = new UpdateBookViewModel();

            Book? book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            updateBookViewModel.Name = book.Name;
            updateBookViewModel.Price = book.Price;
            updateBookViewModel.Inventory = book.Inventory;
            updateBookViewModel.PagesCount = book.PagesCount;
            updateBookViewModel.PublishedYear = book.PublishedYear;
            updateBookViewModel.CategoryId = book.CategoryId;

            List<Category> categories = await _context.Categories.ToListAsync();
            foreach (var category in categories)
            {
                SelectListItem categorySelectListItem = new SelectListItem();
                categorySelectListItem.Text = category.Name;
                categorySelectListItem.Value = category.Id.ToString();
                categorySelectListItem.Selected = category.Id.Equals(book.CategoryId);
                updateBookViewModel.Categories?.Add(categorySelectListItem);
            }

            List<Author> authors = await _context.Authors.ToListAsync();
            List<AuthorBook> authorBooks = await _context.AuthorBooks.Where(c => c.BookId == book.Id).ToListAsync();
            foreach (var author in authors)
            {
                SelectListItem authorSelectListItem = new SelectListItem();
                authorSelectListItem.Text = author.Name;
                authorSelectListItem.Value = author.Id.ToString();
                authorSelectListItem.Selected = authorBooks.Any(c => c.AuthorId == author.Id);
                updateBookViewModel.Authors?.Add(authorSelectListItem);
            }

            return View(updateBookViewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBookViewModel updateBookViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book? book = await _context.Books.FindAsync(updateBookViewModel.Id);

                    if (book == null)
                    {
                        return NotFound();
                    }

                    book.Name = updateBookViewModel.Name;
                    book.Price = updateBookViewModel.Price;
                    book.Inventory = updateBookViewModel.Inventory;
                    book.PagesCount = updateBookViewModel.PagesCount;
                    book.PublishedYear = updateBookViewModel.PublishedYear;
                    book.CategoryId = updateBookViewModel.CategoryId;
                    book.CreatedDate = DateTime.Now;

                    _context.Books.Update(book);

                    if (updateBookViewModel.Authors is not null)
                    {


                        var authorBooks = _context.AuthorBooks.Where(c => c.BookId == book.Id).ToList();
                        foreach (var item in authorBooks)
                        {
                            _context.AuthorBooks.Remove(item);
                        }
                        await _context.SaveChangesAsync();

                        foreach (int authorId in updateBookViewModel.AuthorIds)
                        {
                            AuthorBook authorBook = new AuthorBook();
                            authorBook.BookId = book.Id;
                            authorBook.AuthorId = authorId;
                            _context.AuthorBooks.Add(authorBook);
                        }
                    }

                    await _context.SaveChangesAsync();
                    var alert = ("success", "با موفقیت ویرایش شد");
                   // TempData["MessageType"] = "success";
                    TempData["AlertMessage"] = alert;
                    return RedirectToAction(nameof(Index));
                }
                return View(updateBookViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetBookViewModel getBookViewModel)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
