using System;
using System.Collections.Generic;

namespace PeriodizationApp.Core.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public bool IsCompound { get; set; }

        public ICollection<SetRecord>? SetRecords { get; set; }
    }
}
