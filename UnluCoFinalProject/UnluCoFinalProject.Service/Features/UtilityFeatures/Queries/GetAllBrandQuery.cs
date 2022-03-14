using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.UtilityFeatures.Queries
{
    public class GetAllBrandQuery : IRequest<IEnumerable<Brand>>
    {

        public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<Brand>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBrandQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Brand>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
            {
                var brandList = await _context.Brand.ToListAsync();
                if (brandList == null)
                {
                    return null;
                }
                return brandList.AsReadOnly();
            }
        }
    }
}
