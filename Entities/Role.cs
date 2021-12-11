using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Api.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}