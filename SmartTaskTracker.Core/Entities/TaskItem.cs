using System;
using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.Core.Entities
{
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [Required, MaxLength(50)]
        public string Status { get; set; }
        public DateTime? Deadline { get; set; }

        public Guid? AssigneeId { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }

        //navigacione
        public User Assignee { get; set; }
        public User Creator { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}