using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeacherDiary.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_TicketsForUse_TicketForUseId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "TicketForUseId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_TicketsForUse_TicketForUseId",
                table: "Persons",
                column: "TicketForUseId",
                principalTable: "TicketsForUse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_TicketsForUse_TicketForUseId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "TicketForUseId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_TicketsForUse_TicketForUseId",
                table: "Persons",
                column: "TicketForUseId",
                principalTable: "TicketsForUse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
