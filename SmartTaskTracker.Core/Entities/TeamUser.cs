using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Core.Entities
{
    public class TeamUser
    {
        [Required]
        public Guid TeamId { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [Required, MaxLength(50)]
        public string Role { get; set; }

        public Team Team { get; set; }
        public User User { get; set; }

    }
}
