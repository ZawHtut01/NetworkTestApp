using MediatR;

namespace Orders.Domain.Entities
{
    public record GetOrdersQuery : IRequest<List<Order>>;
}
