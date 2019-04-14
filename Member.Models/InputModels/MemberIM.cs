using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Member.Models.InputModels
{
  public class MemberIM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Phone { get; set; }
    }
}
