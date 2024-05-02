using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int? AddressId { get; set; }
        [Required]
        public string code { get; set; }

        public AddressModel Address { get; set; }
    }
}
