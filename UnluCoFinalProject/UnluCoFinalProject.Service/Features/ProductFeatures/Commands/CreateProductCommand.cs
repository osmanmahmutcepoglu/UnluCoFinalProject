using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public string IsSold { get; set; }
        public string ImagePath { get; set; }
        public bool IsOfferable { get; set; }
        public string UserId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.ProductName = request.ProductName;
                product.Description = request.Description;
                product.CategoryId = request.CategoryId;
                product.ColorId = request.ColorId;
                product.BrandId = request.BrandId;
                product.Price = request.Price;
                product.IsSold = request.IsSold;
                product.ImagePath = request.ImagePath;
                product.IsOfferable = request.IsOfferable;
                product.UserId = request.UserId;

                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
