using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Common;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.OfferFeatures.Commands
{
    public class DeleteOfferByIdCommand : IRequest<AppResponse>
    {
        public int Id { get; set; }
        public class DeleteOfferByIdCommandHandler : IRequestHandler<DeleteOfferByIdCommand, AppResponse>
        {
            private readonly IApplicationDbContext _context;
            public DeleteOfferByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<AppResponse> Handle(DeleteOfferByIdCommand request, CancellationToken cancellationToken)
            {
                var offer = await _context.UserProductOffer.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (offer == null) { return new AppResponse { Succeeded = false, Message = "Teklif bulunamadı.", Errors = null }; }
                _context.UserProductOffer.Remove(offer);
                await _context.SaveChangesAsync();
                return new AppResponse { Succeeded = true, Message = "Teklif başarıyla silindi.", Errors = null }; ;
            }
        }
    }
}
