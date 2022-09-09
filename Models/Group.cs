using System.ComponentModel.DataAnnotations;

namespace Contact.Center.Api.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; } 
        [Required]
        [MaxLength(150)]
        public string? GroupName { get; set; }
        [Required]
        [MaxLength(5)]
        public string? GroupInitials { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<Kpi>? Kpis { get; set; }
        public int ChannelId { get; set; }
        public Channel? Channel { get; set; }
    }
}