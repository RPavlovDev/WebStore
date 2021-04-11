using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Services.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InDbProductData : IProductData
    {
        private readonly AppDbContext _db;

        public InDbProductData(AppDbContext db) => _db = db;

        public IEnumerable<Section> GetSections() => _db.Sections.Include(s => s.Products);

        public IEnumerable<Brand> GetBrands() => _db.Brands.Include(b => b.Products);

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products;
            //.Include(p => p.Section)
            //.Include(p => p.Brand);

            if (Filter?.Ids?.Length > 0)
                query = query.Where(product => Filter.Ids.Contains(product.Id));
            else
            {
                if (Filter?.SectionId is { } section_id)
                    query = query.Where(product => product.SectionId == section_id);

                if (Filter?.BrandId is { } brand_id)
                    query = query.Where(product => product.BrandId == brand_id);
            }

            return query;
        }

        public Product GetProductById(int id) => _db.Products
            .Include(p => p.Section)
            .Include(p => p.Brand)
            .FirstOrDefault(p => p.Id == id);
    }
}
