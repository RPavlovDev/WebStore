using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.ViewModels
{
    public class ProductPagingViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
