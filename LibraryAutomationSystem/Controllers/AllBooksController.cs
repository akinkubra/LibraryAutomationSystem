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
    public class AllBooksController : Controller
    {
        LibraryDbContext islemler = new LibraryDbContext();
        BookService _bookService = new BookService();
        public ActionResult AllBooks()
        {
            List<BookViewModel> BookList = new List<BookViewModel>();
            var bookList = (from b in islemler.BookViews
                            select b).ToList();
            foreach (var item in bookList)
            {
                BookViewModel book = new BookViewModel();
                book.CategoryName = item.CategoryName;
                book.BookName = item.BookName;
                book.AuthorName = item.AuthorName;
                book.PublisherName = item.PublisherName;
                book.BookQuantity = item.BookQuantity;
                BookList.Add(book);
            }
            return View(BookList);
        }

        public ActionResult Book(string BookName, BookViewModel bookVm)
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
        [HttpPost, ActionName("Book")]
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

            _bookService.BookReceive(bookName, bookvm, Session["UserID"].ToString());
            TempData["notice"] = "Kitabı alma işleminiz tamamlandı.7 gün içerisinde iade etmenizi rica ederiz.";

            return View(bookvm);
        }

    }
}
