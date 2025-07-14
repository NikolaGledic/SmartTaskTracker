using System;
using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.Core.Entities
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TaskItemId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public DateTime CreatedAt { get; set; }

        //navigacione
        public TaskItem Task { get; set; }
        public User Author { get; set; }

    }
}