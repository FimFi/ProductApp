using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using ProductApp.Infrastructure.SQLLite.Data.Helpers;

namespace ProductApp.Infrastructure.SQLLite.Data
{
    public class DBInitializer: IDBInitializer
    {
        private IAuthenticationHelper authenticationHelper;
        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }
        public void SeedDB(ProductAppLiteContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            if (ctx.TodoItems.Any())
            {
                return;
                //ctx.Database.ExecuteSqlRaw("DROP TABLE Pets");
                //ctx.Database.ExecuteSqlRaw("DROP Table Owner");
                //ctx.Database.ExecuteSqlRaw("DROP Table Todo");
                //ctx.Database.ExecuteSqlRaw("DROP Table Token");
                //ctx.Database.EnsureCreated();
            }

            ctx.Products.Add(new Product()
            {
                Name = "beer1",
                Price = 50,
                Type = "dark"
            });

            ctx.Products.Add(new Product()
            {
                Name = "beer3",
                Price = 100,
                Type = "ale"
            });

            ctx.Products.Add(new Product()
            {
                Name = "beer3",
                Price = 150,
                Type = "light"
            });

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="dosmth"},
                new TodoItem { IsComplete=false, Name="dosmthelse"}
            };

            string password = "1234";
            byte[] passwordHash, passwordSalt, passwordHash1, passwordSalt1;
            authenticationHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            authenticationHelper.CreatePasswordHash(password, out passwordHash1, out passwordSalt1);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHash1,
                    PasswordSalt = passwordSalt1,
                    IsAdmin = true
                }
            };

            ctx.TodoItems.AddRange(items);
            ctx.Users.AddRange(users);

            ctx.SaveChanges();
        }
    }
}
