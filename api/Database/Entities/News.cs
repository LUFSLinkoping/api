using System.ComponentModel.DataAnnotations;

namespace api.Database.Entities
{
    public class News
    {
        [Key]
        public long Id { get; set; }

        public NewsStatus Status { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public bool Featured { get; set; }
        public NewsCategory Category { get; set; }
        public long? AuthorId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public enum NewsStatus
    {
        DRAFT,
        PUBLISHED
    }

    public enum NewsCategory
    {
        CLUB,
        DISCGOLF,
        ALLROUND,
        OTHER
    }
}
