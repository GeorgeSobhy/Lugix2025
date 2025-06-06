﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.Models
{
    public class NewsLetterModel
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
