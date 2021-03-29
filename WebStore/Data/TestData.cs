using System;
using System.Collections.Generic;

using WebStore.Domain.Entities;
using WebStore.Models;

namespace WebStore.Data
{
    internal static class TestData
    {
        public static readonly List<Employee> Employees = new List<Employee>()
        {
            new Employee { Id = 0, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", CityDepartment = "Москва", BirthDate = new DateTime(1980, 1, 1), Salary = "55000"},
            new Employee { Id = 0, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", CityDepartment = "Санкт-Петербург", BirthDate = new DateTime(1995, 1, 1), Salary = "40000" },
            new Employee { Id = 0, LastName = "Сидоров", FirstName = "Сидор", Patronymic = "Сидорович", CityDepartment = "Казань", BirthDate = new DateTime(2001, 1, 1), Salary = "35000" }
        };

        public static IEnumerable<Section> Sections { get; } = new[]
        {
              new Section { Id = 0, Name = "Спорт", Order = 0 },
              new Section { Id = 0, Name = "Nike", Order = 0, ParentId = 1 },
              new Section { Id = 0, Name = "Under Armour", Order = 1, ParentId = 1 },
              new Section { Id = 0, Name = "Adidas", Order = 2, ParentId = 1 },
              new Section { Id = 0, Name = "Puma", Order = 3, ParentId = 1 },
              new Section { Id = 0, Name = "ASICS", Order = 4, ParentId = 1 },
              new Section { Id = 0, Name = "Для мужчин", Order = 1 },
              new Section { Id = 0, Name = "Fendi", Order = 0, ParentId = 7 },
              new Section { Id = 0, Name = "Guess", Order = 1, ParentId = 7 },
              new Section { Id = 0, Name = "Valentino", Order = 2, ParentId = 7 },
              new Section { Id = 0, Name = "Диор", Order = 3, ParentId = 7 },
              new Section { Id = 0, Name = "Версачи", Order = 4, ParentId = 7 },
              new Section { Id = 0, Name = "Армани", Order = 5, ParentId = 7 },
              new Section { Id = 0, Name = "Prada", Order = 6, ParentId = 7 },
              new Section { Id = 0, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
              new Section { Id = 0, Name = "Шанель", Order = 8, ParentId = 7 },
              new Section { Id = 0, Name = "Гуччи", Order = 9, ParentId = 7 },
              new Section { Id = 0, Name = "Для женщин", Order = 2 },
              new Section { Id = 0, Name = "Fendi", Order = 0, ParentId = 18 },
              new Section { Id = 0, Name = "Guess", Order = 1, ParentId = 18 },
              new Section { Id = 0, Name = "Valentino", Order = 2, ParentId = 18 },
              new Section { Id = 0, Name = "Dior", Order = 3, ParentId = 18 },
              new Section { Id = 0, Name = "Versace", Order = 4, ParentId = 18 },
              new Section { Id = 0, Name = "Для детей", Order = 3 },
              new Section { Id = 0, Name = "Мода", Order = 4 },
              new Section { Id = 0, Name = "Для дома", Order = 5 },
              new Section { Id = 0, Name = "Интерьер", Order = 6 },
              new Section { Id = 0, Name = "Одежда", Order = 7 },
              new Section { Id = 0, Name = "Сумки", Order = 8 },
              new Section { Id = 0, Name = "Обувь", Order = 9 },
        };

        public static IEnumerable<Brand> Brands { get; } = new[]
        {
            new Brand { Id = 0, Name = "Acne", Order = 0 },
            new Brand { Id = 0, Name = "Grune Erde", Order = 1 },
            new Brand { Id = 0, Name = "Albiro", Order = 2 },
            new Brand { Id = 0, Name = "Ronhill", Order = 3 },
            new Brand { Id = 0, Name = "Oddmolly", Order = 4 },
            new Brand { Id = 0, Name = "Boudestijn", Order = 5 },
            new Brand { Id = 0, Name = "Rosch creative culture", Order = 6 },
        };

        public static IEnumerable<Product> Products { get; } = new[]
        {
            new Product { Id = 0, Name = "Белое платье", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
            new Product { Id = 0, Name = "Розовое платье", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
            new Product { Id = 0, Name = "Красное платье", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
            new Product { Id = 0, Name = "Джинсы", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
            new Product { Id = 0, Name = "Лёгкая майка", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
            new Product { Id = 0, Name = "Лёгкое голубое поло", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
            new Product { Id = 0, Name = "Платье белое", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
            new Product { Id = 0, Name = "Костюм кролика", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
            new Product { Id = 0, Name = "Красное китайское платье", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
            new Product { Id = 0, Name = "Женские джинсы", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
            new Product { Id = 0, Name = "Джинсы женские", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
            new Product { Id = 0, Name = "Летний костюм", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
        };
    }
}
