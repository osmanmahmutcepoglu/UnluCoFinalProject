using System;
using System.Collections.Generic;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Domain.Enum;

namespace UnluCoFinalProject.Persistence.Seeds
{
    public static class DefaultBrand
    {
        public static List<Brand> BrandList()
        {
            return new List<Brand>()
            {
                new Brand
                {
                    Id = 1,
                    BrandName = Brands.Ferrari.ToString()
                },
                new Brand
                {
                    Id = 2,
                    BrandName = Brands.BMW.ToString()
                },
                new Brand
                {
                    Id = 3,
                    BrandName = Brands.VOLKSWAGEN.ToString()
                },
                new Brand
                {
                    Id = 4,
                    BrandName = Brands.OPEL.ToString()
                },
                new Brand
                {
                    Id = 5,
                    BrandName = Brands.FIAT.ToString()
                }
            };
        }
    }
}
