using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    artist = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "song",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    albumid_fk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song", x => x.id);
                    table.ForeignKey(
                        name: "FK_song_album_albumid_fk",
                        column: x => x.albumid_fk,
                        principalTable: "album",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "album",
                columns: new[] { "id", "artist", "title" },
                values: new object[] { 1, "Empty Reflection", "Awe" });

            migrationBuilder.InsertData(
                table: "song",
                columns: new[] { "id", "albumid_fk", "title" },
                values: new object[,]
                {
                    { 1, 1, "Quietly Tragic" },
                    { 2, 1, "Just a normal Day" },
                    { 3, 1, "Live for Free" },
                    { 4, 1, "Just a normal day" },
                    { 5, 1, "She'd be there" },
                    { 6, 1, "Listen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_song_albumid_fk",
                table: "song",
                column: "albumid_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "song");

            migrationBuilder.DropTable(
                name: "album");
        }
    }
}
