using MediatR;
using Orders.Domain.Entities;

namespace Orders.Application.Features
{
    public class GetOrdersQuery : IRequest<List<Order>>;
}
