using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore_2_version.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        [Display(Name="Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
