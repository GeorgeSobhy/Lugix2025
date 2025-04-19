using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.Models
{
    public class ContactUsModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string Surname { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [MaxLength(200)]
        public string Subject { get; set; } = null!;
        [MaxLength(500)]
        public string Message { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}
