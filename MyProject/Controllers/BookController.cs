using MyProject.Models;
using MyProject.Services;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;
        private readonly AuthorService authorService;

        public BookController()
        {
            bookService = new BookService(new Models.ApplicationDbContext());
            authorService = new AuthorService(new Models.ApplicationDbContext());
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            var book = bookService.GetAllBooks();
            return View(book);
        }

        [HttpGet]
        public ActionResult GetBookById(int id)
        {

            var book = bookService.GetBookById(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }



        public ActionResult CreateBook()
        {
            var authors = authorService.GetAllAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "Name");

            return View();
        }


        [HttpPost]
        public ActionResult CreateBook(Book books)
        {
          
            //var book = bookService.CreateBook(books);

            if (ModelState.IsValid)
            {
                bookService.CreateBook(books);
                return RedirectToAction("GetAllBooks", "Book");
            }
            var authors = authorService.GetAllAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "Name");

            return View(books);

        }


        [HttpGet]
        public ActionResult UpdateBooks(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var authors = authorService.GetAllAuthors();
            ViewBag.AuthorId = new SelectList(authors, "Id", "Name", book.AuthorId); 
            return View(book);

        }

        [HttpPost]
        public ActionResult UpdateBooks(int id, Book book)
        {
            if (ModelState.IsValid)
            {

                var updateBook = bookService.UpdateBook(id, book);
                if (updateBook != null)
                {
                    return RedirectToAction("GetAllBooks", "Book");
                }
                return HttpNotFound();

            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteBookById(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }

        
        public ActionResult DeleteBook(int id)
        {
           var book = bookService.GetBookById(id);
            if(book != null)
            {
                bookService.DeleteBook(id);
            }
            return RedirectToAction("GetAllBooks","Book");
        }


    }
}