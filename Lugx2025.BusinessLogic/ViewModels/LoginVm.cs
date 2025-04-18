using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.ViewModels
{
    public class LoginVm
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
