using AutoMapper;
using LibraryAutomationSystem.Models;
using LibraryAutomationSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using LibraryAutomationSystem.Services;


namespace LibraryAutomationSystem.Controllers
{
    public class HomeController : Controller
    {
        LibraryDbContext islemler = new LibraryDbContext();
        BookService _bookService = new BookService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BookViewModel searching)
        {
            var searchBook = (from sb in islemler.BookViews
                              where sb.BookName == searching.BookName
                              select sb).FirstOrDefault();
            if (searchBook == null)
            {
                TempData["notice"] = "Kütüphanemizde aradığınız kitap bulunmamaktadır!";
                return View();
            }
            else
            {
                return RedirectToAction("SearchedBook", new { BookName = searching.BookName });
            }         
        }

        public ActionResult SearchedBook(string bookName)
        {
            List<BookViewModel> searchingBook = new List<BookViewModel>();
            BookView book = (from b in islemler.BookViews
                             where b.BookName == bookName
                             select b).FirstOrDefault();

            BookViewModel bk = new BookViewModel();
            bk.CategoryName = book.CategoryName;
            bk.BookName = book.BookName;
            bk.AuthorName = book.AuthorName;
            bk.PublisherName = book.PublisherName;
            bk.BookQuantity = book.BookQuantity;
            searchingBook.Add(bk);

            if (string.IsNullOrEmpty(book.ToString()))
            {
                TempData["notice"] = "Aradığınız kitap kütüphanemizde bulunmamaktadır.";
            }
            return View(searchingBook);
        }
        public ActionResult SelectedBook(string bookName, BookViewModel bookvm)
        {
            BookView book = (from p in islemler.BookViews
                             where p.BookName == bookName
                             select p).FirstOrDefault();

            bookvm.CategoryName = book.CategoryName;
            bookvm.BookName = book.BookName;
            bookvm.AuthorName = book.AuthorName;
            bookvm.PublisherName = book.PublisherName;
            bookvm.BookQuantity = book.BookQuantity;

            return View(bookvm);
        }
        [HttpPost, ActionName("SelectedBook")]
        public ActionResult DeleteProcess(string bookName, BookViewModel bookvm)
        {
            BookView bbook = (from p in islemler.BookViews
                              where p.BookName == bookName
                              select p).FirstOrDefault();

            bookvm.CategoryName = bbook.CategoryName;
            bookvm.BookName = bbook.BookName;
            bookvm.AuthorName = bbook.AuthorName;
            bookvm.PublisherName = bbook.PublisherName;
            bookvm.BookQuantity = bbook.BookQuantity;

            _bookService.BookReceive(bookName,bookvm,Session["UserID"].ToString());
           
            TempData["notice"] = "Kitabı alma işleminiz tamamlandı.7 gün içerisinde iade etmenizi rica ederiz.";

            return View(bookvm);

        }
    }
}


