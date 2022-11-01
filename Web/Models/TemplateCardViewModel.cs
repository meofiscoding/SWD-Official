namespace Web.Models
{
    public class TemplateCardViewModel
    {
        public int TemplateId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? FileName { get; set; }
    }
}
