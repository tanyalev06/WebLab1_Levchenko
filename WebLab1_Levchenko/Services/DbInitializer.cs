using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            if (!context.CatsGroups.Any())
            {
                context.CatsGroups.AddRange(
                new List<CatsGroup>
                {
                    new CatsGroup {GroupName="Персидские"},
                    new CatsGroup {GroupName="Британцы"},
                    new CatsGroup {GroupName="Сиамские"},
                    new CatsGroup {GroupName="Шотландцы"},
                    new CatsGroup {GroupName="Ангорские"},
                    new CatsGroup {GroupName="Просто милахи"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Cats.Any())
            {
                context.Cats.AddRange(
                new List<Cats>
                {
                     new Cats {CatsColor="Красивый", CatsName="Мурка", CatsWeight=200, Image="Котик1.jpg",  CatsGroupID=6},
                     new Cats {CatsColor="Очень Красивый", CatsName="Мурчик", CatsWeight=300, Image="Котик2.jpg",  CatsGroupID=6},
                     new Cats {CatsColor="Оч-оч Красивый", CatsName="Котенок", CatsWeight=250, Image="Котик3.jpg",  CatsGroupID=6},
                     new Cats {CatsColor="Красивенный", CatsName="Котяра", CatsWeight=400, Image="Котик4.jpg",  CatsGroupID=6},
                     new Cats {CatsColor="Разноцветный", CatsName="Котище", CatsWeight=150, Image="Котик5.jpg",  CatsGroupID=6},
                     new Cats {CatsColor="Красивый тоже", CatsName="Мурлыще", CatsWeight=200, Image="Котик6.jpg",  CatsGroupID=6}
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
