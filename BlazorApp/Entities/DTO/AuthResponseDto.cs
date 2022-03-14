using System.Collections.Generic;

namespace BlazorApp.Entities.DTO
{
    public class AuthResponseDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string JWToken { get; set; }
    }
}
