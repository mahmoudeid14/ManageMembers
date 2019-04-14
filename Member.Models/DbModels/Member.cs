using Member.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Member.Models.DbModels
{
   public class Member : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
