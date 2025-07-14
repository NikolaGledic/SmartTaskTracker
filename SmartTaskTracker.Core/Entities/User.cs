using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.Core.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }

        //navigacione kolekcije sta su?
        public ICollection<TeamUser> TeamUsers { get; set; }
        public ICollection<TaskItem> CreatedTask { get; set; }
        public ICollection<TaskItem> AssignedTasks { get; set; }
        public ICollection<Comment> Comments { get; set; }




    }
}
