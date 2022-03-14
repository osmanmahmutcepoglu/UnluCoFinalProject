using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.UtilityFeatures.Queries
{
    public class GetAllIsSoldQuery : IRequest<IEnumerable<IsSold>>
    {

        public class GetAllIsSoldQueryHandler : IRequestHandler<GetAllIsSoldQuery, IEnumerable<IsSold>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllIsSoldQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<IsSold>> Handle(GetAllIsSoldQuery request, CancellationToken cancellationToken)
            {
                var isSoldList = await _context.IsSold.ToListAsync();
                if (isSoldList == null)
                {
                    return null;
                }
                return isSoldList.AsReadOnly();
            }
        }
    }
}
