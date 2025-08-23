using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Mapper.ViewModels
{
    public class ContactUsPageVM
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(50)]
        public string Surname { get; set; } = null!;
        [MaxLength(100)]
        [Required]

        public string Email { get; set; } = null!;

        [MaxLength(200)]
        public string Subject { get; set; } = null!;
        [MaxLength(500)]
        public string Message { get; set; } = null!;
        public string ContactUsDescription { get; set; } = null!;
        [MaxLength(200)]
        [Required]
        public string ContactUsAddress { get; set; } = null!;
        [MaxLength(200)]
        [Required]
        public string ContactUsphone { get; set; } = null!;
        [MaxLength(200)]
        [Required]
        public string ContactUsEmail { get; set; } = null!;
        [MaxLength(500)]
        [Required]
        public string ContactUsMap { get; set; } = null!;
    }

}
