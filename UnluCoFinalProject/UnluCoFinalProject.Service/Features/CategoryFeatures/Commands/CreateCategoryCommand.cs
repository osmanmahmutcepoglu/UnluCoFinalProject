using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Persistence;

namespace UnluCoFinalProject.Service.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new Category();
                category.CategoryName = request.CategoryName;
                category.Description = request.Description;

                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return category.Id;
            }
        }
    }
}
