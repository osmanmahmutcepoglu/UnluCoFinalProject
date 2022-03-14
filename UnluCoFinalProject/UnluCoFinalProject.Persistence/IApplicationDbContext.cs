using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;

namespace UnluCoFinalProject.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Brand> Brand { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Color> Color { get; set; }
        DbSet<IsSold> IsSold { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<UserProductOffer> UserProductOffer { get; set; }

        Task<int> SaveChangesAsync();
    }
}
