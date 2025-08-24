using MediatR;
using Products.Application.Features;
using Products.Domain.Entities;
using Products.Domain.Repositories;

namespace Products.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        private readonly IProductRepository _repo;
        public GetProductsQueryHandler(IProductRepository repo) => _repo = repo;

        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }

}
