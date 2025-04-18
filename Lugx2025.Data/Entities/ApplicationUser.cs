using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lugx2025.Data.Entities
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string Address { get; set; } = null!;
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
    }
}