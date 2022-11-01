using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTO
{
    public  class CardTypeDTO
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public int Status { get; set; }
        public string? Detail { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
