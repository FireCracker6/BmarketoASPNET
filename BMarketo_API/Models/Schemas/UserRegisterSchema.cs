using System.ComponentModel.DataAnnotations;
using BMarketo_API.Models.Entities;

namespace BMarketo_API.Models.Schemas
{
    public class UserRegisterSchema
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        [MinLength(6)]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$")]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        public string Password { get; set; } = null!;

        public static implicit operator IdentityUserEntity(UserRegisterSchema schema)
        {
            return new IdentityUserEntity
            {
                FirstName = schema.FirstName,
                LastName = schema.LastName,
                PhoneNumber = schema.PhoneNumber,
                Email = schema.Email,
                UserName = schema.Email
            };
        }
    }
}
