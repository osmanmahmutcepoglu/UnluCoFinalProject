using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UnluCoFinalProject.Domain.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}