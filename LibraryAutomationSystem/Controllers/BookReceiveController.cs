using LibraryAutomationSystem.Models;
using LibraryAutomationSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Services;

namespace LibraryAutomationSystem.Controllers
{
    public class BookReceiveController : Controller
    {
        LibraryDbContext islemler = new LibraryDbContext();
        BookService _bookService = new BookService();
        public ActionResult RBook(string BookName)
        {
            List<BookViewModel> searchingBook = new List<BookViewModel>();

            List<BookView> selectedBook = (from p in islemler.BookViews
                                           where p.BookName == BookName
                                           select p).ToList();
            foreach (var item in selectedBook)
            {
                BookViewModel bk = new BookViewModel();
                bk.CategoryName = item.CategoryName;
                bk.BookName = item.BookName;
                bk.AuthorName = item.AuthorName;
                bk.PublisherName = item.PublisherName;
                bk.BookQuantity = item.BookQuantity;
                searchingBook.Add(bk);
            }
            if (selectedBook.Count.Equals(0))
            {
                TempData["notice"] = "Aradığınız kitap kütüphanemizde bulunmamaktadır.";
            }
            return View(searchingBook);
        }
        public ActionResult BookDelete()
        {
            ViewData["categories"] = _bookService.GetCategories();
            ViewData["books"] = _bookService.GetBookList();
            return View();
        }
        [HttpPost]
        public ActionResult BookDelete(BookViewModel opr)
        {
            if (string.IsNullOrEmpty(opr.BookName))
            {
                TempData["notice"] = "Lütfen kitap adını giriniz!";
                return View();
            }
            else
            {
                return RedirectToAction("RBook", new { BookName = opr.BookName });
            }
        }

        public ActionResult ReceivingBook(string BookName, BookViewModel bookVm)
        {
            BookView book = (from p in islemler.BookViews
                             where p.BookName == BookName
                             select p).FirstOrDefault();

            bookVm.CategoryName = book.CategoryName;
            bookVm.BookName = book.BookName;
            bookVm.AuthorName = book.AuthorName;
            bookVm.PublisherName = book.PublisherName;
            bookVm.BookQuantity = book.BookQuantity;

            return View(bookVm);
        }
        [HttpPost, ActionName("ReceivingBook")]
        public ActionResult ReceivingProcess(string BookName, BookViewModel bookvm)
        {
            BookView bbook = (from p in islemler.BookViews
                              where p.BookName == BookName
                              select p).FirstOrDefault();

            User User = (from u in islemler.Users
                         where u.Username == bookvm.UserName
                         select u).FirstOrDefault();

            bookvm.CategoryName = bbook.CategoryName;
            bookvm.BookName = bbook.BookName;
            bookvm.AuthorName = bbook.AuthorName;
            bookvm.PublisherName = bbook.PublisherName;
            bookvm.BookQuantity = bbook.BookQuantity;

            _bookService.BookReceive(BookName, bookvm, Session["UserID"].ToString());
            TempData["notice"] = "Kitabı alma işleminiz tamamlandı.7 gün içerisinde iade etmenizi rica ederiz";

            return View(bookvm);



        }

        //public JsonResult BookListByCategoryId(int categoryId)
        //{
        //    List<string> books = (from b in islemler.Books
        //        where b.CategoryId == categoryId
        //        select b.BookName).ToList();
        //    return books;
        //}
    }
}
