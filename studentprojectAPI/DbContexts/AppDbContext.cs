using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using studentprojectAPI.Auth;
using studentprojectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.DbContexts
{// IdentityUser --> ApplicationUser
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // seed music Genres
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"), GenreName = "Classical" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"), GenreName = "Jazz" });
            modelBuilder.Entity<Genre>().HasData(new Genre { GenreId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"), GenreName = "Contemporary" });

            // seed records
            modelBuilder.Entity<Record>().HasData(new Record
            {
                RecordId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                Title = "Born To Run",
                Artist = "Bruce Springsteen",
                Details = "na",
                History = "na",
                ImageUrl = @"\images\borntorun.jpg",
                ImageThumbnailUrl = @"\images\borntorun.jpg",
                RecordOfTheWeek = true,
                GenreId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                Notes = "na",
                Price = 100m
            });

            modelBuilder.Entity<Record>().HasData(new Record
            {
                RecordId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                Title = "Cotton Club days",
                Artist = "Duke Ellington",
                Details = "na",
                History = "na",
                ImageUrl = @"\images\cottonclubdays.jpg",
                ImageThumbnailUrl = @"\images\cottonclubdays.jpg",
                RecordOfTheWeek = false,
                GenreId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                Notes = "na",
                Price = 100m
            });

            modelBuilder.Entity<Record>().HasData(new Record
            {
                RecordId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                Title = "Colour by Numbers",
                Artist = "Culture Club",
                Details = "na",
                History = "na",
                ImageUrl = @"\images\colourbynumbers.jpg",
                ImageThumbnailUrl = @"\images\colourbynumbers.jpg",
                RecordOfTheWeek = false,
                GenreId = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                Notes = "na",
                Price = 100m
            });
        }
    }
}
