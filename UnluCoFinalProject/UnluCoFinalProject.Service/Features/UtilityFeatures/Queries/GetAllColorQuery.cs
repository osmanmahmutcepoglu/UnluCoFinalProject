using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.UtilityFeatures.Queries
{
    public class GetAllColorQuery : IRequest<IEnumerable<Color>>
    {

        public class GetAllColorQueryHandler : IRequestHandler<GetAllColorQuery, IEnumerable<Color>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllColorQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Color>> Handle(GetAllColorQuery request, CancellationToken cancellationToken)
            {
                var colorList = await _context.Color.ToListAsync();
                if (colorList == null)
                {
                    return null;
                }
                return colorList.AsReadOnly();
            }
        }
    }
}
