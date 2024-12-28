using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Core_MVC.Migrations
{
    /// <inheritdoc />
    public partial class SerialNumbermigrationonetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNumberId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SerialNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialNumber_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Name", "Price", "SerialNumberId" },
                values: new object[] { 4, "Laptop", 1000.0, 10 });

            migrationBuilder.InsertData(
                table: "SerialNumber",
                columns: new[] { "Id", "ItemId", "Name" },
                values: new object[] { 10, 4, "1234Laptop56" });

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumber_ItemId",
                table: "SerialNumber",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialNumber");

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "SerialNumberId",
                table: "Item");
        }
    }
}
