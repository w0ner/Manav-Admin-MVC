using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace manav.Migrations
{
    /// <inheritdoc />
    public partial class bir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Renkler",
                columns: table => new
                {
                    RenkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenkAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renkler", x => x.RenkID);
                });

            migrationBuilder.CreateTable(
                name: "Meyveler",
                columns: table => new
                {
                    MeyveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeyveAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    RenkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meyveler", x => x.MeyveID);
                    table.ForeignKey(
                        name: "FK_Meyveler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meyveler_Renkler_RenkID",
                        column: x => x.RenkID,
                        principalTable: "Renkler",
                        principalColumn: "RenkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriID", "KategoriAdı" },
                values: new object[,]
                {
                    { 1, "Tropikal Meyveler" },
                    { 2, "Şekerli Meyveler" },
                    { 3, "Ekşi Meyveler" },
                    { 4, "Kış Meyveler" }
                });

            migrationBuilder.InsertData(
                table: "Renkler",
                columns: new[] { "RenkID", "RenkAdı" },
                values: new object[,]
                {
                    { 1, "Kırmızı" },
                    { 2, "Sarı" },
                    { 3, "Mor" },
                    { 4, "Mavi" },
                    { 5, "Yeşil" },
                    { 6, "Siyah" }
                });

            migrationBuilder.InsertData(
                table: "Meyveler",
                columns: new[] { "MeyveID", "KategoriID", "MeyveAdı", "RenkID" },
                values: new object[,]
                {
                    { 1, 2, "elma", 1 },
                    { 2, 1, "armut", 2 },
                    { 3, 3, "muz", 4 },
                    { 4, 1, "çilek", 5 },
                    { 5, 4, "erik", 2 },
                    { 6, 2, "karpuz", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meyveler_KategoriID",
                table: "Meyveler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Meyveler_RenkID",
                table: "Meyveler",
                column: "RenkID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meyveler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Renkler");
        }
    }
}
