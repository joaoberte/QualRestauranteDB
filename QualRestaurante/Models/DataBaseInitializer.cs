using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace QualRestaurante.Models
{
    public class DataBaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var restaurantes = new List<Restaurante>
            {
                new Restaurante { Nome = "Bar 50", Preco = 17.50 },
                new Restaurante { Nome = "Restaurante Universitario", Preco = 7.30 },
                new Restaurante { Nome = "Sabor Familia", Preco = 19.50 },
                new Restaurante { Nome = "Panorama", Preco = 33.00 },
                new Restaurante { Nome = "Espaço 32", Preco = 20.90 },
                new Restaurante { Nome = "Buffet Victoria", Preco = 17.00 },
                new Restaurante { Nome = "Pé de Manga", Preco = 13.00 },
                new Restaurante { Nome = "Silva Lanches", Preco = 22.50 },
                new Restaurante { Nome = "Palatus", Preco = 23.00 }
            };

            restaurantes.ForEach(s => context.Restaurantes.Add(s));
            context.SaveChanges();

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "carlos@db.com",
                    Email = "carlos@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "miranda@db.com",
                    Email = "miranda@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "augusto@db.com",
                    Email = "augusto@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "paulo@db.com",
                    Email = "paulo@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "carla@db.com",
                    Email = "carla@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "daniela@db.com",
                    Email = "daniela@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            password = passwordHash.HashPassword("123456");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "diego@db.com",
                    Email = "diego@db.com",
                    PasswordHash = password,
                    SecurityStamp = Guid.NewGuid().ToString()
                });
        }
    }
}