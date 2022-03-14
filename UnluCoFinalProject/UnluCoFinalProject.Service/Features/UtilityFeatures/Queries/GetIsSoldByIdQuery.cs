using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.UtilityFeatures.Queries
{
    public class GetIsSoldByIdQuery : IRequest<IsSold>
    {
        public int Id { get; set; }
        public class GetIsSoldByIdQueryHandler : IRequestHandler<GetIsSoldByIdQuery, IsSold>
        {
            private readonly IApplicationDbContext _context;
            public GetIsSoldByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IsSold> Handle(GetIsSoldByIdQuery request, CancellationToken cancellationToken)
            {
                var isSold = _context.IsSold.Where(a => a.Id == request.Id).FirstOrDefault();
                if (isSold == null) return null;
                return isSold;
            }
        }
    }
}
