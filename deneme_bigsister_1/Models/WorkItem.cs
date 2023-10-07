namespace deneme_bigsister_1.Models
{
    public class WorkItem:BaseEntity
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? ContentValue { get; set; }
        public int Order { get; set; }

    }
}
