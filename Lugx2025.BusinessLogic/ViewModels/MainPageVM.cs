using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.BusinessLogic.ViewModels
{
    public class MainPageVM
    {
        public string MainGameImage { get; set; } = null!;
        public float GamePriceWithoutDiscount { get; set; }
        public string MainPageDescription { get; set; } = null!;
        public float GamePriceAfterDiscount{ get; set; }
        public ICollection<GameVM> TrendingGames { get; set; } = new HashSet<GameVM>();
        public ICollection<GameVM> MostPlayed { get; set; } = new HashSet<GameVM>();
        public ICollection<GameVM> TopCategoriesGames { get; set; } = new HashSet<GameVM>();

    
    }
}
