using LibraryAutomationSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAutomationSystem.Services;

namespace LibraryAutomationSystem.ViewModel
{
    public class BookViewModel
    {
        [Display(Name = "id", Prompt = "id")]
        [Editable(false)]
        public int Bookid { get; set; }

        [Display(Name = "categoryId", Prompt = "categoryId")]
        [Editable(false)]
        public int CategoryId { get; set; }

        [Display(Name = "receivingDate", Prompt = "receivingDate")]
        [Editable(false)]
        [DataType(DataType.Date)]
        public DateTime? ReceivingDate { get; set; }

        [Display(Name = "givingDate", Prompt = "givingDate")]
        [Editable(false)]
        [DataType(DataType.Date)]
        public DateTime? GivingDate { get; set; }

        [Display(Name = "BookName", Prompt = "BookName")]
        [Editable(false)]
        public string BookName { get; set; }

        [Display(Name = "Username", Prompt = "Username")]
        [Editable(false)]
        public string UserName { get; set; }

        [Display(Name = "BookQuantity", Prompt = "BookQuantity")]
        [Editable(false)]
        public int? BookQuantity { get; set; }

        [Display(Name = "CategoryName", Prompt = "CategoryName")]
        [Editable(false)]
        public string CategoryName { get; set; }

        [Display(Name = "AuthorName", Prompt = "AuthorName")]
        [Editable(false)]
        public string AuthorName { get; set; }

        [Display(Name = "PublisherName", Prompt = "PublisherName")]
        [Editable(false)]
        public string PublisherName { get; set; }

        [Display(Name = "Penalties", Prompt = "Penalties")]
        [Editable(false)]
        public double PenaltyQuantity { get; set; }

        [Display(Name = "penaltyId", Prompt = "penaltyId")]
        [Editable(false)]
        public int PenaltyId { get; set; }

        [Display(Name = "BookOperationId", Prompt = "BookOperationId")]
        [Editable(false)]
        public int BookOperationId { get; set; }
    
    }
}