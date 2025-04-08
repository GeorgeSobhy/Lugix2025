using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.ViewModels
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public float PriceBeforeSale { get; set; }
        public float PriceAfterSale { get; set; }
        public int AvailableCount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int PurchaseCount { get; set; }
        public int GenreId { get; set; }
        public int UploaderId { get; set; }
        public int VisitorsNumber { get; set; }
        public float StarsCount { get; set; }
        public int ReviewsNumber { get; set; }
        public string GameCode { get; set; } = null!;

        public ICollection<GameVM> RelatedGames { get; set; }
    }
}
