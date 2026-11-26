using System;

namespace PeriodizationApp.Core.Entities
{
    public class SetRecord
    {
        public Guid Id { get; set; }

        // Hacemos la sesión opcional para permitir el "Entrenamiento Libre"
        public Guid? WorkoutSessionId { get; set; }
        public WorkoutSession? WorkoutSession { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        public int SetNumber { get; set; }
        public decimal Weight { get; set; }

        public int TargetReps { get; set; }
        public int ActualReps { get; set; }

        public int TargetRIR { get; set; }
        public int ActualRIR { get; set; }

        public string? Notes { get; set; }

        // --- NUEVA MÉTRICA ANALÍTICA ---
        public decimal Estimated1RM { get; set; }

        // --- LÓGICA DE NEGOCIO (Domain-Driven Design) ---
        public void Calculate1RM()
        {
            if (ActualReps > 0 && Weight > 0)
            {
                // Fórmula de Epley adaptada a C# (Peso * (1 + (Reps / 30)))
                Estimated1RM = Math.Round(Weight * (1m + ((decimal)ActualReps / 30m)), 2);
            }
            else
            {
                Estimated1RM = 0;
            }
        }
    }
}