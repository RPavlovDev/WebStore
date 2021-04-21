using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrators)]
    public class ProductsController : Controller
    {
        public AppDbContext Db { get; }
        private readonly IProductData _ProductData;

        public ProductsController(IProductData ProductData, AppDbContext _db)
        {
            Db = _db;
            _ProductData = ProductData;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице

            var items = _ProductData.GetProductsByPage(page, pageSize)?.Result;
            var count = _ProductData.GetProductsCount()?.Result;

            PageViewModel pageViewModel = new PageViewModel(count.Value, page, pageSize);
            ProductPagingViewModel viewModel = new ProductPagingViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };
            return View(viewModel);
        }

        public IActionResult Edit(int id) =>
            _ProductData.GetProductById(id) is { } product
                ? View(product)
                : NotFound();

        public IActionResult Delete(int id) =>
            _ProductData.GetProductById(id) is { } product
                ? View(product)
                : NotFound();
    }
}
