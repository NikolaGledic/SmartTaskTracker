using System;
using System.ComponentModel.DataAnnotations;

namespace SmartTaskTracker.Core.Entities
{
    public class ExternalIntegration
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string ServiceName { get; set; }

        [Required]
        public DateTime LastFetched { get; set; }

        [Required]
        public string Payload { get; set; }


    }
}