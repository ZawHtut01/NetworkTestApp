using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Repositories;
using Products.Infrastructure.Data;

namespace Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(Guid id)
            => await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product)
            => await _context.Products.AddAsync(product);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
