using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.ViewModels
{
    public class TopCategoriesVM
    {
        public string CategoryName { get; set; } = null!;
        public string GameImageUrl { get; set; } = null!;
    }
}
