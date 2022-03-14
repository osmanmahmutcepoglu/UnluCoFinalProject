using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProductByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Product.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (product == null) return default;
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
