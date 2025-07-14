using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.Core.Entities
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }

    }
}
