using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PeriodizationApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed51Ejercicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SetRecords",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "IsCompound", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-0000-0000-0000-000000000001"), false, "Pecho", "Press de Banca Plano con Barra" },
                    { new Guid("11111111-0000-0000-0000-000000000002"), false, "Pecho", "Press de Banca Inclinado con Mancuernas" },
                    { new Guid("11111111-0000-0000-0000-000000000003"), false, "Pecho", "Press de Banca Declinado" },
                    { new Guid("11111111-0000-0000-0000-000000000004"), false, "Pecho", "Aperturas con Mancuernas (Inclinadas/Plano)" },
                    { new Guid("11111111-0000-0000-0000-000000000005"), false, "Pecho", "Cruces en Polea Alta" },
                    { new Guid("11111111-0000-0000-0000-000000000006"), false, "Pecho", "Cruces en Polea Baja" },
                    { new Guid("11111111-0000-0000-0000-000000000007"), false, "Pecho", "Fondos en Paralelas (Pecho)" },
                    { new Guid("11111111-0000-0000-0000-000000000008"), false, "Pecho", "Pec Deck (Máquina Contrayectora)" },
                    { new Guid("22222222-0000-0000-0000-000000000001"), false, "Espalda", "Dominadas Pronas (Pull-ups)" },
                    { new Guid("22222222-0000-0000-0000-000000000002"), false, "Espalda", "Dominadas Supinas (Chin-ups)" },
                    { new Guid("22222222-0000-0000-0000-000000000003"), false, "Espalda", "Jalón al Pecho en Polea" },
                    { new Guid("22222222-0000-0000-0000-000000000004"), false, "Espalda", "Remo con Barra Péndulo (Pendlay)" },
                    { new Guid("22222222-0000-0000-0000-000000000005"), false, "Espalda", "Remo con Mancuerna a Una Mano" },
                    { new Guid("22222222-0000-0000-0000-000000000006"), false, "Espalda", "Remo Gironda (Polea Baja)" },
                    { new Guid("22222222-0000-0000-0000-000000000007"), false, "Espalda", "Remo en Máquina (Chest-Supported)" },
                    { new Guid("22222222-0000-0000-0000-000000000008"), false, "Espalda", "Pulldown con Brazos Rectos" },
                    { new Guid("22222222-0000-0000-0000-000000000009"), false, "Espalda", "Peso Muerto Tradicional" },
                    { new Guid("33333333-0000-0000-0000-000000000001"), false, "Hombro", "Press Militar con Barra de Pie" },
                    { new Guid("33333333-0000-0000-0000-000000000002"), false, "Hombro", "Press de Hombros Sentado con Mancuernas" },
                    { new Guid("33333333-0000-0000-0000-000000000003"), false, "Hombro", "Elevaciones Laterales con Mancuernas" },
                    { new Guid("33333333-0000-0000-0000-000000000004"), false, "Hombro", "Elevaciones Laterales en Polea" },
                    { new Guid("33333333-0000-0000-0000-000000000005"), false, "Hombro", "Elevaciones Frontales" },
                    { new Guid("33333333-0000-0000-0000-000000000006"), false, "Hombro", "Pájaros (Deltoides Posterior) con Mancuernas" },
                    { new Guid("33333333-0000-0000-0000-000000000007"), false, "Hombro", "Face Pull en Polea" },
                    { new Guid("33333333-0000-0000-0000-000000000008"), false, "Hombro", "Remo al Mentón" },
                    { new Guid("44444444-0000-0000-0000-000000000001"), false, "Pierna", "Sentadilla Libre con Barra" },
                    { new Guid("44444444-0000-0000-0000-000000000002"), false, "Pierna", "Sentadilla Búlgara con Mancuernas" },
                    { new Guid("44444444-0000-0000-0000-000000000003"), false, "Pierna", "Sentadilla Hack en Máquina" },
                    { new Guid("44444444-0000-0000-0000-000000000004"), false, "Pierna", "Prensa de Piernas (Leg Press)" },
                    { new Guid("44444444-0000-0000-0000-000000000005"), false, "Pierna", "Extensiones de Cuádriceps" },
                    { new Guid("44444444-0000-0000-0000-000000000006"), false, "Pierna", "Peso Muerto Rumano (RDL)" },
                    { new Guid("44444444-0000-0000-0000-000000000007"), false, "Pierna", "Peso Muerto Piernas Rígidas" },
                    { new Guid("44444444-0000-0000-0000-000000000008"), false, "Pierna", "Curl de Isquiotibiales Tumbado" },
                    { new Guid("44444444-0000-0000-0000-000000000009"), false, "Pierna", "Curl de Isquiotibiales Sentado" },
                    { new Guid("44444444-0000-0000-0000-000000000010"), false, "Pierna", "Hip Thrust con Barra" },
                    { new Guid("44444444-0000-0000-0000-000000000011"), false, "Pierna", "Elevación de Talones de Pie (Pantorrilla)" },
                    { new Guid("44444444-0000-0000-0000-000000000012"), false, "Pierna", "Elevación de Talones Sentado (Costurera)" },
                    { new Guid("55555555-0000-0000-0000-000000000001"), false, "Bíceps", "Curl de Bíceps con Barra Recta" },
                    { new Guid("55555555-0000-0000-0000-000000000002"), false, "Bíceps", "Curl con Barra EZ" },
                    { new Guid("55555555-0000-0000-0000-000000000003"), false, "Bíceps", "Curl Alterno con Mancuernas" },
                    { new Guid("55555555-0000-0000-0000-000000000004"), false, "Bíceps", "Curl Martillo" },
                    { new Guid("55555555-0000-0000-0000-000000000005"), false, "Bíceps", "Curl en Banco Predicador (Scott)" },
                    { new Guid("55555555-0000-0000-0000-000000000006"), false, "Bíceps", "Curl Concentrado con Mancuerna" },
                    { new Guid("55555555-0000-0000-0000-000000000007"), false, "Bíceps", "Curl de Bíceps en Polea Baja" },
                    { new Guid("66666666-0000-0000-0000-000000000001"), false, "Tríceps", "Extensión de Tríceps en Polea (Cuerda)" },
                    { new Guid("66666666-0000-0000-0000-000000000002"), false, "Tríceps", "Extensión de Tríceps en Polea (Barra Recta)" },
                    { new Guid("66666666-0000-0000-0000-000000000003"), false, "Tríceps", "Press Francés (Skullcrushers)" },
                    { new Guid("66666666-0000-0000-0000-000000000004"), false, "Tríceps", "Copa de Tríceps a Dos Manos" },
                    { new Guid("66666666-0000-0000-0000-000000000005"), false, "Tríceps", "Extensión por Encima de la Cabeza en Polea" },
                    { new Guid("66666666-0000-0000-0000-000000000006"), false, "Tríceps", "Patada de Tríceps con Mancuerna" },
                    { new Guid("66666666-0000-0000-0000-000000000007"), false, "Tríceps", "Press de Banca Agarre Estrecho" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("55555555-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("66666666-0000-0000-0000-000000000007"));

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SetRecords",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
