using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using UnluCoFinalProject.Domain.Enum;

namespace UnluCoFinalProject.Persistence.Seeds
{
    public static class MappingUserRole
    {
        public static List<IdentityUserRole<string>> IdentityUserRoleList()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = Constants.BASIC,
                    UserId = Constants.BASIC
                },
                new IdentityUserRole<string>
                {
                    RoleId = Constants.ADMIN,
                    UserId = Constants.ADMIN
                }
            };
        }
    }
}
