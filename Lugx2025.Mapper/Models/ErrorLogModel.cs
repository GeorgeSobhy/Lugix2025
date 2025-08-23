using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lugx2025.Mapper.Models
{
    public class ErrorLogModel
    {
        [Key]
        public int Id { get; set; }
        public string MethodName { get; set; } = null!;
        public string ClassName { get; set; } = null!;

        public string ErrorMsg { get; set; } = null!;
        public string ErrorCode { get; set; } = null!;
        public string StackTrace { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
