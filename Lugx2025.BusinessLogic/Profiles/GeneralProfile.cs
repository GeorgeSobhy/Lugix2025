using AutoMapper;
using Lugx2025.BusinessLogic.Models;
using Lugx2025.BusinessLogic.ViewModels;
using Lugx2025.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.Profiles
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<Game, GameModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();
            CreateMap<TopCategories, TopCategoriesModel>().ReverseMap();
            CreateMap<ErrorLog, ErrorLogModel>().ReverseMap();
            CreateMap<ContactUs, ContactUsModel>().ReverseMap();
            CreateMap<NewsLetter, NewsLetterModel>().ReverseMap();
            CreateMap<Settings, SettingsModel>().ReverseMap();
            CreateMap<ApplicationUserModel, ApplicationUser>().ReverseMap();
            CreateMap<City, CityModel>().ReverseMap();
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<RegisterModel,ApplicationUser>().ReverseMap();
            CreateMap<RegisterModel, ApplicationUserModel>().ReverseMap();
            CreateMap<ContactUsPageVM, SettingsModel>().ReverseMap();

        }
    }
}
