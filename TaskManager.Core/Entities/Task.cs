using System.ComponentModel.DataAnnotations;

namespace TaskManager.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
    }
    
    public enum TaskPriority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }
}
