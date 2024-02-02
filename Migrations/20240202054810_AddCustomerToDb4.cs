using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class AddCustomerToDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amountt",
                table: "TbOrderDetail");

            migrationBuilder.RenameColumn(
                name: "Ids",
                table: "TbOrderDetail",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "TbOrderDetail",
                newName: "Ids");

            migrationBuilder.AddColumn<int>(
                name: "Amountt",
                table: "TbOrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
