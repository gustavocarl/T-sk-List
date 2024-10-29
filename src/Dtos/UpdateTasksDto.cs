using System.ComponentModel.DataAnnotations;

namespace Task_List.Dtos
{
    public class UpdateTasksDto
    {
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsComplete { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}