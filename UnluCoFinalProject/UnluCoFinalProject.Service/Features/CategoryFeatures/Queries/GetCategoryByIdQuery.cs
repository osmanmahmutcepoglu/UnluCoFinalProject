using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.CategoryFeatures.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
        {
            private readonly IApplicationDbContext _context;
            public GetCategoryByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = _context.Category.Where(a => a.Id == request.Id).FirstOrDefault();
                if (category == null) return null;
                return category;
            }
        }
    }
}
