using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
        public string IsSold { get; set; }
        public string ImagePath { get; set; }
        public bool IsOfferable { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _context.Product.Where(a => a.Id == request.Id).FirstOrDefault();

                if (product == null)
                {
                    return default;
                }
                else
                {
                    product.ProductName = request.ProductName;
                    product.Description = request.Description;
                    product.CategoryId = request.CategoryId;
                    product.ColorId = request.ColorId;
                    product.BrandId = request.BrandId;
                    product.Price = request.Price;
                    product.IsSold = request.IsSold;
                    product.ImagePath = request.ImagePath;
                    product.IsOfferable = request.IsOfferable;
                    _context.Product.Update(product);
                    await _context.SaveChangesAsync();
                    return product.Id;
                }
            }
        }
    }
}
