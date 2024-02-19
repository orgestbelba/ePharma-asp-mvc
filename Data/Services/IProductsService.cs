using ePharma_asp_mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByID(int id);
        Task<IEnumerable<Product>> Search(string searchString);
        Task<IEnumerable<Product>> Sort(string order);
        Task<IEnumerable<Product>> Filter(int? minPrice, int? maxPrice);
        Task AddProduct(Product product);
        Task Update(int id, Product product);
        Task Delete(int id);

    }
}
