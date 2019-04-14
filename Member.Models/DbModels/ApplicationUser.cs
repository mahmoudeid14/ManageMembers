using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Member.Models.DbModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
