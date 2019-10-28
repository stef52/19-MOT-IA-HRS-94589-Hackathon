using Microsoft.EntityFrameworkCore.Migrations;

namespace TC_Hackathon_Reviews.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RatingItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    RatingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewItem_RatingItem_RatingId",
                        column: x => x.RatingId,
                        principalTable: "RatingItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewItem_RatingId",
                table: "ReviewItem",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewItem");

            migrationBuilder.DropTable(
                name: "RatingItem");
        }
    }
}
