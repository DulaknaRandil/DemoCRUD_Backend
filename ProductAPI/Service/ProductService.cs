using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.IService;
using ProductAPI.Model;

namespace ProductAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product) {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        
       }

        public async Task<bool> DeleteAsync(int id)
        {
           var product = await _context.Products.FindAsync(id);

            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<IEnumerable<Product>> GetAllAysnc() =>
            await _context.Products.ToListAsync();
       

        public async Task<Product> GetByIdAysnc(int id) =>
            await _context.Products.FindAsync(id);
       

        public async Task<bool> UpdateAysnc(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            await _context.SaveChangesAsync();
            return true;
           
        }
    }
}
