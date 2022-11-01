using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.DTO
{
    public class CardTemplateDTO
    {
        public int TemplateId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? FileName { get; set; }
        public string TypeName { get; set; }

    }
}
