using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Rings");

            migrationBuilder.CreateTable(
                name: "HowToGet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowToGet = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HowToGet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HowToGet_Rings_RingId",
                        column: x => x.RingId,
                        principalTable: "Rings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HowToGet_RingId",
                table: "HowToGet",
                column: "RingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HowToGet");

            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Rings",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
