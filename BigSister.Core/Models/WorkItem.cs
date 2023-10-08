namespace BigSister.Core.Models
{
    public class WorkItem:BaseEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string? Context { get; set; }
        public int? Order { get; set; }

    }
}
