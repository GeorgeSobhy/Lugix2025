using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Lugx2025.BusinessLogic.Models;

namespace Lugx2025.BusinessLogic.ViewModels
{
    public class ShopVM
    {
        public ICollection<GameVM> Games { get; set; }
        public int CurrentPageNumber { get; set; }
        public int AllPagesNumber { get; set; }
        public ICollection<GenreModel> Genres { get; set; }
    }
}
