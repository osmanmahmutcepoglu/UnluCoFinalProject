using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _context.Category.Where(a => a.Id == request.Id).FirstOrDefault();

                if (category == null)
                {
                    return default;
                }
                else
                {
                    category.CategoryName = request.CategoryName;
                    category.Description = request.Description;
                    _context.Category.Update(category);
                    await _context.SaveChangesAsync();
                    return category.Id;
                }
            }
        }
    }
}
