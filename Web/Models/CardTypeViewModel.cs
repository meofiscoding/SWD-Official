namespace Web.Models
{
    public class CardTypeViewModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public int CardTypeStatus { get; set; }
        public string? Detail { get; set; }
        public DateTime? CardTypeCreatedAt { get; set; }
        public DateTime? CardTypeUpdatedAt { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public int TemplateCardStatus { get; set; }
        public DateTime? TemplateCardCreatedAt { get; set; }
        public DateTime? TemplateCardUpdatedAt { get; set; }
        public string? FileName { get; set; }
        public int TemplateId { get; set; }

    }
}
