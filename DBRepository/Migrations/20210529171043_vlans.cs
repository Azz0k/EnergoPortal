using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class vlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VLAN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VLANName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SubNet = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    isAllowedToDC = table.Column<int>(type: "int", nullable: false),
                    isAllowedToBC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VLAN", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VLAN");
        }
    }
}
