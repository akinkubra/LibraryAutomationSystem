using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using LibraryAutomationSystem.ViewModel;
using System.Web.Security;
using WebMatrix.WebData;
using LibraryAutomationSystem.Models;
using AutoMapper;

namespace LibraryAutomationSystem.Services
{
    public class UserAddService
    {
        LibraryDbContext UserAdd = new LibraryDbContext();

        public UserAddService()
        {
            Mapping();
        }

        public void Mapping()
        {
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<User, UserViewModel>();
        }
        public void AddUser(UserViewModel userVm)
        {
            User user = Mapper.Map<User>(userVm);
            UserAdd.Users.Add(user);
            UserAdd.SaveChanges();
            PasswordRecovery PR = new PasswordRecovery();
            PR.RecoStatus = false;
            PR.RecoCount = 0;
            PR.RecoDate = null;
            PR.UserId = user.UserId;
            UserAdd.PasswordRecoveries.Add(PR);
            UserAdd.SaveChanges();
        }

    }
}