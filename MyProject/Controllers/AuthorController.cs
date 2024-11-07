using MyProject.Models;
using MyProject.Services;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class AuthorController : Controller
    {

        private readonly AuthorService authorService;

        public AuthorController()
        {
            authorService = new AuthorService(new Models.ApplicationDbContext());
        }
        [HttpGet]
        public ActionResult GetAllAuthor()
        {
            var auhtors = authorService.GetAllAuthors();
            return View(auhtors);
        }
        [HttpGet]
        public ActionResult GetAuthorById(int id)
        {
            var auhtors = authorService.GetAuthorById(id);
            if (auhtors == null)
            {
                return HttpNotFound();
            }
            ViewData.Model = auhtors;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Create( Author author)
        {
            if (ModelState.IsValid)
            {
                authorService.CreateAuthor(author);
                return RedirectToAction("GetAllAuthor", "Author");
            }

            return View();

        }
        [HttpGet]
        public ActionResult UpdateAuthorById(int id)
        {
            var author = authorService.GetAuthorById(id);
            if (author == null)
            {
                return HttpNotFound(ViewBag.ErrorMessage = "Такого Автора нет в списке");
            }
            return View(author);
        }

        [HttpPost]
        public ActionResult UpdateAuthorByID(int id, Author author)
        {
            if (ModelState.IsValid)
            {
                var updateAuthor = authorService.UpdateAuthor(id, author);
                if (updateAuthor != null)
                {
                  
                    return RedirectToAction("GetAllAuthor", "Author");

                }
                return HttpNotFound();

            }
            return View(author);

        }

        //[HttpPost,ActionName("Delete")]
        public ActionResult DeleteAuthor(int id)
        {
            authorService.DeleteAuthor(id);
            return RedirectToAction("GetAllAuthor", "Author");



        }

    }
}