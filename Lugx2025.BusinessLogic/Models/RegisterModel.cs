using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password),ErrorMessage ="Password & confirm password must be the same ")]
        public string ReWritePassword { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;
        public int CityId { get; set; }
        public int CountryId { get; set; }

        public bool Agree { get; set; }
    }
}
