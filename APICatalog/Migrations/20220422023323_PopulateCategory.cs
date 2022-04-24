using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    public partial class PopulateCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Category(CategoryName,UrlImage) Values('Bebidas', 'Bebidas.jpg')");
            migrationBuilder.Sql("Insert into Category(CategoryName,UrlImage) Values('Comidas', 'Comidas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Category");
        }
    }
}
