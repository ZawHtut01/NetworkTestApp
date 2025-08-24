using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
