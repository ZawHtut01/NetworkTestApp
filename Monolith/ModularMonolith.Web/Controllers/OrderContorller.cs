using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;

namespace ModularMonolith.Web.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repository.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();
            return Ok();
        }
    }
}
