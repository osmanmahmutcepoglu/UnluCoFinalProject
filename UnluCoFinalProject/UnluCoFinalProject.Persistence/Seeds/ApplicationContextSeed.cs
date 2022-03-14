using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UnluCoFinalProject.Domain.Auth;
using UnluCoFinalProject.Domain.Entities;

namespace UnluCoFinalProject.Persistence.Seeds
{
    public static class ApplicationContextSeed
    {
        public static void ApplicationSeed(this ModelBuilder modelBuilder)
        {

            CreateColors(modelBuilder);

            CreateBrands(modelBuilder);

            CreateIsSolds(modelBuilder);
        }

        private static void CreateColors(ModelBuilder modelBuilder)
        {
            List<Color> colors = DefaultColor.ColorList();
            modelBuilder.Entity<Color>().HasData(colors);
        }

        private static void CreateBrands(ModelBuilder modelBuilder)
        {
            List<Brand> brands = DefaultBrand.BrandList();
            modelBuilder.Entity<Brand>().HasData(brands);
        }

        private static void CreateIsSolds(ModelBuilder modelBuilder)
        {
            List<IsSold> isSold = DefaultIsSold.IsSoldList();
            modelBuilder.Entity<IsSold>().HasData(isSold);
        }
    }
}
