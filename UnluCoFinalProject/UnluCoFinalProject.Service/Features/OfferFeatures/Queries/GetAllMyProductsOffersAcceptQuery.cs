using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Common;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.OfferFeatures.Queries
{
    public class GetAllMyProductsOffersAcceptQuery : IRequest<AppResponse>
    {
        public int OfferId { get; set; }
        public bool IsAccept { get; set; }
        public class GetAllMyProductsOffersAcceptQueryHandler : IRequestHandler<GetAllMyProductsOffersAcceptQuery, AppResponse>
        {
            private readonly IApplicationDbContext _context;
            public GetAllMyProductsOffersAcceptQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<AppResponse> Handle(GetAllMyProductsOffersAcceptQuery request, CancellationToken cancellationToken)
            {
                var userProductOffer = _context.UserProductOffer.Where(a => a.Id == request.OfferId).FirstOrDefault();

                if (userProductOffer == null)
                {
                    return new AppResponse { Succeeded = false, Message = "Teklif bulunamadı.", Errors = null };
                }
                else
                {
                    var product = _context.Product.Where(a => a.Id == userProductOffer.ProductId).FirstOrDefault();

                    userProductOffer.OfferAccept = request.IsAccept;
                    _context.UserProductOffer.Update(userProductOffer);

                    product.Price = userProductOffer.OfferPrice;
                    _context.Product.Update(product);

                    await _context.SaveChangesAsync();
                    return new AppResponse { Succeeded = true, Message = "İşlem başarılı.", Errors = null };
                }
            }
        }
    }
}
