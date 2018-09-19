using BookStoreRepository.DAL;
using BookStoreRepository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreRepository.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        //public BookController()
        //{
        //    this.bookRepository = new BookRepository (new ApplicationDbContext());
        //}
        // GET: Book
        public ActionResult Index()
        {
            var books = from book in bookRepository.GetBooks()
                        select book;
            return View(books);
        }
        public ViewResult Details(int id)
        {
            Book student = bookRepository.GetBookByID(id);
            return View(student);
        }
        public ActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepository.InsertBook(book);
                    bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }
        public ActionResult Edit(int id)
        {
            Book book = bookRepository.GetBookByID(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepository.UpdateBook(book);
                    bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Book book = bookRepository.GetBookByID(id);
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Book book = bookRepository.GetBookByID(id);
                bookRepository.DeleteBook(id);
                bookRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}