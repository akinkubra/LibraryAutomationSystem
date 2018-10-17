using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using LibraryAutomationSystem.ViewModel;
using System.Web.Security;
using LibraryAutomationSystem.Models;
using AutoMapper;

namespace LibraryAutomationSystem.Services
{
    public class BookService
    {
        LibraryDbContext bookDC = new LibraryDbContext();

        public BookService()
        {

        }

        public void BookReceive(string bookName, BookViewModel bookVm, string session)
        {
            BookView bookV = (from p in bookDC.BookViews
                              where p.BookName == bookName
                              select p).FirstOrDefault();

            Book book = (from p in bookDC.Books
                         where p.BookName == bookName
                         select p).FirstOrDefault();

            bookVm.CategoryName = bookV.CategoryName;
            bookVm.BookName = bookV.BookName;
            bookVm.AuthorName = bookV.AuthorName;
            bookVm.PublisherName = bookV.PublisherName;
            book.BookQuantity--;
            BookOperation BO = new BookOperation();
            Penalty penalty = new Penalty();
            BO.UserName = session;
            BO.ReceivingDate = DateTime.Now;
            BO.CategoryName = bookVm.CategoryName;
            BO.BookName = bookVm.BookName;
            BO.AuthorName = bookVm.AuthorName;
            BO.PublisherName = bookVm.PublisherName;
            bookDC.BookOperations.Add(BO);
            bookDC.SaveChanges();
            penalty.BookOperationId = BO.Id;
            penalty.PenaltyQuantity = 0;
            bookDC.Penalties.Add(penalty);
            bookDC.SaveChanges();
        }

        public void BookGive(BookViewModel bookVm, string session)
        {

            TimeSpan? interval;
            DateTime? receivingDate, givingDate;
            receivingDate = null;
            interval = null;
            BookOperation bkO = null;
            if (bookVm.PublisherName == null)
            {
                bkO = (from bo in bookDC.BookOperations
                       where bo.UserName == session && bo.BookName == bookVm.BookName && bo.ReceivingDate != null
                       select bo).FirstOrDefault();
            }
            else
            {
                bkO = (from bo in bookDC.BookOperations
                       where bo.UserName == session && bo.BookName == bookVm.BookName
                       select bo).FirstOrDefault();
            }

            var authr = (from a in bookDC.Authors
                         where a.AuthorName == bookVm.AuthorName
                         select a).FirstOrDefault();

            Penalty penalty = new Penalty();
            BookOperation BO = new BookOperation();
            if (bkO == null)
            {
                BO.UserName = session;
                BO.CategoryName = bookVm.CategoryName;
                BO.BookName = bookVm.BookName;
                BO.PublisherName = bookVm.PublisherName;
                BO.GivingDate = DateTime.Now;
                if (!string.IsNullOrEmpty(bookVm.AuthorName))
                {
                    BO.AuthorName = bookVm.AuthorName;
                }
                else
                {
                    BO.AuthorName = "-";
                }

                bookDC.BookOperations.Add(BO);
                bookDC.SaveChanges();

                penalty.BookOperationId = BO.Id;
                penalty.PenaltyQuantity = 0;
                bookDC.Penalties.Add(penalty);
            }
            else
            {
                if (bkO.ReceivingDate == null)
                {
                    BO.UserName = session;
                    BO.CategoryName = bookVm.CategoryName;
                    BO.BookName = bookVm.BookName;
                    BO.PublisherName = bookVm.PublisherName;
                    BO.GivingDate = DateTime.Now;
                    BO.ReceivingDate = null;
                    if (!string.IsNullOrEmpty(bookVm.AuthorName))
                    {
                        BO.AuthorName = bookVm.AuthorName;
                    }
                    else
                    {
                        BO.AuthorName = "-";
                    }

                    bookDC.BookOperations.Add(BO);
                    bookDC.SaveChanges();

                    penalty.BookOperationId = BO.Id;
                    penalty.PenaltyQuantity = 0;
                    bookDC.Penalties.Add(penalty);
                }
                else
                {
                    receivingDate = bkO.ReceivingDate;
                    bkO.GivingDate = DateTime.Now;
                    givingDate = bkO.GivingDate;
                    interval = givingDate - receivingDate;
                    foreach (var item in bookDC.Penalties)
                    {
                        if (item.BookOperationId == bkO.Id)
                        {
                            if (interval.Value.Days <= 7)
                            {
                                item.PenaltyQuantity = 0;
                            }
                            else
                            {
                                item.PenaltyQuantity = (double)interval.Value.Days * 0.50;
                                break;
                            }
                        }
                    }
                }

                var bk = (from b in bookDC.Books
                          where b.BookName == bookVm.BookName
                          select b).FirstOrDefault();
                Book book = new Book();
                if (bk == null)
                {
                    book.BookName = bookVm.BookName;
                    book.CategoryId = (from item in bookDC.Categories
                                       where item.CategoryName == bookVm.CategoryName
                                       select item.CategoryId).FirstOrDefault();
                    book.BookQuantity = 1;
                    bookDC.Books.Add(book);
                }
                else
                {
                    bk.BookQuantity++;
                }



                Author author = new Author();
                if (authr == null)
                {
                    if (bookVm.AuthorName != null)
                    {
                        author.AuthorName = bookVm.AuthorName;
                        bookDC.Authors.Add(author);
                        Book_Author BA = new Book_Author();
                        BA.AuthorId = author.AuthorId;
                        BA.BookId = book.BookId;
                        bookDC.Book_Author.Add(BA);
                    }
                    else
                    {
                        if (bkO.GivingDate != null)
                        {

                        }
                        else
                        {
                            author.AuthorName = "-";
                            bookDC.Authors.Add(author);
                            Book_Author BA = new Book_Author();
                            BA.AuthorId = author.AuthorId;
                            BA.BookId = book.BookId;
                            bookDC.Book_Author.Add(BA);
                        }
                    }
                }


                var publishr = (from p in bookDC.Publishers
                                where p.PublisherName == bookVm.PublisherName
                                select p).FirstOrDefault();
                Publisher publshr = new Publisher();
                if (publishr == null)
                {
                    if (bookVm.PublisherName != null)
                    {
                        publshr.PublisherName = bookVm.PublisherName;
                        bookDC.Publishers.Add(publshr);
                        Book_Publisher BP = new Book_Publisher();
                        BP.PublisherId = publshr.PublisherId;
                        BP.BookId = book.BookId;
                        bookDC.Book_Publisher.Add(BP);
                    }
                    else
                    {
                        if (bkO.GivingDate != null)
                        {

                        }
                        else
                        {
                            publshr.PublisherName = "-";
                            bookDC.Publishers.Add(publshr);
                            Book_Publisher BP = new Book_Publisher();
                            BP.PublisherId = publshr.PublisherId;
                            BP.BookId = book.BookId;
                            bookDC.Book_Publisher.Add(BP);
                        }
                    }
                }

                bookDC.SaveChanges();
            }
        }

        public List<SelectListItem> GetCategories()
        {
            var categories = (from c in bookDC.Categories
                select c.CategoryName).ToList();
            List<SelectListItem> categoryList =new List<SelectListItem>();
            categories.Insert(0,"Seçiniz");
            for (int i=0 ; i < categories.Count;i++)
            {
                categoryList.Add(new SelectListItem() { Text = categories[i], Value = categories[i] });
            }
            return categoryList;
        }

        public List<SelectListItem> GetBookList()
        {
            var books = (from b in bookDC.BookViews
                where b.BookQuantity != 0
                select b.BookName).ToList();
            List<SelectListItem> bookList = new List<SelectListItem>();
            books.Insert(0, "Seçiniz");
            for (int i = 0; i < books.Count; i++)
            {
                bookList.Add(new SelectListItem() { Text = books[i], Value = books[i] });
            }
            return bookList;
        }

    }
}