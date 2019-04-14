using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Member.Models.DbModels
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        { }
       
    }
}
