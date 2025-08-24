using MediatR;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;

namespace Orders.Application.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<Order>>
    {
        private readonly IOrderRepository _repo;
        public GetOrdersQueryHandler(IOrderRepository repo) => _repo = repo;

        public async Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
