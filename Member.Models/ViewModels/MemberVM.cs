﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Member.Models.ViewModels
{
   public class MemberVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
