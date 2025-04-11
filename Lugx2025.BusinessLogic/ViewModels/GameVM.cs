using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.ViewModels
{
    public class GameVM
    {
        [Key]
        public int Id { get; set; }
        public string PhotoPath { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, float.MaxValue)]
        public float PriceBeforeSale { get; set; }
        [Range(0, float.MaxValue)]
        public float PriceAfterSale { get; set; }
        public string Genre { get; set; } = null!;
    }
}
