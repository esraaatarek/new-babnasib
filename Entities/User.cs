using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Api.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}