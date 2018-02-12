using LibraryAutomationSystem.Models;
using LibraryAutomationSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.Controllers
{
    public class ProcessController : Controller
    {
        LibraryDbContext Process = new LibraryDbContext();

        public ActionResult MyProcess()
        {
            List<BookViewModel> myPrcss = new List<BookViewModel>();

            string usrName = Session["UserID"].ToString();
            List<BookOperation> MP = (from b in Process.BookOperations
                                      where b.UserName == usrName
                                      select b).ToList();

            TimeSpan? interval;
            DateTime? receivingDate, givingDate;
            Penalty penalty = new Penalty();
            
            foreach (var item in MP)
            {
                BookViewModel bk = new BookViewModel();
                bk.CategoryName = item.CategoryName;
                bk.BookName = item.BookName;
                bk.AuthorName = item.AuthorName;
                bk.PublisherName = item.PublisherName;
                bk.UserName = item.UserName;
                bk.ReceivingDate = item.ReceivingDate;
                bk.GivingDate = item.GivingDate;
                bk.PenaltyQuantity = (from i in Process.Penalties
                                      where i.BookOperationId == item.Id
                                      select i.PenaltyQuantity).FirstOrDefault();

                if (bk.GivingDate == null)
                {
                    receivingDate = bk.ReceivingDate;
                    givingDate = bk.GivingDate;
                    interval = DateTime.Now - receivingDate;
                    if (interval.Value.Days <= 7)
                    {
                        TempData["notice"] = "";
                    }
                    else
                    {
                        interval = DateTime.Now.AddDays(-7) - (receivingDate);
                        foreach (var i in Process.Penalties)
                        {
                            if (i.BookOperationId == item.Id)
                            {
                                i.PenaltyQuantity = (double)interval.Value.Days * 0.50;
                                bk.PenaltyQuantity = i.PenaltyQuantity;
                            }
                        }
                        TempData["notice"] += "** " + bk.BookName + "'ı lütfen iade ediniz.7 gün geçmiştir";
                    }
                }
                Process.SaveChanges();
                myPrcss.Add(bk);
            }
            if (myPrcss.Count.Equals(0))
            {
                TempData["notice"] = "Herhangi bir işleminiz bulunmamaktadır.";
            }

            return View(myPrcss);
        }

        public ActionResult Payment(double penalty, string bookName, BookViewModel bookVm)
        {
            BookOperation book = (from p in Process.BookOperations
                                  where p.BookName == bookName
                                  select p).FirstOrDefault();

            bookVm.CategoryName = book.CategoryName;
            bookVm.BookName = book.BookName;
            bookVm.AuthorName = book.AuthorName;
            bookVm.PublisherName = book.PublisherName;
            bookVm.ReceivingDate = book.ReceivingDate;
            bookVm.GivingDate = book.GivingDate;
            bookVm.PenaltyQuantity = penalty;

            return View(bookVm);
        }

        [HttpPost, ActionName("Payment")]
        public ActionResult PaymentProcess(double penalty, string bookName, BookViewModel bookVm)
        {
            BookOperation book = (from p in Process.BookOperations
                                  where p.BookName == bookName
                                  select p).FirstOrDefault();

            bookVm.CategoryName = book.CategoryName;
            bookVm.BookName = book.BookName;
            bookVm.AuthorName = book.AuthorName;
            bookVm.PublisherName = book.PublisherName;
            bookVm.ReceivingDate = book.ReceivingDate;
            bookVm.GivingDate = book.GivingDate;
            bookVm.PenaltyQuantity = penalty;

            var Penalties = (from p in Process.Penalties
                             where p.PenaltyQuantity == penalty
                             select p).FirstOrDefault();

            var bo = (from b in Process.BookOperations
                      where b.Id == Penalties.BookOperationId && b.BookName == bookName
                      select b).FirstOrDefault();

            var selectedpenalty = (from sp in Process.Penalties
                                   where sp.BookOperationId == bo.Id
                                   select sp).FirstOrDefault();
            selectedpenalty.PenaltyQuantity = 0;
            Process.SaveChanges();
            TempData["notice"] = "Ödeme işleminiz gerçekleşmiştir";

            return View(bookVm);
        }

        public ActionResult BookGive(double penalty, string bookName, BookViewModel bookVm)
        {
            BookOperation book = (from p in Process.BookOperations
                                  where p.BookName == bookName
                                  select p).FirstOrDefault();

            bookVm.CategoryName = book.CategoryName;
            bookVm.BookName = book.BookName;
            bookVm.AuthorName = book.AuthorName;
            bookVm.PublisherName = book.PublisherName;
            bookVm.ReceivingDate = book.ReceivingDate;
            bookVm.GivingDate = book.GivingDate;
            bookVm.PenaltyQuantity = penalty;

            return View(bookVm);
        }

        [HttpPost, ActionName("BookGive")]
        public ActionResult GivingProcess(double penalty, string bookName, BookViewModel bookVm)
        {
            BookOperation book = (from p in Process.BookOperations
                                  where p.BookName == bookName
                                  select p).FirstOrDefault();

            bookVm.CategoryName = book.CategoryName;
            bookVm.BookName = book.BookName;
            bookVm.AuthorName = book.AuthorName;
            bookVm.PublisherName = book.PublisherName;
            bookVm.ReceivingDate = book.ReceivingDate;
            bookVm.GivingDate = book.GivingDate;
            bookVm.PenaltyQuantity = penalty;

            var penlty = (from p in Process.Penalties
                where p.PenaltyQuantity == penalty
                select p).ToList();

            string session = Session["UserID"].ToString();
            BookOperation bkO = null;
            foreach (var item in penlty)
            {
                bkO = (from bko in Process.BookOperations
                    where bko.UserName == session && bko.Id == item.BookOperationId && bko.BookName == bookName &&
                          bko.ReceivingDate != null && bko.GivingDate == null
                    select bko).FirstOrDefault();
                if(bkO != null) break;
            }

            var bk = (from b in Process.Books
                      where b.BookName == bookName
                      select b).FirstOrDefault();

            bk.BookQuantity++;

            bkO.GivingDate = DateTime.Now;

            Process.SaveChanges();

            TempData["notice"] = "Kitabı verme işleminiz başarılı";

            return View(bookVm);
        }
    }
}
