using System;
using System.Collections.Generic;

namespace PeriodizationApp.Core.Entities
{
    public class WorkoutSession
    {
        public Guid Id { get; set; }
        public Guid MesocycleId { get; set; }
        public Mesocycle? Mesocycle { get; set; }

        public string Name { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public int ReadinessScore { get; set; }
        public int SessionRPE { get; set; }

        public ICollection<SetRecord>? SetRecords { get; set; }
    }
}
