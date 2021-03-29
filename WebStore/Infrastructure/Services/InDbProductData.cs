using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Services.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InDbProductData : IProductData
    {
        private readonly AppDbContext _db;

        public InDbProductData(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Section> GetSections() => _db.Sections;

        public IEnumerable<Brand> GetBrands() => _db.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            if (Filter?.SectionId == null && Filter?.BrandId == null)
                return _db.Products.IgnoreQueryFilters();

            var query = _db.Products;

            if (Filter?.SectionId is { } section_id)
            {
                _db.SectionId = section_id;
                query.Include(x => x.SectionId);
            }

            if (Filter?.BrandId is { } brand_id)
            {
                _db.BrandId = brand_id;
                query.Include(x => x.BrandId);
            }

            return query.ToList();
        }
    }
}
