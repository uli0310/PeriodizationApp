using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeriodizationApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogicaPeriodizacion1RM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetRecords_WorkoutSessions_WorkoutSessionId",
                table: "SetRecords");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutSessionId",
                table: "SetRecords",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<decimal>(
                name: "Estimated1RM",
                table: "SetRecords",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_SetRecords_WorkoutSessions_WorkoutSessionId",
                table: "SetRecords",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetRecords_WorkoutSessions_WorkoutSessionId",
                table: "SetRecords");

            migrationBuilder.DropColumn(
                name: "Estimated1RM",
                table: "SetRecords");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutSessionId",
                table: "SetRecords",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SetRecords_WorkoutSessions_WorkoutSessionId",
                table: "SetRecords",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
