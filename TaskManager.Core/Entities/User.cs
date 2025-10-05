using System.ComponentModel.DataAnnotations;

namespace TaskManager.Core.Entities
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLoginAt { get; set; }
        
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
