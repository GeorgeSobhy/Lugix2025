using Lugx2025.Data.Context;
using Lugx2025.Data.Entities;
using Lugx2025.Data.Repository;
using Lugx2025.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Seeder
{
    public static class Seeder
    {
        public  static async Task Intialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var genreRepo = serviceProvider.GetRequiredService<IGenreRepository>();
            var settingsRepo = serviceProvider.GetRequiredService<ISettingsRepository>();
            var cityRepo = serviceProvider.GetRequiredService<ICityRepository>();
            var countryRepo = serviceProvider.GetRequiredService<ICountryRepository>();
            var context = serviceProvider.GetRequiredService<ApplicationDBContext>();
            var gameRepo = serviceProvider.GetRequiredService<IGameRepository>();

            await context.Database.MigrateAsync();
            await context.Database.EnsureCreatedAsync();

            if (!(await cityRepo.GetAllAsync()).Any())
                await cityRepo.AddAsync(new City() { Name = "Cario" });

            if (!(await countryRepo.GetAllAsync()).Any())
                await countryRepo.AddAsync(new Country() { Name = "Egypt" });
            if (!roleManager.Roles.Any())
            {
                var role = new IdentityRole<int>("SuperAdmin");
                await roleManager.CreateAsync(role);
                 role = new IdentityRole<int>("Admin");
                await roleManager.CreateAsync(role);
                 role = new IdentityRole<int>("User");
                await roleManager.CreateAsync(role);
            }

            if (!userManager.Users.Any())
            {
                var city = (await cityRepo.GetAllAsync()).FirstOrDefault();
                var country = (await countryRepo.GetAllAsync()).FirstOrDefault();
                var user = new ApplicationUser { UserName = "George", Email = "test@test.com", CityId = city?.Id ?? 1, Address = "address", CountryId = country?.Id ?? 1 };
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }
            if (!(await genreRepo.GetAllAsync()).Any())
            { 
                await genreRepo.AddAsync(new Genre() { Name = "Default", Description = "Default", Code = "dflt"});
            }

            if (!(await gameRepo.GetAllAsync()).Any())
            {
                var genre = (await genreRepo.GetAllAsync()).FirstOrDefault();
                var user = await userManager.FindByEmailAsync("test@test.com");
                var game = new Game()
                {
                    Name = "Default Game",
                    ShortDescription="short description",
                    GameCode = "DFLT",
                    Description = "Default",
                    GenreId = genre?.Id ?? 1,
                    AvailableCount = 1,
                    IsActive = true,
                    PriceAfterSale = 10,
                    PriceBeforeSale = 15,
                    CreationDate = DateTime.Now,
                    UploaderId = user?.Id ?? 1,
                    PhotoPath = "https://cdn1.epicgames.com/offer/b0cd075465c44f87be3b505ac04a2e46/GTAV_CHARM_Epic_FirstParty_PortraitFOB_1200x1600_R02_1200x1600-a5528b33df876e64f5dee728830c80a3?resize=1&w=360&h=480&quality=medium"
                };
                await gameRepo.AddAsync(game);
            }
            if(!(await settingsRepo.GetAllAsync()).Any())
            {
                var game = (await gameRepo.GetAllAsync()).FirstOrDefault();
                await settingsRepo.AddAsync(new Settings()
                {
                    ContactUsAddress = "Default Address",
                    ContactUsDescription = "Default",
                    ContactUsEmail = "Default@mail.com",
                    ContactUsMapUrl = "",
                    ContactUsPhone = "+132423141324",
                    MainGameId = game?.Id ?? 1,
                    MainPageHeader = "Default Headers"
                });
            }
        }
    }
}
