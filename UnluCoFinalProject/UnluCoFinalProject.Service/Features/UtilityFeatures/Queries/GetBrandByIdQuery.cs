using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.UtilityFeatures.Queries
{
    public class GetBrandByIdQuery : IRequest<Brand>
    {
        public int Id { get; set; }
        public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Brand>
        {
            private readonly IApplicationDbContext _context;
            public GetBrandByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
            {
                var brand = _context.Brand.Where(a => a.Id == request.Id).FirstOrDefault();
                if (brand == null) return null;
                return brand;
            }
        }
    }
}
