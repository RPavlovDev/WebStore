using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL.Context;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Mapping;
using WebStore.Infrastructure.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        public IHostingEnvironment HostingEnvironment;
        private readonly AppDbContext _db;
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData, IHostingEnvironment IHostingEnvironment, AppDbContext db)
        {
            HostingEnvironment = IHostingEnvironment;
            _db = db;
            _ProductData = ProductData;
        }

        public IActionResult Index(int? BrandId, int? SectionId)
        {
            var filter = new ProductFilter
            {
                BrandId = BrandId,
                SectionId = SectionId,
            };

            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products
                   .OrderBy(p => p.Order)
                   .ToView()
            });
        }

        [HttpPost, Authorize(Roles = Role.Administrators)]
        public IActionResult Index(int id, string name)
        {
            var newFileName = string.Empty;

            var product = _ProductData.GetProductById(id);
            if (product is null) return NotFound();

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;

                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        
                        newFileName = Convert.ToString(Guid.NewGuid()) + Path.GetExtension(fileName);
                        
                        fileName = Path.Combine(HostingEnvironment.WebRootPath, "images\\shop") + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        product.ImageUrl = newFileName;
                        _db.SaveChanges();
                    }
                }

            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _ProductData.GetProductById(id);
            if (product is null) return NotFound();

            return View(product.ToView());
        }
        
    }
}
