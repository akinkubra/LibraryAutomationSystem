using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LibraryAutomationSystem.Models;
using LibraryAutomationSystem.ViewModel;

namespace LibraryAutomationSystem.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Book, BookViewModel>();
            Mapper.CreateMap<BookViewModel, Book>();
        }
    }
}