using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HowToGet_RingId",
                table: "HowToGet");

            migrationBuilder.CreateIndex(
                name: "IX_HowToGet_RingId",
                table: "HowToGet",
                column: "RingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HowToGet_RingId",
                table: "HowToGet");

            migrationBuilder.CreateIndex(
                name: "IX_HowToGet_RingId",
                table: "HowToGet",
                column: "RingId",
                unique: true);
        }
    }
}
