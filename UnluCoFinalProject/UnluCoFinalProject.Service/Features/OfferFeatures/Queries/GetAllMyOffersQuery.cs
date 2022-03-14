using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.OfferFeatures.Queries
{
    public class GetAllMyOffersQuery : IRequest<IEnumerable<UserProductOffer>>
    {
        public string UserId { get; set; }
        public class GetAllMyOffersQueryHandler : IRequestHandler<GetAllMyOffersQuery, IEnumerable<UserProductOffer>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllMyOffersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<UserProductOffer>> Handle(GetAllMyOffersQuery request, CancellationToken cancellationToken)
            {
                var userProductOfferList = await _context.UserProductOffer.Where(x=>x.UserId ==request.UserId).ToListAsync();
                if (userProductOfferList == null)
                {
                    return null;
                }
                return userProductOfferList.AsReadOnly();
            }
        }
    }
}
