using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.CQRS.Products.Commands.CreateProduct;
using Shop.Application.CQRS.Products.Queries;

namespace Redis_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            var result =
                await _mediator.Send(
                    command,
                    cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
             int pageNumber = 1,
             int pageSize = 10,
             CancellationToken cancellationToken = default)
        {
            var result =
                await _mediator.Send(
                    new GetProductsQuery(
                        pageNumber,
                        pageSize),
                    cancellationToken);

            return Ok(result);
        }
    }
}
