﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lugx2025.BusinessLogic.Models
{
    public class ApplicationUserModel:IdentityUser<int>
    {
        public string Address { get; set; } = null!;
    }
}