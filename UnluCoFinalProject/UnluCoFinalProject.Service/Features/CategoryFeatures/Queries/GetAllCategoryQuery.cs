using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.CategoryFeatures.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {

        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCategoryQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var categoryList = await _context.Category.ToListAsync();
                if (categoryList == null)
                {
                    return null;
                }
                return categoryList.AsReadOnly();
            }
        }
    }
}
