using ePharma_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public class ProductsService : IProductsService
    {

        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }
        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> Filter(int? minPrice, int? maxPrice)
        {
            var filteredProducts = await _context.Products
                .Where(p => (minPrice == null || p.Price >= minPrice)
                         && (maxPrice == null || p.Price <= maxPrice))
                .ToListAsync();

            return filteredProducts;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var data = await _context.Products.ToListAsync();
            return data;
        }

        public async Task<Product> GetByID(int id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return data;
        }

        public async Task<IEnumerable<Product>> Search(string searchString)
        {    
            var data = await GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                string filter = searchString.ToLower(); //Making the search not Case Sensitive
                var matches = data.Where(p => p.Name.ToLower().Contains(filter));
                return matches;
            }

            return data;
        }

        public async Task<IEnumerable<Product>> Sort(string order)
        {
            var data = await GetAllAsync();

            if (string.IsNullOrEmpty(order))
            {
                return data; // No sorting specified, return the original data
            }

            return order.ToLower() switch
            {
                "nameasc" => data.OrderBy(p => p.Name),
                "namedesc" => data.OrderByDescending(p => p.Name),
                "priceasc" => data.OrderBy(p => p.Price),
                "pricedesc" => data.OrderByDescending(p => p.Price),
                _ => data,// If the order is not recognized, return the original data
            };
        }

        public Task Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
