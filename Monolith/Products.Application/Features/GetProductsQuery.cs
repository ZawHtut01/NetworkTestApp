using MediatR;
using Products.Domain.Entities;

namespace Products.Application.Features
{
    public record GetProductsQuery : IRequest<List<Product>>;
}
