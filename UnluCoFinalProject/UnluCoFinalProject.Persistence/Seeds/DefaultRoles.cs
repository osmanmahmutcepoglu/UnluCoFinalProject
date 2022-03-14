using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using UnluCoFinalProject.Domain.Enum;

namespace UnluCoFinalProject.Persistence.Seeds
{
    public static class DefaultRoles
    {
        public static List<IdentityRole> IdentityRoleList()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = Constants.ADMIN,
                    Name = Roles.ADMIN.ToString(),
                    NormalizedName = Roles.ADMIN.ToString()
                },
                new IdentityRole
                {
                    Id = Constants.BASIC,
                    Name = Roles.BASIC.ToString(),
                    NormalizedName = Roles.BASIC.ToString()
                }
            };
        }
    }
}
