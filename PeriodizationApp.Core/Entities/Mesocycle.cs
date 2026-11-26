using System;
using System.Collections.Generic;

namespace PeriodizationApp.Core.Entities
{
    public class Mesocycle
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<WorkoutSession>? Sessions { get; set; }
    }
}
