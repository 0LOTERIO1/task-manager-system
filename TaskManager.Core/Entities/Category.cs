using System.ComponentModel.DataAnnotations;

namespace TaskManager.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(7)]
        public string Color { get; set; } = "#007bff";
        
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
