using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryAutomationSystem.ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "id", Prompt = "id")]
        [Editable(false)]
        public int id { get; set; }

        [Display(Name = "Name", Prompt = "Name")]
        [Editable(false)]
        public string Name { get; set; }

        [Display(Name = "Surname", Prompt = "Surname")]
        [Editable(false)]
        public string Surname { get; set; }

        [Display(Name = "Username", Prompt = "Username")]
        [Editable(false)]
        public string Username { get; set; }

        [Display(Name = "Password", Prompt = "Password")]
        [Editable(false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "OldPassword", Prompt = "OldPassword")]
        [Editable(false)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "New password and confirmation does not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ReturnToken { get; set; }

        [Required(ErrorMessage = "We need your email to send you a reset link!")]
        [Display(Name = "Your account email")]
        public string Email { get; set; }

        [Display(Name = "Mail", Prompt = "Mail")]
        [Editable(false)]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

    }
}