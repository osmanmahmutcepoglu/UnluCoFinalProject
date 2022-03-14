using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Auth;

namespace UnluCoFinalProject.Service.Validation
{
    public class CustomIdentityPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (password.Count() > 20)
            {
                errors.Add(new IdentityError()
                {
                    Code = "PasswordLength",
                    Description = "Passwords must be a maximum of 20 characters."
                });
            }
            var result = errors.Count() == 0 ?
                Task.FromResult(IdentityResult.Success) :
                Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            return result;
        }
    }
}
