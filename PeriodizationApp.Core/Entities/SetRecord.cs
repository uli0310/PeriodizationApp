using System;

namespace PeriodizationApp.Core.Entities
{
    public class SetRecord
    {
        public Guid Id { get; set; }

        // Usuario propietario del registro (permite separar series libres y por sesión por cuenta)
        public Guid? UserId { get; set; }

        // Sesión opcional para permitir "Entrenamiento Libre"
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

        // 1RM Estimado considerando proximidad al fallo (ActualReps + ActualRIR)
        public decimal Estimated1RM { get; set; }

        // --- MOTOR BIOMECÁNICO BASADO EN EVIDENCIA (Epley + Brzycki ajustados por RIR) ---
        public void Calculate1RM()
        {
            Estimated1RM = ComputeScientific1RM(Weight, ActualReps, ActualRIR);
        }

        public static decimal ComputeScientific1RM(decimal weight, int actualReps, int actualRir)
        {
            if (actualReps <= 0 || weight <= 0)
            {
                return 0m;
            }

            // Repeticiones efectivas al fallo = Reps realizadas + Reps en reserva (limitado a RIR <= 5 para precisión)
            int effectiveRir = Math.Clamp(actualRir, 0, 5);
            int effectiveRepsToFailure = actualReps + effectiveRir;

            if (effectiveRepsToFailure == 1)
            {
                return Math.Round(weight, 2);
            }

            // Rango 2-10 reps al fallo: Fórmula de Epley ajustada por RIR
            if (effectiveRepsToFailure <= 10)
            {
                return Math.Round(weight * (1m + (effectiveRepsToFailure / 30m)), 2);
            }

            // Rango >10 reps al fallo: Promedio híbrido Epley + Brzycki para evitar sobreestimación en altas repeticiones
            decimal epley = weight * (1m + (effectiveRepsToFailure / 30m));
            int clampedForBrzycki = Math.Min(effectiveRepsToFailure, 30);
            decimal brzycki = weight * (36m / (37m - clampedForBrzycki));

            return Math.Round((epley + brzycki) / 2m, 2);
        }
    }
}
