using System.ComponentModel.DataAnnotations;

namespace Task_List.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsComplete { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}