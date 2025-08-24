using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Features;

namespace ModularMonolith.Web.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _mediator.Send(new GetProductsQuery()));
    }
}
