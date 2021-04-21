using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Services.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int id);
        Task<IEnumerable<Product>> GetProductsByPage(int page, int pageSize = 3);
        Task<int> GetProductsCount();
    }
}
