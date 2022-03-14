using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Common;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.ProductFeatures.Queries
{
    public class ProductsIsSoldQuery : IRequest<AppResponse>
    {
        public int ProductId { get; set; }
        public string IsSold { get; set; }
        public class ProductsIsSoldQueryHandler : IRequestHandler<ProductsIsSoldQuery, AppResponse>
        {
            private readonly IApplicationDbContext _context;
            public ProductsIsSoldQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<AppResponse> Handle(ProductsIsSoldQuery request, CancellationToken cancellationToken)
            {
                var product = _context.Product.Where(a => a.Id == request.ProductId).FirstOrDefault();

                if (product == null)
                {
                    return new AppResponse { Succeeded = false, Message = "Ürün bulunamadı.", Errors = null };
                }
                else
                {
                    product.IsSold = request.IsSold;
                    _context.Product.Update(product);

                    await _context.SaveChangesAsync();
                    return new AppResponse { Succeeded = true, Message = "İşlem başarılı.", Errors = null };
                }
            }
        }
    }
}
