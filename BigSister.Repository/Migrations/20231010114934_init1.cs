using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigSister.Repository.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConstantValues",
                columns: new[] { "Id", "Context", "CreatedDate", "Section", "UpdatedDate" },
                values: new object[] { 8, null, null, "iframeLocation", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConstantValues",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
