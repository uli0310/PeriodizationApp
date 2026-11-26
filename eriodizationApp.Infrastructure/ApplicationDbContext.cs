using System;
using Microsoft.EntityFrameworkCore;
using PeriodizationApp.Core.Entities;

namespace PeriodizationApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mesocycle> Mesocycles { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<SetRecord> SetRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Al eliminar una WorkoutSession o Mesocycle, conservar las series históricas poniendo WorkoutSessionId en NULL
            modelBuilder.Entity<SetRecord>()
                .HasOne(sr => sr.WorkoutSession)
                .WithMany(ws => ws.SetRecords)
                .HasForeignKey(sr => sr.WorkoutSessionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Sembrado de 51 ejercicios categorizados con MuscleGroup e IsCompound corregidos biomecánicamente
            modelBuilder.Entity<Exercise>().HasData(
                // PECHO (11111111)
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000001"), Name = "Press de Banca Plano con Barra", MuscleGroup = "Pecho/Tríceps/Hombro Anterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000002"), Name = "Press de Banca Inclinado con Mancuernas", MuscleGroup = "Pecho Superior/Hombro Anterior/Tríceps", IsCompound = true },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000003"), Name = "Press de Banca Declinado", MuscleGroup = "Pecho Inferior/Tríceps/Hombro Anterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000004"), Name = "Aperturas con Mancuernas (Inclinadas/Plano)", MuscleGroup = "Pecho", IsCompound = false },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000005"), Name = "Cruces en Polea Alta", MuscleGroup = "Pecho Inferior", IsCompound = false },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000006"), Name = "Cruces en Polea Baja", MuscleGroup = "Pecho Superior", IsCompound = false },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000007"), Name = "Fondos en Paralelas (Pecho)", MuscleGroup = "Pecho/Tríceps/Hombro Anterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("11111111-0000-0000-0000-000000000008"), Name = "Pec Deck (Máquina Contrayectora)", MuscleGroup = "Pecho", IsCompound = false },

                // ESPALDA (22222222)
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000001"), Name = "Dominadas Pronas (Pull-ups)", MuscleGroup = "Espalda/Bíceps", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000002"), Name = "Dominadas Supinas (Chin-ups)", MuscleGroup = "Espalda/Bíceps", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000003"), Name = "Jalón al Pecho en Polea", MuscleGroup = "Espalda/Bíceps", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000004"), Name = "Remo con Barra Péndulo (Pendlay)", MuscleGroup = "Espalda/Bíceps/Hombro Posterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000005"), Name = "Remo con Mancuerna a Una Mano", MuscleGroup = "Espalda/Bíceps/Hombro Posterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000006"), Name = "Remo Gironda (Polea Baja)", MuscleGroup = "Espalda/Bíceps/Hombro Posterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000007"), Name = "Remo en Máquina (Chest-Supported)", MuscleGroup = "Espalda/Bíceps/Hombro Posterior", IsCompound = true },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000008"), Name = "Pulldown con Brazos Rectos", MuscleGroup = "Espalda (Dorsal)", IsCompound = false },
                new Exercise { Id = Guid.Parse("22222222-0000-0000-0000-000000000009"), Name = "Peso Muerto Tradicional", MuscleGroup = "Espalda/Glúteo/Isquiotibiales", IsCompound = true },

                // PIERNA (44444444)
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000001"), Name = "Sentadilla Libre con Barra", MuscleGroup = "Cuádriceps/Glúteo/Aductores", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000002"), Name = "Sentadilla Búlgara con Mancuernas", MuscleGroup = "Cuádriceps/Glúteo", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000003"), Name = "Sentadilla Hack en Máquina", MuscleGroup = "Cuádriceps/Glúteo", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000004"), Name = "Prensa de Piernas (Leg Press)", MuscleGroup = "Cuádriceps/Glúteo", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000005"), Name = "Extensiones de Cuádriceps", MuscleGroup = "Cuádriceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000006"), Name = "Peso Muerto Rumano (RDL)", MuscleGroup = "Isquiotibiales/Glúteo/Espalda Baja", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000007"), Name = "Peso Muerto Piernas Rígidas", MuscleGroup = "Isquiotibiales/Glúteo/Espalda Baja", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000008"), Name = "Curl de Isquiotibiales Tumbado", MuscleGroup = "Isquiotibiales", IsCompound = false },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000009"), Name = "Curl de Isquiotibiales Sentado", MuscleGroup = "Isquiotibiales", IsCompound = false },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000010"), Name = "Hip Thrust con Barra", MuscleGroup = "Glúteo/Isquiotibiales", IsCompound = true },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000011"), Name = "Elevación de Talones de Pie (Pantorrilla)", MuscleGroup = "Pantorrilla (Gastrocnemio)", IsCompound = false },
                new Exercise { Id = Guid.Parse("44444444-0000-0000-0000-000000000012"), Name = "Elevación de Talones Sentado (Costurera)", MuscleGroup = "Pantorrilla (Sóleo)", IsCompound = false },

                // HOMBRO (33333333)
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000001"), Name = "Press Militar con Barra de Pie", MuscleGroup = "Hombro/Tríceps", IsCompound = true },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000002"), Name = "Press de Hombros Sentado con Mancuernas", MuscleGroup = "Hombro/Tríceps", IsCompound = true },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000003"), Name = "Elevaciones Laterales con Mancuernas", MuscleGroup = "Hombro Lateral", IsCompound = false },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000004"), Name = "Elevaciones Laterales en Polea", MuscleGroup = "Hombro Lateral", IsCompound = false },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000005"), Name = "Elevaciones Frontales", MuscleGroup = "Hombro Anterior", IsCompound = false },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000006"), Name = "Pájaros (Deltoides Posterior) con Mancuernas", MuscleGroup = "Hombro Posterior", IsCompound = false },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000007"), Name = "Face Pull en Polea", MuscleGroup = "Hombro Posterior/Trapecio", IsCompound = true },
                new Exercise { Id = Guid.Parse("33333333-0000-0000-0000-000000000008"), Name = "Remo al Mentón", MuscleGroup = "Hombro Lateral/Trapecio", IsCompound = true },

                // BÍCEPS (55555555)
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000001"), Name = "Curl de Bíceps con Barra Recta", MuscleGroup = "Bíceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000002"), Name = "Curl con Barra EZ", MuscleGroup = "Bíceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000003"), Name = "Curl Alterno con Mancuernas", MuscleGroup = "Bíceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000004"), Name = "Curl Martillo", MuscleGroup = "Bíceps/Antebrazo", IsCompound = false },
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000005"), Name = "Curl en Banco Predicador (Scott)", MuscleGroup = "Bíceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000006"), Name = "Curl Concentrado con Mancuerna", MuscleGroup = "Bíceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("55555555-0000-0000-0000-000000000007"), Name = "Curl de Bíceps en Polea Baja", MuscleGroup = "Bíceps", IsCompound = false },

                // TRÍCEPS (66666666)
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000001"), Name = "Extensión de Tríceps en Polea (Cuerda)", MuscleGroup = "Tríceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000002"), Name = "Extensión de Tríceps en Polea (Barra Recta)", MuscleGroup = "Tríceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000003"), Name = "Press Francés (Skullcrushers)", MuscleGroup = "Tríceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000004"), Name = "Copa de Tríceps a Dos Manos", MuscleGroup = "Tríceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000005"), Name = "Extensión por Encima de la Cabeza en Polea", MuscleGroup = "Tríceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000006"), Name = "Patada de Tríceps con Mancuerna", MuscleGroup = "Tríceps", IsCompound = false },
                new Exercise { Id = Guid.Parse("66666666-0000-0000-0000-000000000007"), Name = "Press de Banca Agarre Estrecho", MuscleGroup = "Tríceps/Pecho/Hombro Anterior", IsCompound = true }
            );
        }
    }
}
