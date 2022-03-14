using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.UtilityFeatures.Queries
{
    public class GetColorByIdQuery : IRequest<Color>
    {
        public int Id { get; set; }
        public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQuery, Color>
        {
            private readonly IApplicationDbContext _context;
            public GetColorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Color> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
            {
                var color = _context.Color.Where(a => a.Id == request.Id).FirstOrDefault();
                if (color == null) return null;
                return color;
            }
        }
    }
}
