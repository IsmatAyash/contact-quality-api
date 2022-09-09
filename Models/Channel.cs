using System.ComponentModel.DataAnnotations;

namespace Contact.Center.Api.Models
{
    public class Channel
    {
        [Key]
        public int ChannelId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? ChannelName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public List<Group>? Groups { get; set; }
    }
}