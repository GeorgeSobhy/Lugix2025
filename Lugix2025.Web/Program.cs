using AutoMapper;
using Lugx2025.BusinessLogic.Profiles;
using Lugx2025.BusinessLogic.Services;
using Lugx2025.BusinessLogic.Services.Interfaces;
using Lugx2025.Data.Context;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository;
using Lugx2025.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lugix2025.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("UAT"));
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GeneralProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddIdentity<ApplicationUser,IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDBContext>();
            builder.Services.AddScoped<ITagRepository,TagRepository>();
            builder.Services.AddScoped<IGameRepository,GameRepository>();
            builder.Services.AddScoped<IContactUsRepository,ContactUsRepository>();
            builder.Services.AddScoped<IErrorLogRepository,ErrorLogRepository>();
            builder.Services.AddScoped<IGenreRepository,GenreRepository>();
            builder.Services.AddScoped<INewsLetterRepository, NewsLetterRepository>();
            builder.Services.AddScoped<ISettingsRepository,SettingsRepository>();
            builder.Services.AddScoped<ITopCategoriesRepository,TopCategoriesRepository>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<ICityRepository,CityRepository>();
            builder.Services.AddScoped<ICountryRepository,CountryRepository>();

            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IContactUsService, ContactUsService>();
            builder.Services.AddScoped<IErrorLogService, ErrorLogService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<INewsLetterService, NewsLetterService>();
            builder.Services.AddScoped<ISettingsService, SettingsService>();
            builder.Services.AddScoped<ITopCategoriesService, TopCategoriesService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICountryService, CountryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
