using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Migrations.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is Keyword of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is Description of eShopSolution" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });
            modelBuilder.Entity<Category>().HasData(
                    new Category()
                    {
                        Id = 1,
                        IsShowOnHome = true,
                        ParentId = null,
                        SortOrder = 1,
                        Status = Status.Active
                    },
                    new Category()
                    {
                        Id = 2,
                        IsShowOnHome = true,
                        ParentId = null,
                        SortOrder = 2,
                        Status = Status.Active
                    }
                    );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                            new CategoryTranslation() {Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                            new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                            new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang nữ" },
                            new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                );
            modelBuilder.Entity<Product>().HasData(
                    new Product()
                    {
                        Id = 1,
                        DateCreated = DateTime.Now,
                        OriginalPrice = 100000,
                        Price = 200000,
                        Stock = 0,
                        ViewCount = 0
                    }
                    );
            modelBuilder.Entity<ProductTranslation>().HasData(
                    new ProductTranslation() {Id = 1, ProductId = 1, Name = "Áo sơ mi nam trắng Viết Tiến", LanguageId = "vi-VN", SeoAlias = "ao-so-mi-nam-trang-viet-tien", SeoDescription = "Áo sơ mi nam trắng Viết Tiến", SeoTitle = "Áo sơ mi nam trắng Viết Tiến", Details = "Áo sơ mi nam trắng Viết Tiến", Description = "Áo sơ mi nam trắng Viết Tiến" },
                    new ProductTranslation() { Id = 2, ProductId = 1, Name = "Viet Tien Men T-Shirt", LanguageId = "en-US", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "Viet Tien Men T-Shirt", SeoTitle = "Viet Tien Men T-Shirt", Details = "Viet Tien Men T-Shirt", Description = "Viet Tien Men T-Shirt" }

                );
            var adminId = new Guid("891EA0CC-8F28-4858-9154-24F3CD80C3FF");
            var roleId = new Guid("49D64DE6-AB22-4C6E-97B1-511BD45AE04E");
            modelBuilder.Entity<ProductInCategory>().HasData(
                    new ProductInCategory() {ProductId = 1, CategoryId = 1}
                );
            modelBuilder.Entity<Order>().HasData(
                    new Order() { Id = 1, ShipAddress = "Vĩnh Phúc", ShipEmail = "HieuKT@gmail.com", ShipName = "AnhTV", ShipPhoneNumber = "0987654234", Status = OrderStatus.InProgress, UserId = adminId }
                );
            modelBuilder.Entity<OrderDetail>().HasData(
                    new OrderDetail() { OrderId = 1, Price = 200000, ProductId = 1, Quantity = 1 }
                );


            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "khuongtrunghieu38@gmail.com",
                NormalizedEmail = "khuongtrunghieu38@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Abcd1234#"),
                SecurityStamp = string.Empty,
                FirstName = "Hieu",
                LastName = "Khuong",
                Dob = new DateTime(2020, 01, 31)
            }) ;

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
