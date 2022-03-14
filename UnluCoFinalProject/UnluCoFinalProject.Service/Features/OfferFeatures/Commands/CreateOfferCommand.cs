using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Common;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.OfferFeatures.Commands
{
    public class CreateOfferCommand : IRequest<AppResponse>
    {
        [Required(ErrorMessage ="Kullanıcı bulunamadı.")]
        public string UserId { get; set; }
        [Required(ErrorMessage ="Ürün seçilmedi")]
        public int ProductId { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Rakam giriniz.")]
        public int OfferPrice { get; set; }

        public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, AppResponse>
        {
            private readonly IApplicationDbContext _context;
            public CreateOfferCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<AppResponse> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
            {
                var product = _context.Product.SingleOrDefault(x => x.Id == request.ProductId);
                if (product == null)
                {
                    return new AppResponse { Succeeded = false, Message = "Ürün bulunamadı.", Errors = null };

                }
                else if (product.IsOfferable == false)
                {
                    return new AppResponse { Succeeded = false, Message = "Bu ürüne teklif verilemez.", Errors = null };
                }
                else if (product.UserId == request.UserId)
                {
                    return new AppResponse { Succeeded = false, Message = "Kendi ürününüze teklif veremezsiniz.", Errors = null };
                }

                var userProductOffer = new UserProductOffer();
                userProductOffer.ProductId = request.ProductId;
                userProductOffer.UserId = request.UserId;
                userProductOffer.OfferPrice = request.OfferPrice;
                userProductOffer.OfferAccept = false;
                userProductOffer.OfferDate = DateTime.Now;
                userProductOffer.ProductUserId = product.UserId;


                _context.UserProductOffer.Add(userProductOffer);
                await _context.SaveChangesAsync();
                return new AppResponse { Succeeded = true, Message = "Teklif başarıyla eklendi", Errors = null };
            }
        }
    }
}
