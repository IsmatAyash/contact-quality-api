using System.ComponentModel.DataAnnotations;
namespace Contact.Center.Api.Models
{
    public class Kpi
    {
        [Key]
        public int KpiId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? KpiName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? KpiType { get; set; }
        public int KpiMaxGrade { get; set; }
        public string? KpiRadioBtn { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}