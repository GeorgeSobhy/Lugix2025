using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Data.Entities
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public string MainPageHeader { get; set; } = null!;
        [ForeignKey(nameof(MainGame))]
        public int MainGameId { get; set; }
        public string ContactUsDescription { get; set; } = null!;
        public string ContactUsAddress { get; set; } = null!;
        public string ContactUsPhone { get; set; } = null!;
        [EmailAddress]
        public string ContactUsEmail{ get; set; } = null!;
        public string ContactUsMapUrl { get; set; } = null!;


        public virtual Game MainGame { get; set; }
    }
}
