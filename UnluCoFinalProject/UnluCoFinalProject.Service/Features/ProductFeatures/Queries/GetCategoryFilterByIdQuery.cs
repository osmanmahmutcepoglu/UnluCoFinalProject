using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.ProductFeatures.Queries
{
    public class GetCategoryFilterByIdQuery : IRequest<IEnumerable<Product>>
    {
        public int CategoryId { get; set; }
        public class GetCategoryFilterByIdQueryHandler : IRequestHandler<GetCategoryFilterByIdQuery, IEnumerable<Product>>
        {
            private readonly IApplicationDbContext _context;
            public GetCategoryFilterByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetCategoryFilterByIdQuery request, CancellationToken cancellationToken)
            {
                var productList = await _context.Product.Where(a => a.CategoryId == request.CategoryId).ToListAsync();
                if (productList == null) return null;
                return productList.AsReadOnly();
            }
        }
    }
}
