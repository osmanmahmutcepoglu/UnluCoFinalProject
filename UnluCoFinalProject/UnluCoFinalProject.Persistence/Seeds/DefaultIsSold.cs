using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Entities;
using UnluCoFinalProject.Domain.Enum;

namespace UnluCoFinalProject.Persistence.Seeds
{
    public static class DefaultIsSold
    {
        public static List<IsSold> IsSoldList()
        {
            return new List<IsSold>()
            {
                new IsSold
                {
                    Id = 1,
                    Name= IsSolds.Aktif.ToString()
                },
                new IsSold
                {
                    Id = 2,
                    Name = IsSolds.Pasif.ToString()
                }
            };
        }
    }
}
