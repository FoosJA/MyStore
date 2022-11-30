using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyStore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "А boat for one person", "Kayak", 275m },
                    { 2, "Watersports", "Protective and fashionable", "Lifejacket", 48.95m },
                    { 3, "Soccer", "FIFA-approved size and weight", "Soccer Ball", 19.50m },
                    { 4, "Soccer", "Give your playing field а professional touch", "Corner Flags", 34.95m },
                    { 5, "Soccer", "Flat-packed 35, 000-seat stadium", "Stadium", 79500m },
                    { 6, "Chess", "Improve brain efficiency Ьу 75i", "Thinking Сар", 16m },
                    { 7, "Chess", "Secretly give your opponent а disadvantage", "Unsteady Chair", 29.95m },
                    { 8, "Chess", "А fun game for the family", "Human Chess Board", 75m },
                    { 9, "Chess", "Gold-plated, diamond-studded King", "Bling-Bling King", 1200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
