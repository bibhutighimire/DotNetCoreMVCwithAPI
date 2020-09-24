using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCwithAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    quantity = table.Column<int>(type: "int(10)", nullable: false),
                    isDiscontinued = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "ID", "isDiscontinued", "name", "quantity" },
                values: new object[,]
                {
                    { -1, false, "Tomato", 49 },
                    { -2, false, "Metal", 75 },
                    { -3, false, "Jacket", 33 },
                    { -4, true, "Chair", 45 },
                    { -5, false, "Pet Food", 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
