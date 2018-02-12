using LibraryAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using LibraryAutomationSystem.ViewModel;
using System.Web.Security;
using WebMatrix.WebData;
using System.Net.Mail;
using LibraryAutomationSystem.Services;

namespace LibraryAutomationSystem.Controllers
{
    public class UserController : Controller
    {

        LibraryDbContext kayit = new LibraryDbContext();
        LibraryDbContext login = new LibraryDbContext();
        LibraryDbContext passReset = new LibraryDbContext();
        UserAddService userAddservice = new UserAddService();
        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserViewModel user)
        {
            if(string.IsNullOrEmpty(user.Surname)||string.IsNullOrEmpty(user.Username)||string.IsNullOrEmpty(user.Password)||string.IsNullOrEmpty(user.Mail))
            {
                TempData["notice"] = "Lütfen bütün alanları doldurunuz!";
                return View();
            }
            else
            {
                foreach (var item in kayit.Users)
                {
                    if (user.Username == item.Username)
                    {
                        TempData["notice"] = "Bu kullanıcı adı daha önce kullanılmıştır!";                      
                        break;
                    }
                    else if(user.Password == item.Password)
                    {
                        TempData["notice"] = "Bu şifre daha önce kullanılmıştır!";
                        break;
                    }                                                                                   
                }
                if (TempData["notice"] == null)
                {
                    userAddservice.AddUser(user);
                    TempData["notice"] = "Kütüphaneye başarıyla kayıt oldunuz";
                    return View();
                }
                else
                {
                    return View();
                }               
            }            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            string userName = user.Username;
            string pass = user.Password;
            User usr = (from i in login.Users
                        where i.Password == pass && i.Username == userName
                        select i).FirstOrDefault();
            if (usr != null)
            {
                FormsAuthentication.SetAuthCookie(user.Mail, true);
                Session["UserID"] = usr.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass))
            {
                TempData["notice"] = "Lütfen zorunlu alanları doldurunuz";
                return View();
            }
            else
            {
                TempData["notice"] = "Yanlış kullanıcı adı veya şifre girdiniz!";
                return View();
            }


        }

        [AllowAnonymous]
        public ActionResult LostPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LostPassword(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username))
            {
                TempData["notice"] = "Lütfen kullanıcı adınızı giriniz";
                return View();
            }
            else
            {
                User foundUser = (from u in passReset.Users
                                  where u.Username == model.Username
                                  select u).FirstOrDefault();
                if (foundUser == null)
                {
                    TempData["notice"] = "Yanlış kullanıcı adı girdiniz.";
                }
                else
                {
                    string randomParola = "";
                    Random rastgele = new Random();
                    for (int a = 0; a < 6; a++)
                    {
                        randomParola += rastgele.Next(0, 9);
                    }

                    if (CheckandSetRecovery(foundUser.UserId) == false)
                    {
                        foundUser.Password = randomParola;
                        passReset.SaveChanges();
                        TempData["notice"] = "Parolanız gönderildi.Yeni parolanız:" + randomParola + ".     Giriş yapabilirsiniz.";
                    }
                    else
                    {
                        TempData["notice"] = "Zaten 30 dakika içerinde parola almışsınız.";
                    }                  
                }
                return View();
            }
        }


        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.OldPassword) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.ConfirmPassword))
            {
                TempData["notice"] = "Lütfen gerekli bilgileri giriniz";
                return View();
            }
            else
            {
                User foundUser = (from u in passReset.Users
                                  where u.Password == model.OldPassword
                                  select u).FirstOrDefault();
                if (foundUser == null)
                {
                    TempData["notice"] = "Şifrenizi yanlış girdiniz!";
                }
                else
                {
                    if (CheckandSetRecovery(foundUser.UserId) == false)
                    {
                        foreach (var item in kayit.Users)
                        {
                            if (item.Password == model.Password)
                            {
                                TempData["notice"] = "Bu şifre daha önce kullanılmıştır!";
                                break;
                            }
                            else
                            {
                                foundUser.Password = model.Password;
                                passReset.SaveChanges();
                                TempData["notice"] = "Parolanız başarıyla değiştirildi.Giriş yapabilirsiniz";
                            }                           
                        }                      
                    }
                }
                return View();
            }

        }
        public bool CheckandSetRecovery(int id)
        {
            bool check = false;
            var find = (from x in passReset.PasswordRecoveries
                        where x.UserId == id
                        select x).FirstOrDefault();
            if (find.RecoStatus == true)
            {
                DateTime newDate = DateTime.Now;
                DateTime recoDate = (DateTime)find.RecoDate;
                TimeSpan time = new TimeSpan();
                time = newDate - recoDate;
                if (time.TotalMinutes < 30)
                {
                    check = true;
                }
            }
            else
            {
                find.RecoDate = DateTime.Now;
                find.RecoStatus = false;
                find.RecoCount += 1;
                passReset.SaveChanges();
                check = false;
            }

            return check;
        }
    }

}
