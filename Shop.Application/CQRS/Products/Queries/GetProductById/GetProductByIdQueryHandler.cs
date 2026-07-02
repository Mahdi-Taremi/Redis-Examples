using MediatR;
using Shop.Application.Common.Interfaces.Repositories;
using Shop.Application.CQRS.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.CQRS.Products.Queries.GetProductById
{
    public sealed class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(
            IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var product =
                await _repository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (product is null)
                throw new KeyNotFoundException(
                    $"Product '{request.Id}' was not found.");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
