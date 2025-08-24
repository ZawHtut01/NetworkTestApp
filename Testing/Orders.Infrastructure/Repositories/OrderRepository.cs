using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Infrastructure.Data;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context) => _context = context;

        public async Task<List<Order>> GetAllAsync()
            => await _context.Orders.ToListAsync();

        public async Task AddAsync(Order order)
            => await _context.Orders.AddAsync(order);

        public Task<bool> UpdateAsync(Order order)
        {
            if (order == null)
            {
                return Task.FromResult(false);
            }

            _context.Orders.Update(order);
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                return true;
            }

            return false;
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
