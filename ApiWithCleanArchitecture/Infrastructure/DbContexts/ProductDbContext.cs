﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic Items"
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Dresses"
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery Items"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
