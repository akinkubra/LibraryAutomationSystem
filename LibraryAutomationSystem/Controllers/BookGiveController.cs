using LibraryAutomationSystem.Models;
using LibraryAutomationSystem.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Services;

namespace LibraryAutomationSystem.Controllers
{
    public class BookGiveController : Controller
    {
        LibraryDbContext islemler = new LibraryDbContext();
        BookService _bookService = new BookService();
        public ActionResult BookAdd()
        {
           ViewData["categories"] = _bookService.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult BookAdd(BookViewModel bookVm)
        {
            ViewData["categories"] = _bookService.GetCategories();
            //foreach (var item in bookVm.BookName)
            //{
            //    if (bookVm.BookName.Contains(" "))
            //    {
            //        bookVm.BookName.Remove(0);

            //    }
            //    else
            //    {
            //        break;                   
            //    }
            //}

            bookVm.BookName = bookVm.BookName.Trim();

            if (string.IsNullOrEmpty(bookVm.BookName) && string.IsNullOrEmpty(bookVm.CategoryName) && string.IsNullOrEmpty(bookVm.AuthorName) &&
                string.IsNullOrEmpty(bookVm.PublisherName))
            {
                TempData["notice"] = "Lütfen kitap vermek için gerekli bilgileri giriniz!";
                return View();
            }
            else
            {
                _bookService.BookGive(bookVm, Session["UserID"].ToString());
                TempData["notice"] = "Kitabı verme işleminiz başarılı";

                return View();
            }
        }
    }
}
